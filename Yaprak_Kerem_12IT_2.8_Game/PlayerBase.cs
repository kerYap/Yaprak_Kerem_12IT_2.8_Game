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

    /// <summary>
    /// class for the in game player, inherited off of the shop model
    /// </summary>
    public class PlayerInGame : PlayerModel
    {
        public PlayerInGame(PictureBox modelPB) : base(modelPB)
        {
        }

        public void UpdatePos(MouseEventArgs e, bool[,] stuff)
        {
            this.loc = e.Location;
            this.pb.Location = loc;
            SnapGrid(stuff);
        }

        public void SnapGrid(bool[,] placeablePoints)
        {
            int? x = null;
            int? y = null;
            //find closest point index
            if(loc.Y <= 600 && loc.X <= 900)
            {
                x = (int)Math.Round((double)(loc.X / 30));
                y = (int)Math.Round((double)(loc.Y / 30));
            }
            //check if it is placeable
            if(x != null)
            {
                if (placeablePoints[(int)x,(int)y] == true)
                {
                    int locX = (int)x * 30;
                    int locY = (int)y * 30;
                    loc.X = locX;
                    loc.Y = locY;
                }
            }
        }
    }
}