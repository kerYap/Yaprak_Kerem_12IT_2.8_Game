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
    public class PlayerVehicle : PlayerModel
    {
        uint damage = 100;
        List<TrackingMissile> Missiles;
        public PlayerVehicle(PictureBox modelPB, MouseEventHandler click, MouseEventHandler move) : base(modelPB, click, move) 
        {
            enemiesToAttack = 3;
        }

        /// <summary>
        /// this is called everytick, manages when to attack
        /// </summary>
        /// <param name="enemies">this is a list of targetable enemies</param>
        public void AttackTick(List<EnemyAir> enemies)
        {
            if(tickCount == null)
            {
                tickCount = 0;
            }
            tickCount++;
            if(tickCount >= attackSpeed && placed)
            {
                Attack(enemies);
                tickCount = 0;
            }
        }

        /// <summary>
        /// this is the attack method, it handles creating new missiles and what enemies to target
        /// </summary>
        /// <param name="e">list of targetable enemies</param>
        private void Attack(List<EnemyAir> e)
        {
            List<EnemyAir> enemiesToAttack = new List<EnemyAir>();
            //find nearest air enemies
            foreach(EnemyAir enemy in e)
            {
                if (enemiesToAttack.Count == 3) break;
                if (DistanceBetweenPoints(enemy.loc, new Point(this.loc.X + 15, this.loc.Y + 15)) <= attackRadius)
                {
                    enemiesToAttack.Add(enemy);
                }
            }
            //send missiles
            foreach(EnemyAir enemy in enemiesToAttack)
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
}
