using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yaprak_Kerem_12IT_TD_Game
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

        //enemy model picture boxes
        PictureBox enemyModelAir;
        PictureBox enemyModelVehicle;
        PictureBox enemyModelGround;
        //

        /// <summary>
        /// constructor for the level
        /// </summary>
        /// <param name="map">specifies the filepath of the .csv file</param>
        /// <param name="tutorial">specifies whether it is the tutorial or not, if it is not, it will read wave data from a file instead of running the tutorial</param>
        public LevelBase(string map, bool tutorial)
        {
            InitializeComponent();
            //make form non re-sizeable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            grid = new Grid(map, this);
            if (tutorial) { StartTutorial(); }
        }

        /// <summary>
        /// if the player places a picturebox in the same grid location, this should be called to return the wasted coins
        /// </summary>
        /// <param name="money">the amount of coins to return</param>
        public void ReturnMoney(uint money)
        {
            coins += money;
        }
        
        /// <summary>
        /// handles running the tutorial
        /// </summary>
        private void StartTutorial()
        {
            this.Name += "Korean War";
            System.Threading.Thread.Sleep(1000);
            MessageBox.Show("Welcome to the battle general! We are here in korea fighting the a proxy war against the americans, You must help hold off Incheon from american attack. This is a crucial peice of land in the war, dont fail!");
            System.Threading.Thread.Sleep(1000);
            MessageBox.Show("Here comes an enemy Lockheed XF-90, an early jet powered fighter jet. It is coming quick better place your anti-air missile to hold it off.");
        }

        //set tracking to true
        //need to make each one for each type of enemy
        private void pictureBoxPlayerModel_MouseClick(object sender, MouseEventArgs e)
        {
            if (trackMouse)
            {
                this.trackMouse = false;
                players[(int)playersIndex - 1].SnapGrid(pictureBoxPlayerModel_MouseClick, pictureBoxPlayerModel_MouseMove, grid, true);
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
                players[(int)playersIndex - 1].SnapGrid(pictureBoxPlayerModel_MouseClick, pictureBoxPlayerModel_MouseMove, grid, false);
            }
        }

        private void pictureBoxPlayerModel_MouseMove(object sender, MouseEventArgs e)
        {
            if (trackMouse)
            {
                players[(int)playersIndex - 1].UpdatePos(e, true);
                players[(int)playersIndex - 1].SnapGrid(pictureBoxPlayerModel_MouseClick, pictureBoxPlayerModel_MouseMove, grid, false);
            }
        }

        private void Tick(object sender, EventArgs e)
        {

        }
    }

}