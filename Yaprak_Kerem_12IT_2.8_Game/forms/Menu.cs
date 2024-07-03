using System;
using System.Windows.Forms;

namespace Yaprak_Kerem_12IT_TD_Game
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
            LevelBase tutorial = new LevelBase("..\\..\\data\\levels\\tutorialLevel\\", true, this);
            tutorial.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("Welcome to the Vietnamese war, please help us defend Haiphong from american attack");
            LevelBase viet = new LevelBase("..\\..\\data\\levels\\vietnamWar\\", false, this);
            viet.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("You have finally made it to the Soviet-Afghan War, this is the last of the 3 major proxy wars of the ");
            LevelBase afg = new LevelBase("..\\..\\data\\levels\\vietnamWar\\", false, this);
            afg.Show();
        }
    }
}
