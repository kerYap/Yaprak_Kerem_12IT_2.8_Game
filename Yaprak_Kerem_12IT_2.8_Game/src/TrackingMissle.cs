﻿using System;
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
        public PictureBox PictureBox { get; private set; }
        private EnemyAir targetEnemy;
        private float speed;
        private PointF currentPosition;

        public TrackingMissile(EnemyAir targetEnemy)
        {
            this.targetEnemy = targetEnemy;

            InitializePictureBox();
            InitializePosition();
        }

        private void InitializePictureBox()
        {
            PictureBox = new PictureBox
            {
                
            };
        }

        private void InitializePosition()
        {
            currentPosition = new PointF(PictureBox.Location.X, PictureBox.Location.Y);
        }

        public void Update()
        {
            if (targetEnemy == null || targetEnemy.PictureBox == null)
                return;

            var targetPosition = new PointF(targetEnemy.PictureBox.Location.X, targetEnemy.PictureBox.Location.Y);
            var direction = new PointF(targetPosition.X - currentPosition.X, targetPosition.Y - currentPosition.Y);
            var distance = Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);

            if (distance <= speed)
            {
                currentPosition = targetPosition;
            }
            else
            {
                var normalizedDirection = new PointF(direction.X / (float)distance, direction.Y / (float)distance);
                currentPosition.X += normalizedDirection.X * speed;
                currentPosition.Y += normalizedDirection.Y * speed;
            }

            PictureBox.Location = new Point((int)currentPosition.X, (int)currentPosition.Y);
        }
    }
}
