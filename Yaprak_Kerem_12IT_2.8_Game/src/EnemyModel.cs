using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yaprak_Kerem_12IT_TD_Game
{
    public class EnemyModel : IEnemy
    {
        //enemy information
        public uint damage;
        public float movementSpeed;
        public int health;
        public uint reward;

        public PictureBox PictureBox { get; private set; }
        private LinkedList<(int, int)> path;
        private LinkedListNode<(int, int)> currentTargetNode;
        private PointF currentPosition;
        public Point loc;
        public Size size;

        public EnemyModel(PictureBox modelPB, Grid gridManager, LevelBase level)
        {
            path = gridManager.Path;
            loc = modelPB.Location;
            this.currentTargetNode = path.First;
            InitializePictureBox(modelPB);
            InitializePosition();
            level.Controls.Add(PictureBox);
        }

        private void InitializePictureBox(PictureBox modelPictureBox)
        {
            PictureBox = new PictureBox
            {
                Image = modelPictureBox.Image,
                Size = modelPictureBox.Size,
                Location = modelPictureBox.Location,
                SizeMode = modelPictureBox.SizeMode,
                BackColor = modelPictureBox.BackColor,
                BorderStyle = modelPictureBox.BorderStyle,
                Anchor = modelPictureBox.Anchor,
                Dock = modelPictureBox.Dock,
                Margin = modelPictureBox.Margin,
                Padding = modelPictureBox.Padding,
                Visible = modelPictureBox.Visible,
                Enabled = modelPictureBox.Enabled
            };
        }

        private void InitializePosition()
        {
            if (currentTargetNode != null)
            {
                currentPosition = new PointF(currentTargetNode.Value.Item2 * 30, currentTargetNode.Value.Item1 * 30);
                PictureBox.Location = new Point((int)currentPosition.X, (int)currentPosition.Y);
            }
        }

        public virtual void Update(LevelBase level)
        {
            if(health <= 0)
            {
                this.PictureBox.Dispose();
                this.damage = 0;
                level.RemoveEnemy(this, reward);
                return;
            }
            if (currentTargetNode != null && currentTargetNode.Next != null)
            { 
                PointF targetPosition = new PointF(currentTargetNode.Next.Value.Item2 * 30, currentTargetNode.Next.Value.Item1 * 30);
                PointF directionOfTravel = new PointF(targetPosition.X - currentPosition.X, targetPosition.Y - currentPosition.Y);
                double distance = Math.Sqrt(directionOfTravel.X * directionOfTravel.X + directionOfTravel.Y * directionOfTravel.Y);
                if(distance <= movementSpeed)
                {
                    //move straight to target position
                    currentPosition = targetPosition;
                    currentTargetNode = currentTargetNode.Next;
                }
                else
                {
                    //move towards target
                    PointF newDirection = new PointF(directionOfTravel.X / (float)distance, directionOfTravel.Y / (float)distance);
                    currentPosition.X += newDirection.X * movementSpeed;
                    currentPosition.Y += newDirection.Y * movementSpeed;
                }
                //update picturebox
                loc = new Point((int)currentPosition.X, (int) currentPosition.Y);
                PictureBox.Location = loc;

                //rotate image
                Bitmap originalImg = new Bitmap(this.PictureBox.Image);
                Bitmap rotation = RotateImage(originalImg, targetPosition);
                PictureBox.Image = rotation;

            }
            else if (currentTargetNode == null)
            {
                level.TakeDamage(damage);
                this.PictureBox.Dispose();
                level.RemoveEnemy(this, 0);
            }
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }

        private Bitmap RotateImage(Bitmap bmp, PointF targetPosition)
        {
            float angle = (float)(Math.Atan2(targetPosition.Y - PictureBox.Location.Y, targetPosition.X - PictureBox.Location.X) * 180f / Math.PI);

            Bitmap rotatedBmp = new Bitmap(bmp.Width, bmp.Height);
            rotatedBmp.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

            Graphics g = Graphics.FromImage(rotatedBmp);
            g.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            g.RotateTransform(angle);

            g.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            g.DrawImage(bmp, new Point(0, 0));

            return rotatedBmp;
        }
    }
}
