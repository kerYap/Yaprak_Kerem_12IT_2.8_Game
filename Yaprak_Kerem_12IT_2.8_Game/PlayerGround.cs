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
    internal class PlayerGround : PlayerModel
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
