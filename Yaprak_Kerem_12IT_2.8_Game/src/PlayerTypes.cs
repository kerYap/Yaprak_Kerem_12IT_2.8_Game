using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Yaprak_Kerem_12IT_TD_Game
{
    public class PlayerAir : PlayerModel
    {
        private float rotationAngle;
        private float rotationSpeed;
        private int coneAngle;
        private int damagePerSecond;
        private PictureBox attackAreaPB;
        public PlayerAir(PictureBox modelPB, MouseEventHandler click, MouseEventHandler move, LevelBase l, int cost) : base(modelPB, click, move,cost)
        {
            damagePerSecond = 5;
            rotationSpeed = 2.2f;
            coneAngle = 35;
            attackRadius = 90;
            attackAreaPB = new PictureBox
            {
                Size = new Size((int)(attackRadius * 2), (int)(attackRadius * 2)),
                BackColor = Color.Transparent,
                Location = new Point((int)(loc.X - attackRadius), (int)(loc.Y - attackRadius)),
            };
            
            attackAreaPB.Paint += AttackAreaPB_Paint;
            this.attackSpeed = 0;
            l.Controls.Add(attackAreaPB);
            attackAreaPB.Enabled = false;
        }

        private void UpdateAttackAreaPosition()
        {
            attackAreaPB.Location = new Point(this.loc.X - (attackAreaPB.Width / 2) + (this.pb.Width / 2),
                                            this.loc.Y - (attackAreaPB.Height / 2) + (this.pb.Height / 2));
        }
        protected override void Dispose(Grid g)
        {
            base.Dispose(g);
            //delete the area picturebox
            attackAreaPB.Dispose();
        }
        public override void UpdatePos(MouseEventArgs e, bool add, Grid g, bool finalPlace)
        {
            this.pb.BringToFront();
            // Temporarily store the original location
            Point originalLoc = this.loc;
            Point newLoc;

            if (!add)    // If the mouse moves on the form, we set to the location of the mouse
            {
                // Set the location to the location on the form
                newLoc = e.Location;

                // Set the picturebox to the middle of the mouse
                newLoc.X -= this.pb.Width / 2;
                newLoc.Y -= this.pb.Height / 2;
            }
            else
            {
                newLoc = new Point();
                // If the mouse moves on the picturebox, we offset the current location by the location on the picturebox
                newLoc.X = this.loc.X + e.Location.X - this.pb.Width / 2;
                newLoc.Y = this.loc.Y + e.Location.Y - this.pb.Height / 2;
            }

            // Check if the new location results in an overlap
            if (!IsAttackAreaOverlapping(newLoc, g))
            {
                // If no overlap, update the position
                this.loc = newLoc;
                SnapGrid(g, finalPlace);
                this.pb.Location = loc;
                UpdateAttackAreaPosition();
            }
            else
            {
                // If overlap and final placement, show a message and reset
                if (finalPlace)
                {
                    // Reset to original position
                    this.loc = originalLoc;
                    SnapGrid(g, finalPlace);
                    this.pb.Location = loc;
                    UpdateAttackAreaPosition();
                }
            }
        }
        private bool IsAttackAreaOverlapping(Point potentialLocation, Grid g)
        {
            // Temporarily set the attack area to the new location to check for overlap
            Rectangle potentialAttackAreaBounds = new Rectangle(
                potentialLocation.X - (attackAreaPB.Width / 2) + (this.pb.Width / 2),
                potentialLocation.Y - (attackAreaPB.Height / 2) + (this.pb.Height / 2),
                attackAreaPB.Width,
                attackAreaPB.Height
            );

            foreach (var otherPlayer in g.thisLevel.players.OfType<PlayerAir>())
            {
                if (otherPlayer != this && potentialAttackAreaBounds.IntersectsWith(otherPlayer.attackAreaPB.Bounds))
                {
                    return true;
                }
            }
            return false;
        }
        public override void AttackTick(List<IEnemy> enemies)
        {
            rotationAngle += rotationSpeed;
            if (rotationAngle >= 360) rotationAngle -= 360;
            attackAreaPB.Invalidate();
            base.AttackTick(enemies);
        }
        protected override void Attack(List<IEnemy> enemies)
        {
            foreach(IEnemy enemy in enemies)
            {
                if(enemy is EnemyGround && IsWithinAttack(enemy))
                {
                    enemy.TakeDamage(damagePerSecond);
                }
            }
        }
        private void AttackAreaPB_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // draw cone
            //make brush
            Brush brush = new SolidBrush(Color.FromArgb(128, Color.Yellow));
            //make path
            GraphicsPath path = new GraphicsPath();
            //add line 1
            path.AddLine(attackAreaPB.Width / 2, attackAreaPB.Height / 2, (float)(attackAreaPB.Width / 2 + Math.Cos(Math.PI * (rotationAngle - coneAngle / 2) / 180) * attackAreaPB.Width / 2), (float)(attackAreaPB.Height / 2 + Math.Sin(Math.PI * (rotationAngle - coneAngle / 2) / 180) * attackAreaPB.Height / 2));
            //add the arc
            path.AddArc(new RectangleF(0, 0, attackAreaPB.Width, attackAreaPB.Height), rotationAngle - coneAngle / 2, coneAngle);
            //add last line
            path.AddLine(attackAreaPB.Width / 2, attackAreaPB.Height / 2, (float)(attackAreaPB.Width / 2 + Math.Cos(Math.PI * (rotationAngle + coneAngle / 2) / 180) * attackAreaPB.Width / 2), (float)(attackAreaPB.Height / 2 + Math.Sin(Math.PI * (rotationAngle + coneAngle / 2) / 180) * attackAreaPB.Height / 2));
            //draw path
            g.FillPath(brush, path);
            brush.Dispose();
            path.Dispose();
        }

        protected bool IsWithinAttack(IEnemy enemy)
        {
            Point enemyPos = enemy.pictureBox.Location;
            enemyPos.Offset(enemy.pictureBox.Width / 2, enemy.pictureBox.Height / 2);
            //if it is out of distance, it must be out of range
            float distance = DistanceBetweenPoints(pb.Location, enemyPos);
            if (distance > attackRadius) return false;

            //calculate if it is within the radius of the attack
            float angleToEnemy = CalcAngle(enemyPos);
            float angleDiff = Math.Abs(angleToEnemy - rotationAngle);
            if(angleDiff > 180)
            {
                //adjust wrap of angle
                angleDiff = 360 - angleDiff;
            }
            return angleDiff <= coneAngle / 2;
        }
        private float CalcAngle(Point pos)
        {
            Point thisPos = new Point(pb.Location.X + pb.Width / 2, pb.Location.Y + pb.Height / 2);
            float changeInX = pos.X - thisPos.X;
            float changeInY = pos.Y - thisPos.Y;
            return (float)(Math.Atan2(changeInY, changeInX) * (180 / Math.PI));
        }
    }
    public class PlayerVehicle : PlayerModel
    {
        private List<TrackingMissile> Missiles = new List<TrackingMissile>();
        public LevelBase lev;
        public PlayerVehicle(PictureBox modelPB, MouseEventHandler click, MouseEventHandler move, LevelBase l, int cost) : base(modelPB, click, move, cost)
        {
            TargetableEnemies = 3;
            damage = 100;
            attackRadius = 100;
            lev = l;
            attackSpeed = 100;
        }

        public override void AttackTick(List<IEnemy> enemies)
        {
            foreach (var missile in Missiles.ToList<TrackingMissile>())
            {
                missile.Update(this);
            }
            base.AttackTick(enemies);
        }

        /// <summary>
        /// this is the attack method, it handles creating new missiles and what enemies to target
        /// </summary>
        /// <param name="e">list of targetable enemies</param>
        protected override void Attack(List<IEnemy> e)
        {
            List<EnemyAir> enemiesToAttack = new List<EnemyAir>();
            //find nearest air enemies
            foreach (EnemyAir enemy in e.OfType<EnemyAir>())
            {
                if (enemiesToAttack.Count == 3) break;
                if (DistanceBetweenPoints(enemy.loc, new Point(this.loc.X + 15, this.loc.Y + 15)) <= attackRadius)
                {
                    enemiesToAttack.Add(enemy);
                }
            }
            //send missiles
            foreach (EnemyAir enemy in enemiesToAttack)
            {
                Missiles.Add(new TrackingMissile(enemy, this, damage, lev));
            }
        }

        /// <summary>
        /// deletes target missile from the list, so it stops updating
        /// </summary>
        /// <param name="target"></param>
        public void DeleteMissile(TrackingMissile target)
        {
            Missiles.Remove(target);
        }
    }
    public class PlayerGround : PlayerModel
    {
        public PlayerGround(PictureBox modelPB, MouseEventHandler click, MouseEventHandler move, int cost) : base(modelPB, click, move, cost)
        {
            attackRadius = 60;
            damage = 30;
            attackSpeed = 30;
        }
        protected override void Attack(List<IEnemy> enemies)
        {
            foreach(EnemyVehicle enemy in enemies.OfType<EnemyVehicle>())
            {
                Point enemyPosition = enemy.pictureBox.Location;
                float distance = DistanceBetweenPoints(pb.Location, enemyPosition);
                if(distance <= attackRadius)
                {
                    enemy.TakeDamage((int)damage);
                }
            }
        }
    }
}
