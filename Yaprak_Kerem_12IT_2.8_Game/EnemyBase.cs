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
        protected uint movementSpeed;
        protected int horizontalMultiplier;
        protected int verticalMultiplier;
        public int health;

        public PictureBox pb;
        protected Rectangle bounds;
        protected Point loc;
        protected Size size;

        public EnemyModel(PictureBox modelPB)
        {
            pb = modelPB;
            loc = modelPB.Bounds.Location;
            size = modelPB.Size;
            bounds = new Rectangle(loc, size);
        }
    }
    //public class EnemyPlayerInGame : EnemyModel
}
