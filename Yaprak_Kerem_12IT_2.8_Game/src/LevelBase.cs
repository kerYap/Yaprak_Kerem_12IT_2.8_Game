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
        List<IPlayer> players = new List<IPlayer>();
        //

        //list of enemies
        List<IEnemy> enemies = new List<IEnemy>();
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
        public LevelBase(string map, bool tutorial, int levelHealth)
        {
            InitializeComponent();
            //initialise picture box events
            InitializePicturebox(ref playerModelAir, pictureBoxAir,"f");
            playerModelAir.MouseClick += AirModelMouseClick;
            playerModelAir.MouseMove += AirModelMouseMove;
            //
            InitializePicturebox(ref playerModelGround, pictureBoxGround,"f");
            playerModelGround.MouseClick += GroundModelMouseClick;
            playerModelGround.MouseMove += GroundModelMouseMove;
            //
            InitializePicturebox(ref playerModelVehicle, pictureBoxVehicle,"f");
            playerModelVehicle.MouseClick += VehicleModelMouseClick;
            playerModelVehicle.MouseMove += VehicleModelMouseMove;
            //
            
            //make form non re-sizeable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            //set health
            health = levelHealth;

            grid = new Grid(map, this);
            if (tutorial) { StartTutorial(); }
            else { Level(); }
        }

        private void InitializePicturebox(ref PictureBox playerModel, PictureBox copy, string ImagePath)
        {
            playerModel = copy;
            //playerModel.Image = Image.FromFile(ImagePath);
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
            this.Text += ": Korean War";
            System.Threading.Thread.Sleep(1000);
            MessageBox.Show("Welcome to the battle general! We are here in Korea fighting the a proxy war against the americans, You must help hold off Incheon from american attack. This is a crucial peice of land in the war, dont fail!");
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
            if (health <= 0)
            {
                this.gameTick.Stop();
                MessageBox.Show("Comrade! We lost!!! Incheon is now taken by the Americans!");
                this.Dispose();
            }
            if(players.Count != 0)
            {
                foreach (var player in players)
                {
                    player.AttackTick(enemies);
                }
            }
            if(enemies.Count != 0)
            {
                foreach (var enemy in enemies)
                {
                    enemy.Update(this);
                }
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

        //player movement
        //All
        private void MVP_MouseMove(object sender, MouseEventArgs e)
        {
            if (players.Count == 0) return;
            if (trackMouse == true)
            {
                players[players.Count() - 1].UpdatePos(e, false, grid, false);
            }
        }
        //Air Model
        private void AirModelMouseMove(object sender, MouseEventArgs e)
        {
            if(players.Count == 0) return;
            if (trackMouse == true) { players[players.Count() - 1].UpdatePos(e, true, grid, false);}
        }
        private void AirModelMouseClick(object sender, MouseEventArgs e)
        {
            if (!trackMouse)
            {
                players.Add(new PlayerAir(playerModelAir, AirModelMouseClick, AirModelMouseMove));
                Controls.Add(players[players.Count - 1].pb);
                trackMouse = true;
            }
            else
            {
                trackMouse = false;
                if (players.Count == 0) return;
                players[players.Count - 1].UpdatePos(e, true, grid, true);
            }
        }
        //Ground Model
        private void GroundModelMouseMove(object sender, MouseEventArgs e)
        {
            if (players.Count == 0) return;
            if (trackMouse == true) players[players.Count() - 1].UpdatePos(e, true, grid, false);
        }
        private void GroundModelMouseClick(object sender, MouseEventArgs e)
        {
            if (!trackMouse)
            {
                players.Add(new PlayerGround(playerModelGround, GroundModelMouseClick, GroundModelMouseMove));
                Controls.Add(players[players.Count - 1].pb);
                trackMouse = true;
            }
            else
            {
                trackMouse = false;
                if (players.Count == 0) return;
                players[players.Count - 1].UpdatePos(e, true, grid, true);
            }
        }
        //Vehicle Model
        private void VehicleModelMouseMove(object sender, MouseEventArgs e)
        {
            if (players.Count == 0) return;
            if (trackMouse == true) players[players.Count() - 1].UpdatePos(e, true, grid, false);
        }
        private void VehicleModelMouseClick(object sender, MouseEventArgs e)
        {
            if (!trackMouse)
            {
                players.Add(new PlayerVehicle(playerModelVehicle, VehicleModelMouseClick, VehicleModelMouseMove));
                Controls.Add(players[players.Count - 1].pb);
                trackMouse = true;
            }
            else
            {
                trackMouse = false;
                if (players.Count == 0) return;
                players[players.Count - 1].UpdatePos(e, true, grid, true);
            }
        }
        //
    }
}