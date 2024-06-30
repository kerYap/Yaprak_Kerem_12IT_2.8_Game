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
        public Grid grid;
        //

        //list of waves
        public List<Wave> waves = new List<Wave>();

        //list of players
        public List<IPlayer> players = new List<IPlayer>();
        //

        //list of enemies
        public List<IEnemy> enemies = new List<IEnemy>();
        //

        //game info
        private int coins = 0;
        private int health = 0;
        //

        //for tracking
        bool trackMouse = false;
        //

        //player model picture boxes
        PictureBox playerModelAir;
        int playerCostAir;
        PictureBox playerModelVehicle;
        int playerCostVehicle;
        PictureBox playerModelGround;
        int playerCostGround;
        //

        //enemy model picture boxes
        public PictureBox enemyModelAir;
        public PictureBox enemyModelVehicle;
        public PictureBox enemyModelGround;
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
            InitializePicturebox(ref playerModelAir, pictureBoxAir,"..\\..\\data\\images\\PlayerAir.png", true);
            playerModelAir.MouseClick += AirModelMouseClick;
            playerModelAir.MouseMove += AirModelMouseMove;
            //
            InitializePicturebox(ref playerModelGround, pictureBoxGround,"..\\..\\data\\images\\PlayerGround.png", true);
            playerModelGround.MouseClick += GroundModelMouseClick;
            playerModelGround.MouseMove += GroundModelMouseMove;
            //
            InitializePicturebox(ref playerModelVehicle, pictureBoxVehicle,"..\\..\\data\\images\\PlayerVehicle.png", true);
            playerModelVehicle.MouseClick += VehicleModelMouseClick;
            playerModelVehicle.MouseMove += VehicleModelMouseMove;
            //

            //initialise enemy pictureboxes
            InitializePicturebox(ref enemyModelAir, pictureBoxAirE, "..\\..\\data\\images\\EnemyAir.png", true);
            InitializePicturebox(ref enemyModelGround, pictureBoxGroundE, "..\\..\\data\\images\\EnemyGround.png", true);
            InitializePicturebox(ref enemyModelVehicle, pictureBoxVehicleE, "..\\..\\data\\images\\EnemyVehicle.png", true);
            //make form non re-sizeable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            //set health
            health = levelHealth;

            grid = new Grid(map, this);
            if (tutorial) { StartTutorial(); }
            else { Level(); }
        }

        private void InitializePicturebox(ref PictureBox playerModel, PictureBox copy, string ImagePath, bool imageFile)
        {
            playerModel = copy;
            if(imageFile)playerModel.Image = Image.FromFile(ImagePath);
        }

        public void removePlayer(IPlayer p)
        {
            players.Remove(p);
        }


        /// <summary>
        /// if the player places a picturebox in the same grid location, this should be called to return the wasted coins
        /// </summary>
        /// <param name="money">the amount of coins to return</param>
        public void ReturnMoney(uint money)
        {
            coins += (int)money;
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
            this.coins = 300;
            this.Text += ": Korean War";
            this.Show();
            //this.BackgroundImage = Image.FromFile("..\\..\\data\\levels\\tutorialLevel\\backImage.png");
            playerCostVehicle = 100;
            labelVehicle.Text += playerCostVehicle.ToString();
            playerCostAir = 200;
            labelAir.Text += playerCostAir.ToString();
            playerCostGround = 50;
            labelGround.Text += playerCostGround.ToString();
            System.Threading.Thread.Sleep(1000);
            MessageBox.Show("Welcome to the battle general! We are here in Korea fighting the a proxy war against the americans, You must help hold off Incheon from american attack. This is a crucial peice of land in the war, dont fail!");
            waves.Add(new Wave(3, 0, 0, 0, this));
            MessageBox.Show("Here comes an enemy Lockheed XF-90, an early jet powered fighter. It is coming quick, you must place your 2K-12 surface to air missiles");
            waves.Add(new Wave(0, 0, 3, 0, this));
            MessageBox.Show("Here now comes some enemy special services to attack us, quick defend their attack with your Mil-24 Attack Helicopter.");
        }

        /// <summary>
        /// game update tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tick(object sender, EventArgs e)
        {
            //update wave
            waves[0].update(this);
            if (health <= 0)
            {
                this.gameTick.Stop();
                MessageBox.Show("Comrade! We lost!!!");
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
                foreach (var enemy in enemies.ToList())
                {
                    enemy.Update(this);
                }
            }
            //check for end of wave
            if (waves[0].waveComplete())
            {
                waves.RemoveAt(0);
            }
            //check for end of waves
            if(waves.Count() == 0)
            {
                //wfaoiehpawoieh
            }
            //sort out money
            labelCoins.Text = coins.ToString();
            //sort out health
            labelHealth.Text = health.ToString();
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
            coins += (int)r;
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
                //check for if there is enough money
                if(coins >= playerCostAir)
                {
                    players.Add(new PlayerAir(playerModelAir, AirModelMouseClick, AirModelMouseMove, this, playerCostAir));
                    Controls.Add(players[players.Count - 1].pb);
                    trackMouse = true;
                    coins -= playerCostAir;
                }
                else
                {
                    return;
                }
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
                if (coins >= playerCostGround)
                {
                    players.Add(new PlayerGround(playerModelGround, GroundModelMouseClick, GroundModelMouseMove, playerCostGround));
                    Controls.Add(players[players.Count - 1].pb);
                    trackMouse = true;
                    coins -= playerCostGround;
                }
                else
                {
                    return;
                }
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
                if (coins >= playerCostVehicle)
                {
                    players.Add(new PlayerVehicle(playerModelVehicle, VehicleModelMouseClick, VehicleModelMouseMove, this, playerCostVehicle));
                    Controls.Add(players[players.Count - 1].pb);
                    trackMouse = true;
                    coins -= playerCostVehicle;
                }
                else
                {
                    return;
                }
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