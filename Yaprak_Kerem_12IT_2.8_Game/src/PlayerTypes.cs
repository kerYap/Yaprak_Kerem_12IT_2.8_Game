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
        private float roationAngle;
        private float rotationSpeed;
        private int bulletSpeed;
        private int coneAngle;
        private int damagePerSecond;
        private PictureBox attackAreaPB;

        public PlayerAir(PictureBox modelPB, MouseEventHandler click, MouseEventHandler move) : base(modelPB, click, move)
        {
            attackAreaPB = new PictureBox
            {
                Size = new Size((int)(attackRadius * 2), (int)(attackRadius * 2)),
                BackColor = Color.Transparent,
                Location = new Point((int)(loc.X - attackRadius), (int)(loc.Y - attackRadius)),
            };
            attackAreaPB.Paint += AttackAreaPB_Paint;
        }
        private void AttackAreaPB_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // draw cone
            //make brush
            Brush brush = new SolidBrush(Color.FromArgb(128, Color.Yellow));
            //make path
            GraphicsPath path = new GraphicsPath();
            //calculate the points of the cone
            PointF startOfArc = new PointF(, )
        }
    }
    public class PlayerVehicle : PlayerModel
    {
        private List<TrackingMissile> Missiles = new List<TrackingMissile>();

        public PlayerVehicle(PictureBox modelPB, MouseEventHandler click, MouseEventHandler move) : base(modelPB, click, move)
        {
            TargetableEnemies = 3;
        }

        public override void AttackTick(List<IEnemy> enemies)
        {
            foreach (var missile in Missiles)
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
                Missiles.Add(new TrackingMissile(enemy, this, damage));
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
        public PlayerGround(PictureBox modelPB, MouseEventHandler click, MouseEventHandler move) : base(modelPB, click, move)
        {

        }
        public void AttackTick()
        {
        }
        private void Attack()
        {
            //find nearest vehicle
            //attack vehicle
        }
    }
}
