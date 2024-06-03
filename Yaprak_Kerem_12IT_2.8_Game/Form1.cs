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
    public partial class MVP : Form
    {
        //list of players
        private List<PlayerModel> players = new List<PlayerModel>();
        //index of the current player that is being moved
        private uint playersIndex = 0;
        //

        //various constants for the grid
        const int GRID_WIDTH = 30;
        const int FORM_WIDTH_PLAYABLE_AREA = 900;
        const int FORM_HEIGHT_PLAYABLE_AREA = 600;
        //
        
        private bool[,] placeablePoints = new bool[900 / 30, 600 /30];

        bool trackMouse = false;

        public MVP()
        {
            
            InitializeComponent();
            //make form non re-sizeable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            //make the basic map
            for(int c = 0; c < FORM_WIDTH_PLAYABLE_AREA / GRID_WIDTH; c++)
            {
                for(int js = 0; js < FORM_HEIGHT_PLAYABLE_AREA / GRID_WIDTH; js++)
                {
                    if(c == 10)
                    {
                        placeablePoints[c, js] = false;
                    }
                    else
                    {
                        placeablePoints[c, js] = true;
                    }
                }
            }
            //initialize player model
            
        }

        //set tracking to true
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

        private void MVP_MouseMove(object sender, MouseEventArgs e)
        {
            if (trackMouse)
            {
                players[(int)playersIndex - 1].UpdatePos(e, false);
                players[(int)playersIndex - 1].SnapGrid(placeablePoints);
            }
        }

        private void pictureBoxPlayerModel_MouseMove(object sender, MouseEventArgs e)
        {
            if (trackMouse)
            {
                players[(int)playersIndex - 1].UpdatePos(e, true);
                players[(int)playersIndex - 1].SnapGrid(placeablePoints);
            }
        }
    }

}