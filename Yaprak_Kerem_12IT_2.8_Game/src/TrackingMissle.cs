using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Yaprak_Kerem_12IT_TD_Game
{
    public class TrackingMissile
    {
        //bitmap of image
        Bitmap bmp;
        //

        public PictureBox pictureBox { get; private set; }
        private EnemyAir targetEnemy;
        private float speed;
        private PointF currentPosition;
        private uint damage;

        public TrackingMissile(EnemyAir targetEnemy, PlayerVehicle calledPlayer, uint damage, LevelBase l)
        {
            speed = 1f;
            this.targetEnemy = targetEnemy;
            InitializePictureBox(calledPlayer);
            InitializePosition();
            this.damage = damage;
            this.pictureBox.Visible = true;
            this.pictureBox.Enabled = true;
            l.Controls.Add(this.pictureBox);
        }

        private Bitmap RotateImage(Bitmap bmp, PointF direction)
        {
            float angle = (float)(Math.Atan2(direction.Y, direction.X) * 180f / Math.PI);

            Bitmap rotatedBmp = new Bitmap(bmp.Width, bmp.Height);
            rotatedBmp.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotatedBmp))
            {
                g.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
                g.RotateTransform(angle);
                g.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
                g.DrawImage(bmp, new Point(0, 0));
            }

            return rotatedBmp;
        }

        private void InitializePictureBox(PlayerVehicle calledPlayer)
        {
            bmp = (Bitmap)Image.FromFile("..\\..\\data\\images\\missile.png");
            pictureBox = new PictureBox
            {
                Size = new Size(20, 20),
                Image = bmp,
                Location = new Point(calledPlayer.pb.Location.X + calledPlayer.pb.Width / 2, calledPlayer.pb.Location.Y + calledPlayer.pb.Height / 2)
            };
        }
        private void InitializePosition()
        {
            currentPosition = new PointF(pictureBox.Location.X, pictureBox.Location.Y);
        }

        public void Update(PlayerVehicle calledPlayer)
        {
            if (targetEnemy == null || targetEnemy.pictureBox == null)
                return;

            var targetPosition = new PointF(targetEnemy.pictureBox.Location.X, targetEnemy.pictureBox.Location.Y);
            var direction = new PointF(targetPosition.X - currentPosition.X, targetPosition.Y - currentPosition.Y);
            var distance = Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);

            if (distance <= speed)
            {
                currentPosition = targetPosition;
                //call damage
                targetEnemy.TakeDamage((int)damage);
                //remove this
                this.pictureBox.Dispose();
                calledPlayer.DeleteMissile(this);
            }
            else
            {
                var normalizedDirection = new PointF(direction.X / (float)distance, direction.Y / (float)distance);
                currentPosition.X += normalizedDirection.X * speed;
                currentPosition.Y += normalizedDirection.Y * speed;
            }

            //handle rotation of the image
            Bitmap rotatedBmp = RotateImage(bmp, direction);
            pictureBox.Image = rotatedBmp;
            //rotatedBmp.Dispose();
            //
            pictureBox.Location = new Point((int)currentPosition.X, (int)currentPosition.Y);
        }
    }
}
