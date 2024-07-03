using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Yaprak_Kerem_12IT_TD_Game
{
    public partial class LevelBase : Form
    {
        //grid manager
        public Grid grid;
        //

        private int tickCount = 0;

        private bool waitTicks = false;

        private bool tutorialOrNot = false;

        //list of waves
        public List<Wave> waves = new List<Wave>();
        //

        //list of players
        public List<IPlayer> players = new List<IPlayer>();
        //

        //list of enemies
        public List<IEnemy> enemies = new List<IEnemy>();
        //

        private Form CalledForm;

        //game info
        private int coins = 0;
        private int health = 0;
        private int round = 0;
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
        public LevelBase(string map, bool tutorial, Form calledFrom)
        {
            InitializeComponent();
            //initialise picture box events
            InitializePicturebox(ref playerModelAir, pictureBoxAir, "..\\..\\data\\images\\PlayerAir.png", true);
            playerModelAir.MouseClick += AirModelMouseClick;
            playerModelAir.MouseMove += AirModelMouseMove;
            //
            InitializePicturebox(ref playerModelGround, pictureBoxGround, "..\\..\\data\\images\\PlayerGround.png", true);
            playerModelGround.MouseClick += GroundModelMouseClick;
            playerModelGround.MouseMove += GroundModelMouseMove;
            //
            InitializePicturebox(ref playerModelVehicle, pictureBoxVehicle, "..\\..\\data\\images\\PlayerVehicle.png", true);
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
            this.DoubleBuffered = true;

            CalledForm = calledFrom;

            playerCostVehicle = 100;
            labelVehicle.Text += playerCostVehicle.ToString();
            playerCostAir = 200;
            labelAir.Text += playerCostAir.ToString();
            playerCostGround = 50;
            labelGround.Text += playerCostGround.ToString();

            grid = new Grid(map, this);
            InitializeBackground(grid);
            if (tutorial) { StartTutorial(); tutorialOrNot = true; health = 1000; }
            else { Level(map); }
            gameTick.Enabled = true;
        }

        private void InitializePicturebox(ref PictureBox playerModel, PictureBox copy, string ImagePath, bool imageFile)
        {
            playerModel = copy;
            if (imageFile) playerModel.Image = Image.FromFile(ImagePath);
            playerModel.BackColor = Color.SaddleBrown;
        }

        public void removePlayer(IPlayer p)
        {
            players.Remove(p);
        }

        private void InitializeBackground(Grid g)
        {
            string backgroundImgPath = "..\\..\\data\\images\\background.png";
            string pathTileImgPath = "..\\..\\data\\images\\tile.png";

            BackgroundPathDrawer b = new BackgroundPathDrawer(backgroundImgPath, pathTileImgPath);

            b.DrawPathOnBackground(g.Path);
            this.BackgroundImage = b.GetFinalBackground();
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
        private void Level(string filePath)
        {
            this.Show();
            int coins;
            string text;
            waves = ReadWavesFromFile(filePath, out coins, out text, out health);
            this.coins = coins;
            this.Text += text;
        }

        /// <summary>
        /// handles running the tutorial
        /// </summary>
        private void StartTutorial()
        {
            if (round == 0)
            {
                this.coins = 300;
                this.Text += ": Korean War";
                this.Show();
                MessageBox.Show("Welcome to the battle general! We are here in Korea fighting the first proxy war against the Americans. You must help hold off Incheon from American attack. This is a crucial peice of land in the war, don't fail!");
                MessageBox.Show("Here comes an enemy Lockheed XF-90, an early jet powered fighter from America. It is coming quick, you must place your 2K-12 surface to air missiles. To place a unit, you have to click on it once, then move your mouse to the position that you want to drop it onto and then you should click again to place it. You can not place on the enemies path.");
                waves.Add(new Wave(3, 0, 0, 0, this));
            }
            else if (round == 1)
            {
                this.coins += 200;
                MessageBox.Show("Well done on defending us from that attack, now we have seen some American special service operators making their way to us. To defend Incheon from them you need to place your Mil-24 attack helicopter, the yellow cone shows its attack zone. As well as this, you must place them far enough apart so they do not crash");
                waves.Add(new Wave(0, 0, 2, 0, this));
            }
            else if (round == 2)
            {
                this.coins += 150;
                MessageBox.Show("Good Job! The enemies last resort are their tanks, we can see them rolling this way now. Place down your spetznaz toops to attack the tanks. However, just waringing you, spetznaz have to be quite close to do any damage to enemies.");
                waves.Add(new Wave(0, 2, 0, 0, this));
            }
            else if (round == 3)
            {
                this.coins += 500;
                MessageBox.Show("Here comes the last lot of enemies, there are a few of them be prepared!");
                waves.Add(new Wave(4, 5, 4, 0, this));
            }
            else
            {
                EndOfGame(true);
            }
        }

        /// <summary>
        /// game update tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tick(object sender, EventArgs e)
        {
            if (waitTicks)
            {
                tickCount++;
            }

            //update wave
            if (waitTicks && tickCount < 2000)
            {
                foreach (var PlayerAir in players.OfType<PlayerAir>())
                {
                    PlayerAir.AttackTick(enemies);//call this so that the attack cone still spins
                }
                return;
            }
            else if (waitTicks && tickCount >= 2000)
            {
                waitTicks = false;
            }
            if (waves.Count > 0)
            {
                waves[0].update(this);
            }
            if (health <= 0)
            {
                EndOfGame(false);
            }
            if (players.Count != 0)
            {
                this.SuspendLayout();
                foreach (var player in players)
                {
                    player.AttackTick(enemies);
                }
                this.ResumeLayout(true);
            }
            if (enemies.Count != 0)
            {
                this.SuspendLayout();
                foreach (var enemy in enemies.ToList())
                {
                    enemy.Update(this);
                }
                this.ResumeLayout(true);
            }
            //check for end of wave
            if (waves.Count > 0)
            {
                if (waves[0].waveComplete())
                {
                    waves.RemoveAt(0);
                    waitTicks = true;
                    if (health < 0)
                    {
                        EndOfGame(false);
                    }
                    if (tutorialOrNot && health > 0)
                    {
                        round++;
                        StartTutorial();
                    }
                }
            }
            //check for end of waves
            if (waves.Count() == 0)
            {
                if (!tutorialOrNot) EndOfGame(true);
            }
            //sort out money
            labelCoins.Text = coins.ToString();
            //sort out health
            labelHealth.Text = health.ToString();
        }
        private List<Wave> ReadWavesFromFile(string filePath, out int coins, out string text, out int health)
        {
            List<Wave> waves = new List<Wave>();
            string[] lines = File.ReadAllLines(filePath + "waves.txt");
            text = lines[0];
            coins = int.Parse(lines[1]);
            health = int.Parse(lines[2]);

            double? D = null, A = null, V = null, G = null;

            foreach (var line in lines)
            {
                var parts = line.Split(' ');
                if (parts.Length != 2) continue;

                var key = parts[0];
                if (double.TryParse(parts[1], out var value))
                {
                    switch (key)
                    {
                        case "D":
                            D = value;
                            break;
                        case "A":
                            A = value;
                            break;
                        case "V":
                            V = value;
                            break;
                        case "G":
                            G = value;
                            break;
                        case "W":
                            // When encountering a new wave number, create a new Wave object if all values are set
                            if (D.HasValue && A.HasValue && V.HasValue && G.HasValue)
                            {
                                waves.Add(new Wave((int)A.Value, (int)V.Value, (int)G.Value, (float)D.Value, this));
                            }

                            // Reset values for the next wave
                            D = A = V = G = null;
                            break;
                    }
                }
            }

            // Add the last wave if file ends without a new "W" entry
            if (D.HasValue && A.HasValue && V.HasValue && G.HasValue)
            {
                waves.Add(new Wave((int)A.Value, (int)V.Value, (int)G.Value, (float)D.Value, this));
            }

            return waves;
        }
        private void EndOfGame(bool win)
        {
            string message;
            string[] lines = File.ReadAllLines("..\\..\\data\\facts\\facts.txt");
            Random r = new Random();
            message = lines[r.Next(0, lines.Length)];
            this.gameTick.Stop();
            //show the fact in the messagebox
            if (win)
            {
                MessageBox.Show($"Well done, we held off their attack. Did you know? : {message}");
            }
            else { MessageBox.Show($"Comrade! We lost!!! Did you know? : {message}"); }
            //open the menu
            CalledForm.Show();
            //dispose this form
            this.Dispose();
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
        //Air Modelw
        private void AirModelMouseMove(object sender, MouseEventArgs e)
        {
            if (players.Count == 0) return;
            if (trackMouse == true) { players[players.Count() - 1].UpdatePos(e, true, grid, false); }
        }
        private void AirModelMouseClick(object sender, MouseEventArgs e)
        {
            if (!trackMouse)
            {
                //check for if there is enough money
                if (coins >= playerCostAir)
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