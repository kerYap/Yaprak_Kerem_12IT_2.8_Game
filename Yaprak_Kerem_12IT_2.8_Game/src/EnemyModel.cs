﻿using System;
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

        private Bitmap right;
        private Bitmap left;
        private Bitmap up;
        private Bitmap down;

        public EnemyModel(PictureBox modelPB, Grid gridManager, LevelBase level)
        {
            path = gridManager.Path;
            loc = modelPB.Location;
            this.currentTargetNode = path.First;
            InitializePictureBox(modelPB);
            InitializePosition();

            level.Controls.Add(PictureBox);
            right = new Bitmap(modelPB.Image);
            down = (Bitmap)right.Clone();
            down.RotateFlip(RotateFlipType.Rotate90FlipNone);
            left = (Bitmap)down.Clone();
            left.RotateFlip(RotateFlipType.Rotate90FlipNone);
            up = (Bitmap)left.Clone();
            up.RotateFlip(RotateFlipType.Rotate90FlipNone);

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

                //determine direction of movement
                if(currentTargetNode.Value.Item2 > currentTargetNode.Next.Value.Item2)
                {
                    PictureBox.Image = left;
                }
                else if(currentTargetNode.Value.Item2 < currentTargetNode.Next.Value.Item2)
                {
                    PictureBox.Image = right;
                }
                else if(currentTargetNode.Value.Item1 > currentTargetNode.Next.Value.Item1)
                {
                    PictureBox.Image = up;
                }
                else
                {
                    PictureBox.Image = down;
                }

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
    }
}
