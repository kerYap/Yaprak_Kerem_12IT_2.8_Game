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
    /// <summary>
    /// class for the shop model
    /// </summary>
    public class PlayerModel
    {
        //variables for the model
        public uint index;
        public PictureBox pb;
        protected Rectangle bounds;
        protected Point loc;
        protected Size size;
        //

        //game data
        public uint cost;

        private bool placed = false;

        public PlayerModel(PictureBox modelPB, MouseEventHandler clickEventHandler, MouseEventHandler moveEventHandler)
        {
            //make a new picturebox
            pb = new PictureBox();
            //

            //set properties
            pb.Image = modelPB.Image;
            pb.Size = modelPB.Size;
            pb.Location = modelPB.Location;
            pb.SizeMode = modelPB.SizeMode;
            pb.BackColor = modelPB.BackColor;
            pb.BorderStyle = modelPB.BorderStyle;
            pb.Anchor = modelPB.Anchor;
            pb.Dock = modelPB.Dock;
            pb.Margin = modelPB.Margin;
            pb.Padding = modelPB.Padding;
            pb.Visible = modelPB.Visible;
            pb.Enabled = modelPB.Enabled;
            //

            //set various location data
            loc = modelPB.Location;
            size = modelPB.Size;
            bounds = new Rectangle(loc, size);
            //

            //add event handlers
            pb.MouseClick += clickEventHandler;
            pb.MouseMove += moveEventHandler;
        }

        /// <summary>
        /// checks if a point is in the bounds of the picturebox
        /// </summary>
        /// <param name="e">the point to check</param>
        /// <returns>whether the point e is within the bounds</returns>
        public bool CheckInBounds(Point e)
        {
            return bounds.Contains(e);
        }

        /// <summary>
        /// checks collision with a picturebox
        /// </summary>
        /// <param name="p">the picturebox to detect collision</param>
        /// <returns>boolean</returns>
        public bool CheckInBounds(PictureBox p)
        {
            return pb.Bounds.IntersectsWith(p.Bounds);
        }

        /// <summary>
        /// this updates the position of this instance of the picturebox
        /// </summary>
        /// <param name="e">mouse event args, used to find the location of the mouse</param>
        /// <param name="add">if the mouse moved on the picturebox then the location must be added rather than set. True will mean that the location of e will be added to the location. False is to set</param>
        public void UpdatePos(MouseEventArgs e, bool add)
        {
            //enable picturebox and make visible
            this.pb.Enabled = true;
            this.pb.Visible = true;
            //

            if (!add)    //if the mouse moves on the form, we set to the location of the mouse
            {
                //set the location to the location on the form
                this.loc = e.Location;

                //set the picturebox to the middle of the mouse
                this.loc.X -= 15;
                this.loc.Y -= 15;
                this.pb.Location = loc;
                //

                //dont do the addition style
                return;
            }

            //if the mouse moves on the picturebox, we offset the current location by the location on the picturebox
            this.loc.X += e.Location.X;
            this.loc.Y += e.Location.Y;
            //


            //set the picturebox to the middle of the mouse
            this.loc.X -= 15;
            this.loc.Y -= 15;
            //

            //set the location to the new location
            this.pb.Location = loc;
            //
        }

        public void EndPlacementSelection(MouseEventHandler click, MouseEventHandler move)
        {
            this.pb.MouseClick -= click;
            this.pb.MouseMove -= move;
            placed = true;
        }

        /// <summary>
        /// grid snapping for the player, done by rounding division of location and the grid size. Also checks if the points are placeable.
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