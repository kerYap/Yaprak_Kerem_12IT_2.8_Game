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

        public PlayerModel playerModel;

        const int GRID_WIDTH = 30;
        const int FORM_WIDTH_PLAYABLE_AREA = 900;
        const int FORM_HEIGHT_PLAYABLE_AREA = 600;

        private bool[,] placeablePoints = new bool[900 / 30, 600 /30];
        bool trackMouse = false;
        public MVP()
        {
            
            InitializeComponent();
            //make form non re-sizeable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            playerModel = new PlayerModel(new PictureBox());

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
            players.Add(new PlayerModel(pictureBoxPlayerModel));
            if (trackMouse)
            {
                trackMouse = false;
            }
            else
            {
                trackMouse = true;
            }
        }

        private void MVP_MouseMove(object sender, MouseEventArgs e)
        {
            if (trackMouse)
            {
                players[0].UpdatePos(e, false);
                players[0].SnapGrid(placeablePoints);
            }
        }

        private void pictureBoxPlayerModel_MouseMove(object sender, MouseEventArgs e)
        {
            if (trackMouse)
            {
                players[0].UpdatePos(e, true);
                players[0].SnapGrid(placeablePoints);
            }
        }
    }

}