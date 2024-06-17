using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yaprak_Kerem_12IT_TD_Game
{
    public class PlayerAir : PlayerModel
    {
        public PlayerAir(PictureBox modelPB, MouseEventHandler click, MouseEventHandler move) : base(modelPB, click, move)
        {
        }
    }
    public class PlayerVehicle : PlayerModel
    {
        List<TrackingMissile> Missiles;
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
            if (tickCount == null)
            {
                tickCount = 0;
            }
            tickCount++;
            if (tickCount >= attackSpeed && placed)
            {
                Attack();
                tickCount = 0;
            }
        }
        private void Attack()
        {
            //find nearest vehicle
            //attack vehicle
        }
    }
}
