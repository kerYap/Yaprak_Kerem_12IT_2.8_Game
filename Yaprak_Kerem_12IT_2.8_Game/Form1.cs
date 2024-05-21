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
        public List<List<Tuple<int,int>>> grid = new List<List<Tuple<int,int>>>();
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

        private void MVP_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void timerUpdatePos_Tick(object sender, EventArgs e)
        {

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
            this.pb = modelPB;
            this.loc = pb.Bounds.Location;
            this.size = pb.Size;
            this.bounds = new Rectangle(loc, size);
        }

        bool CheckInBounds(MouseEventArgs e)
        {
            return this.bounds.Contains(e.Location);
        }
    }
    /// <summary>
    /// class for the in game player, inherited off of the shop model
    /// </summary>
    public class PlayerInGame : PlayerModel
    {
        public PlayerInGame(PictureBox modelPB, bool isTracking) : base(modelPB)
        {
            this.pb = new PictureBox();
        }
        public void UpdatePos(MouseEventArgs e)
        {
            this.loc = e.Location;
            this.pb
        }
    }
}
