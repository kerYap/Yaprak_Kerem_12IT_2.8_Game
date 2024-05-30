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
        protected PictureBox pb;
        protected Rectangle bounds;
        protected Point loc;
        protected Size size;

        public PlayerModel(PictureBox modelPB)
        {
            pb = new PictureBox();
            size = modelPB.Size;
            bounds = new Rectangle(loc, size);
            pb.Location = loc;
            pb.Size = size;
            pb.Bounds = bounds;
            pb.Visible = false;
            pb.BackColor = modelPB.BackColor;
            pb.BindingContext = modelPB.BindingContext;
            pb.Enabled = false;
            
        }

        public bool CheckInBounds(Point e)
        {
            return bounds.Contains(e);
        }

        public void UpdatePos(MouseEventArgs e, bool add)
        {
            pb.Enabled = true;
            pb.Visible = true;
            if (!add)    //if the mouse moves on the form, we set to the location of the mouse
            {
                this.loc = e.Location;
                //set the picturebox to the middle of the mouse
                this.loc.X -= 15;
                this.loc.Y -= 15;

                this.pb.Location = loc;
                return;
            }
            this.loc.X += e.Location.X;
            this.loc.Y += e.Location.Y;

            //set teh picturebox to the middle of the mouse
            this.loc.X -= 15;
            this.loc.Y -= 15;

            this.pb.Location = loc;

        }

        /// <summary>
        /// grid snapping for the player
        /// </summary>
        /// <param name="placeablePoints">this is a bool array of points where the player is placeable</param>
        public void SnapGrid(bool[,] placeablePoints)
        {
            int? x = null;
            int? y = null;

            //find closest point index
            if (loc.Y <= 600 && loc.X <= 900)
            {
                x = (int?)Math.Round((double)loc.X / 30);
                y = (int?)Math.Round((double)loc.Y / 30);
            }

            //check if it is placeable
            if (x != null && y != null)
            {
                Point buf = new Point(((int)x * 30), ((int)y * 30));
                this.loc = buf;
                this.pb.Location = loc;
            }
        }
    }
}