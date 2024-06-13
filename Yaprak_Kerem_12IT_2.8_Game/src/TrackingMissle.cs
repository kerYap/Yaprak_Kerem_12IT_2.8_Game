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
    public class TrackingMissile
    {
        private PictureBox pb;
        private EnemyAir target;
        private uint speed;
        public TrackingMissile(EnemyAir targetEnemy)
        {
            target = targetEnemy;
            //set picturebox image
        }
        public void Move()
        {

        }
    }
}
