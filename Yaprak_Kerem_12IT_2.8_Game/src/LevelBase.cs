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
        List<IPlayer> players;
        //

        //list of enemies
        List<IEnemy> enemies;
        //

        //various constants for the grid
        const int GRID_WIDTH = 30;
        const int FORM_WIDTH_PLAYABLE_AREA = 900;
        const int FORM_HEIGHT_PLAYABLE_AREA = 600;
        //

        //game info
        private uint coins = 0;
        private int health = 0;
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
            else { Level(); }
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
        /// runs the level based off of a file of waves and difficulty
        /// </summary>
        private void Level()
        {

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
            System.Threading.Thread.Sleep(2000);

        }

        /// <summary>
        /// game update tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tick(object sender, EventArgs e)
        {
            foreach(var player in players)
            {
                player.AttackTick(enemies);
            }
            foreach(var enemy in enemies)
            {
                enemy.Update(this);
            }
        }

        //enemy handling
        /// <summary>
        /// deletes the air enemy from the list
        /// </summary>
        /// <param name="e">enemy to remove</param>
        /// <param name="r">reward for killing enemy</param>
        public void RemoveEnemy(IEnemy e, uint r)
        {
            enemies.Remove(e);
            coins += r;
        }

        /// <summary>
        /// makes the form take damage
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(uint damage)
        {
            health -= (int)damage;
        }
        //

        //player movement handling
        private void PlayerModel_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void PlayerModel_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void MVP_MouseMove(object sender, MouseEventArgs e)
        {

        }
        //
    }
}