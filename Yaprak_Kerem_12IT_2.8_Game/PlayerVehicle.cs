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

namespace Yaprak_Kerem_12IT_2_8_Game
{
    internal class PlayerVehicle : PlayerModel
    {
        public PlayerVehicle(PictureBox modelPB, MouseEventHandler click, MouseEventHandler move) : base(modelPB, click, move) 
        {
            enemiesToAttack = 3;
        }
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
            
        }
        private float DistanceBetweenPoints(Point point1, Point point2)
        {
            return (float)Math.Sqrt(
                (Math.Pow((double)(point1.X - point2.X), (double)2) 
                + Math.Pow((double)(point1.Y - point2.Y), (double)2)
                ));
        }
    }
}
