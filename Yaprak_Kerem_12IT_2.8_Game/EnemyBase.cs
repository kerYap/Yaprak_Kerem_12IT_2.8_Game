using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yaprak_Kerem_12IT_2_8_Game
{
    public class EnemyModel
    {
        //enemy information
        public uint damage;
        public uint movementSpeed;
        public int health;

        public PictureBox pb;
        public Rectangle bounds;
        public Point loc;
        public Size size;

        public EnemyModel(PictureBox modelPB)
        {
            pb = modelPB;
            loc = modelPB.Bounds.Location;
            size = modelPB.Size;
            bounds = new Rectangle(loc, size);
        }
        public void EnemyMove()
        {

        }
    }
}
