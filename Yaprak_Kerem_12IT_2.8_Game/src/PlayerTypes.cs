using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
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
            damagePerSecond = 100;
            rotationSpeed = 3;
            coneAngle = 40;
            attackRadius = 50;
            attackAreaPB = new PictureBox
            {
                Size = new Size((int)(attackRadius * 2), (int)(attackRadius * 2)),
                BackColor = Color.Transparent,
                Location = new Point((int)(loc.X - attackRadius), (int)(loc.Y - attackRadius)),
            };
            
            attackAreaPB.Paint += AttackAreaPB_Paint;
            attackAreaPB.MouseMove += move;
            attackAreaPB.MouseClick += click;
            this.attackSpeed = 0;
            l.Controls.Add(attackAreaPB);
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

        public override void UpdatePos(MouseEventArgs e, bool add, Grid g, bool finalPlace)
        {
            attackAreaPB.SendToBack();
            pb.BringToFront();
            base.UpdatePos(e, add, g, finalPlace);

            //update attack area position
            attackAreaPB.Location = new Point(loc.X - attackAreaPB.Width / 2 + pb.Width / 2, loc.Y - attackAreaPB.Height / 2 + pb.Height / 2);
            attackAreaPB.Invalidate();
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

        protected bool IsWithinAttack(IEnemy enemy)
        {
            Point enemyPos = enemy.pictureBox.Location;
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
        LevelBase lev;
        public PlayerVehicle(PictureBox modelPB, MouseEventHandler click, MouseEventHandler move, LevelBase l, int cost) : base(modelPB, click, move, cost)
        {
            TargetableEnemies = 3;
            damage = 100;
            attackRadius = 100;
            lev = l;
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
