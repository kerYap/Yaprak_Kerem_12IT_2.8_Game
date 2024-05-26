﻿using System;
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
        const int GRID_WIDTH = 30;
        const int FORM_WIDTH_PLAYABLE_AREA = 900;
        const int FORM_HEIGHT_PLAYABLE_AREA = 600;

        private bool[,] placeablePoints = new bool[900 / 30, 600 /30];
        private MouseEventArgs mouseEventArgs;
        bool trackMouse = false;
        public MVP()
        {
            InitializeComponent();
            //make form non re-sizeable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            //make the basic map
            for(int i = 0; i < FORM_WIDTH_PLAYABLE_AREA / GRID_WIDTH; i++)
            {
                for(int j = 0; j < FORM_HEIGHT_PLAYABLE_AREA / GRID_WIDTH; j++)
                {
                    if(i == 10)
                    {
                        placeablePoints[i, j] = false;
                    }
                    else
                    {
                        placeablePoints[i, j] = true;
                    }
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
            PlayerInGame player = new PlayerInGame(pictureBoxPlayerModel);
            if (trackMouse)
            {
                player.UpdatePos(mouseEventArgs, placeablePoints);
            }
        }

        private void MVP_MouseMove(object sender, MouseEventArgs e)
        {
            mouseEventArgs = e;
        }

    }

}
