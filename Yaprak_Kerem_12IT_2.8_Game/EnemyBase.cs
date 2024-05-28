using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yaprak_Kerem_12IT_2._8_Game
{
    public class EnemyModel
    {
        public PictureBox pb;
        protected Rectangle bounds;
        protected Point loc;
        protected Size size;

        public EnemyModel(PictureBox modelPB)
        {
            this.pb = modelPB;
            this.loc = modelPB.Bounds.Location;
            this.size = modelPB.Size;
            this.bounds = new Rectangle(loc, size);
        }

        public bool CheckInBounds(Point e)
        {
            return bounds.Contains(e);
        }
    }
    //public class EnemyPlayerInGame : EnemyModel
}
