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
        const int FORM_WIDTH = 900;
        const int FORM_HEIGHT = 600;
        public List<List<int>> grid = new List<List<int>>();
        public MVP()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            for(int i = 0; i < FORM_WIDTH / GRID_WIDTH; i++)
            {
                for(int j = 0; j < FORM_HEIGHT / GRID_WIDTH; j++)
                {

                }
            }
            
        }

    }
}
