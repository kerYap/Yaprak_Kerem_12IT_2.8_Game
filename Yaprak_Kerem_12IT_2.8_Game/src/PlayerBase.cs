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

namespace Yaprak_Kerem_12IT_TD_Game
{
    public class PlayerModel : IPlayer
    {
        //variables for the model
        public uint index;
        public PictureBox pb {get; private set;}
        protected Rectangle bounds;
        protected Point loc;
        protected Size size;
        //

        //game data
        public uint cost;
        protected uint attackSpeed;
        protected uint? tickCount = null;
        protected bool placed = false;
        protected uint TargetableEnemies;
        protected float attackRadius;
        protected uint damage;
        //
        MouseEventHandler clickEvent;
        MouseEventHandler moveEvent;

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
            clickEvent = clickEventHandler;
            moveEvent = moveEventHandler;
            pb.MouseClick += clickEventHandler;
            pb.MouseMove += moveEventHandler;
        }

        /// <summary>
        /// this updates the position of this instance of the picturebox
        /// </summary>
        /// <param name="e">mouse event args, used to find the location of the mouse</param>
        /// <param name="add">if the mouse moved on the picturebox then the location must be added rather than set. True will mean that the location of e will be added to the location. False is to set</param>
        public virtual void UpdatePos(MouseEventArgs e, bool add, Grid g, bool finalPlace)
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

                //snap to grid
                SnapGrid(g, finalPlace);
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

            //snap to grid
            SnapGrid(g,finalPlace);
            //
        }

        /// <summary>
        /// removes the event handlers from the picture box, and checks if it has placed inside of another pictrebox 
        /// </summary>
        /// <param name="click">mouse event handler for the click</param>
        /// <param name="move">mose event handler for the movement</param>
        /// <param name="g">grid manager of the level</param>
        /// <param name="location">the location</param>
        protected void EndPlacementSelection(Grid g, (int, int) location)
        {
            this.pb.MouseClick -= clickEvent;
            this.pb.MouseMove -= moveEvent;
            placed = true;
            if (!g.CanPlace(location))
            {
                this.pb.Dispose();
                g.ReturnMoney(cost);
            }
        }

        /// <summary>
        /// grid snapping for the player, done by rounding division of location and the grid size. Also checks if the points are placeable.
        /// </summary>
        /// <param name="placeablePoints">this is a bool array of points where the player is placeable</param>
        protected void SnapGrid(Grid grid, bool endOfPlacement)
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
                if (!grid.CanPlace(((int)x, (int)y)))
                {
                    return;
                }
                Point buf = new Point(((int)x * 30), ((int)y * 30));
                this.loc = buf;
                this.pb.Location = loc;
            }
            if(endOfPlacement && x != null && y != null)
            {
                EndPlacementSelection(grid, ((int)x,(int)y));
            }
        }

        /// <summary>
        /// calculates distance between point using pythagoras
        /// </summary>
        /// <param name="point1">one point of comparison</param>
        /// <param name="point2">second point of comparison</param>
        /// <returns>float of the distance between the 2 points</returns>
        protected float DistanceBetweenPoints(Point point1, Point point2)
        {
            return (float)Math.Sqrt(
                (Math.Pow((double)(point1.X - point2.X), (double)2)
                + Math.Pow((double)(point1.Y - point2.Y), (double)2)
                ));
        }

        public virtual void AttackTick(List<IEnemy> enemies)
        {
            if (tickCount == null)
            {
                tickCount = 0;
            }
            tickCount++;
            if (tickCount >= attackSpeed && placed)
            {
                Attack(enemies);
                tickCount = 0;
            }
        }
        protected virtual void Attack(List<IEnemy> enemies) {}
    }
}