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
    /// <summary>
    /// class for the shop model
    /// </summary>
    public class PlayerModel
    {
        public PictureBox pb;
        protected Rectangle bounds;
        protected Point loc;
        protected Size size;

        public PlayerModel(PictureBox modelPB)
        {
            pb = modelPB;
            loc = modelPB.Bounds.Location;
            size = modelPB.Size;
            bounds = new Rectangle(loc, size);
        }

        public bool CheckInBounds(Point e)
        {
            return bounds.Contains(e);
        }
    }

    /// <summary>
    /// class for the in game player, inherited off of the shop model
    /// </summary>
    public class PlayerInGame : PlayerModel
    {
        public PlayerInGame(PictureBox modelPB) : base(modelPB)
        {
            pb = new PictureBox();
        }

        public void UpdatePos(MouseEventArgs e)
        {
            loc = e.Location;
            pb.Location = loc;
        }

        public void SnapGrid(List<Tuple<Point, bool>> grid)
        {
            //find closest point

            //check if it is placeable
        }
    }
}