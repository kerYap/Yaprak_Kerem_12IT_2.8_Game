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
        public PictureBox pb;
        public Rectangle bounds;
        public Point loc;
        public Size size;

        public EnemyModel(PictureBox modelPB, Grid gridManager)
        {
            path = gridManager.Path;
            this.currentTargetNode = path.First;
            pb = new PictureBox();
            InitializePictureBox(modelPB);
        }

        private void InitializePictureBox(PictureBox modelPictureBox)
        {
            PictureBox = new PictureBox
            {
                Size = modelPictureBox.Size,
                Image = modelPictureBox.Image,
                SizeMode = modelPictureBox.SizeMode,
                BackColor = modelPictureBox.BackColor,
                Location = loc
            };
        }

        private void InitializePosition()
        {
            if (currentTargetNode != null)
            {
                currentPosition = new PointF(currentTargetNode.Value.Item1 * 30, currentTargetNode.Value.Item2 * 30);
                PictureBox.Location = new Point((int)currentPosition.X, (int)currentPosition.Y);
            }
        }

        public virtual void Update(LevelBase level)
        {
            if(health >= 0)
            {
                this.pb.Dispose();
                this.damage = 0;
                level.RemoveEnemy(this, reward);
            }
            if (currentTargetNode != null && currentTargetNode.Next != null)
            { 
                PointF targetPosition = new PointF(currentTargetNode.Next.Value.Item1 * 30, currentTargetNode.Next.Value.Item2 * 30);
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
                pb.Location = loc;
            }
            else if (currentTargetNode == null)
            {
                level.TakeDamage(damage);
                this.pb.Dispose();
                level.RemoveEnemy(this, 0);
            }
        }
    }
}
