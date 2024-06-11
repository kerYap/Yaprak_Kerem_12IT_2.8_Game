using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yaprak_Kerem_12IT_2._8_Game;

namespace Yaprak_Kerem_12IT_2_8_Game
{
    public partial class LevelBase : Form
    {
        //grid manager
        Grid grid;
        //

        //list of players
        //need to do list for each type
        private List<PlayerModel> players = new List<PlayerModel>();
        private uint indexPlayers = 0;
        //

        //index of the current player that is being moved
        private uint playersIndex = 0;
        //

        //various constants for the grid
        const int GRID_WIDTH = 30;
        const int FORM_WIDTH_PLAYABLE_AREA = 900;
        const int FORM_HEIGHT_PLAYABLE_AREA = 600;
        //

        //game info
        private uint coins = 0;
        private uint numOfEnemies = 0;
        private uint difficulty = 0;
        //

        //for tracking
        bool trackMouse = false;
        //

        //player model picture boxes
        PictureBox playerModelAir;
        PictureBox playerModelVehicle;
        PictureBox playerModelGround;
        //

        public LevelBase(string map)
        {
            InitializeComponent();
            //make form non re-sizeable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            grid = new Grid(map);
        }

        //set tracking to true
        //need to make each one for each type of enemy
        private void pictureBoxPlayerModel_MouseClick(object sender, MouseEventArgs e)
        {
            if (trackMouse)
            {
                this.trackMouse = false;
                players[(int)playersIndex - 1].EndPlacementSelection(pictureBoxPlayerModel_MouseClick, pictureBoxPlayerModel_MouseMove);
            }
            else
            {
                playersIndex++;
                players.Add(new PlayerModel(pictureBoxPlayerModel,pictureBoxPlayerModel_MouseClick, pictureBoxPlayerModel_MouseMove));
                this.Controls.Add(players[(int)playersIndex - 1].pb);
                players[(int)playersIndex - 1].pb.Visible = true;
                players[(int)playersIndex - 1].pb.BringToFront();

                this.trackMouse = true;
            }
        }

        //do for the current type as well
        private void MVP_MouseMove(object sender, MouseEventArgs e)
        {
            if (trackMouse)
            {
                players[(int)playersIndex - 1].UpdatePos(e, false);
                players[(int)playersIndex - 1].SnapGrid(grid);
            }
        }

        private void pictureBoxPlayerModel_MouseMove(object sender, MouseEventArgs e)
        {
            if (trackMouse)
            {
                players[(int)playersIndex - 1].UpdatePos(e, true);
                players[(int)playersIndex - 1].SnapGrid(grid);
            }
        }
    }

}