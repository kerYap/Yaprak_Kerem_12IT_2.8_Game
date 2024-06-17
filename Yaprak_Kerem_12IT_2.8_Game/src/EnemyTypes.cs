using System;
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
    public class EnemyAir : EnemyModel
    {
        public EnemyAir(PictureBox pb, Grid g) : base(pb, g)
        {
            movementSpeed = 10;
        }
        public void takeDamage(int damage)
        {
            health -= damage;
        }

    }
    public class EnemyVehicle : EnemyModel
    {
        public EnemyVehicle(PictureBox pb, Grid g) : base(pb, g)
        {

        }
    }
    public class EnemyGround : EnemyModel
    {
        public EnemyGround(PictureBox pb, Grid g) : base(pb, g)
        {

        }
    }

   
}
