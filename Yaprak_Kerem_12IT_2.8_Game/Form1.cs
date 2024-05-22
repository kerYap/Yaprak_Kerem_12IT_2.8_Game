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
    public partial class MVP : Form
    {
        const int GRID_WIDTH = 30;
        const int FORM_WIDTH_PLAYABLE_AREA = 900;
        const int FORM_HEIGHT_PLAYABLE_AREA = 600;

        private MouseEventArgs mouseEventArgs;
        public List<Tuple<Point, bool>> grid = new List<Tuple<Point, bool>>();
        bool trackMouse = false;
        public MVP()
        {
            InitializeComponent();
            //make form non re-sizeable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            //calculate the grid points
            for(int i = 0; i < FORM_WIDTH_PLAYABLE_AREA / GRID_WIDTH; i++)
            {
                List<Tuple<int,int>> bufRow = new List<Tuple<int,int>>();
                for(int j = 0; j < FORM_HEIGHT_PLAYABLE_AREA / GRID_WIDTH; j++)
                {
                    bufRow.Add(new Tuple<int,int>(i,j));
                }
            }
            //initialize player model
            
        }

        //set tracking to true
        private void pictureBoxPlayerModel_MouseClick(object sender, MouseEventArgs e)
        {
                trackMouse = true;
        }

        private void timerUpdatePos_Tick(object sender, EventArgs e)
        {
            if (trackMouse)
            {
                PlayerInGame player = new PlayerInGame(pictureBoxPlayerModel);
                player.UpdatePos(mouseEventArgs);
            }
        }

        private void MVP_MouseMove(object sender, MouseEventArgs e)
        {
            mouseEventArgs = e;
        }

    }

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

        public void SnapGrid()
        {

        }
    }
}
