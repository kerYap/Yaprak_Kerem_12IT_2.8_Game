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
        List<PlayerInGame> players = new List<PlayerInGame>();

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
            players.Add(new PlayerInGame(pictureBoxPlayerModel));
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
                players[0].UpdatePos(e);
                players[0].SnapGrid(placeablePoints);
            }
        }

    }

}