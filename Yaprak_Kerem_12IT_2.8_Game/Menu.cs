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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void buttonRunTutorial_Click(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("Hello comrade! You are the new millitary commander for the USSR, your job is to protect significant locations for the Red Army from the American scum. Good Luck commander!");
            Tutorial tutorial = new Tutorial("sus");
            tutorial.Show();

        }
    }
}
