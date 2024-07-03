namespace Yaprak_Kerem_12IT_TD_Game
{
    partial class LevelBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gameTick = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxGround = new System.Windows.Forms.PictureBox();
            this.pictureBoxVehicle = new System.Windows.Forms.PictureBox();
            this.pictureBoxAir = new System.Windows.Forms.PictureBox();
            this.labelPlayers = new System.Windows.Forms.Label();
            this.labelVehicle = new System.Windows.Forms.Label();
            this.labelAir = new System.Windows.Forms.Label();
            this.labelGround = new System.Windows.Forms.Label();
            this.labelEnemies = new System.Windows.Forms.Label();
            this.pictureBoxVehicleE = new System.Windows.Forms.PictureBox();
            this.labelVehicleE = new System.Windows.Forms.Label();
            this.pictureBoxAirE = new System.Windows.Forms.PictureBox();
            this.labelAirE = new System.Windows.Forms.Label();
            this.pictureBoxGroundE = new System.Windows.Forms.PictureBox();
            this.labelGroundE = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCoins = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelHealth = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGround)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVehicle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVehicleE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAirE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroundE)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(0, 0);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // gameTick
            // 
            this.gameTick.Interval = 10;
            this.gameTick.Tick += new System.EventHandler(this.Tick);
            // 
            // pictureBoxGround
            // 
            this.pictureBoxGround.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxGround.Location = new System.Drawing.Point(915, 123);
            this.pictureBoxGround.Name = "pictureBoxGround";
            this.pictureBoxGround.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxGround.TabIndex = 1;
            this.pictureBoxGround.TabStop = false;
            // 
            // pictureBoxVehicle
            // 
            this.pictureBoxVehicle.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxVehicle.Location = new System.Drawing.Point(915, 25);
            this.pictureBoxVehicle.Name = "pictureBoxVehicle";
            this.pictureBoxVehicle.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxVehicle.TabIndex = 2;
            this.pictureBoxVehicle.TabStop = false;
            // 
            // pictureBoxAir
            // 
            this.pictureBoxAir.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxAir.Location = new System.Drawing.Point(915, 74);
            this.pictureBoxAir.Name = "pictureBoxAir";
            this.pictureBoxAir.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxAir.TabIndex = 3;
            this.pictureBoxAir.TabStop = false;
            // 
            // labelPlayers
            // 
            this.labelPlayers.AutoSize = true;
            this.labelPlayers.Location = new System.Drawing.Point(912, 9);
            this.labelPlayers.Name = "labelPlayers";
            this.labelPlayers.Size = new System.Drawing.Size(44, 13);
            this.labelPlayers.TabIndex = 4;
            this.labelPlayers.Text = "Players:";
            // 
            // labelVehicle
            // 
            this.labelVehicle.AutoSize = true;
            this.labelVehicle.Location = new System.Drawing.Point(913, 58);
            this.labelVehicle.Name = "labelVehicle";
            this.labelVehicle.Size = new System.Drawing.Size(109, 13);
            this.labelVehicle.TabIndex = 5;
            this.labelVehicle.Text = "Vehicle: 2K 12, Cost: ";
            // 
            // labelAir
            // 
            this.labelAir.AutoSize = true;
            this.labelAir.Location = new System.Drawing.Point(912, 107);
            this.labelAir.Name = "labelAir";
            this.labelAir.Size = new System.Drawing.Size(86, 13);
            this.labelAir.TabIndex = 6;
            this.labelAir.Text = "Air: Mil-24, Cost: ";
            // 
            // labelGround
            // 
            this.labelGround.AutoSize = true;
            this.labelGround.Location = new System.Drawing.Point(912, 156);
            this.labelGround.Name = "labelGround";
            this.labelGround.Size = new System.Drawing.Size(122, 13);
            this.labelGround.TabIndex = 7;
            this.labelGround.Text = "Ground: Spetsnaz, Cost:";
            // 
            // labelEnemies
            // 
            this.labelEnemies.AutoSize = true;
            this.labelEnemies.Location = new System.Drawing.Point(912, 199);
            this.labelEnemies.Name = "labelEnemies";
            this.labelEnemies.Size = new System.Drawing.Size(50, 13);
            this.labelEnemies.TabIndex = 8;
            this.labelEnemies.Text = "Enemies:";
            // 
            // pictureBoxVehicleE
            // 
            this.pictureBoxVehicleE.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxVehicleE.Location = new System.Drawing.Point(915, 215);
            this.pictureBoxVehicleE.Name = "pictureBoxVehicleE";
            this.pictureBoxVehicleE.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxVehicleE.TabIndex = 9;
            this.pictureBoxVehicleE.TabStop = false;
            // 
            // labelVehicleE
            // 
            this.labelVehicleE.AutoSize = true;
            this.labelVehicleE.Location = new System.Drawing.Point(912, 248);
            this.labelVehicleE.Name = "labelVehicleE";
            this.labelVehicleE.Size = new System.Drawing.Size(106, 13);
            this.labelVehicleE.TabIndex = 10;
            this.labelVehicleE.Text = "Vehicle: M24 Chafee";
            // 
            // pictureBoxAirE
            // 
            this.pictureBoxAirE.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxAirE.Location = new System.Drawing.Point(915, 264);
            this.pictureBoxAirE.Name = "pictureBoxAirE";
            this.pictureBoxAirE.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxAirE.TabIndex = 11;
            this.pictureBoxAirE.TabStop = false;
            // 
            // labelAirE
            // 
            this.labelAirE.AutoSize = true;
            this.labelAirE.Location = new System.Drawing.Point(913, 297);
            this.labelAirE.Name = "labelAirE";
            this.labelAirE.Size = new System.Drawing.Size(104, 13);
            this.labelAirE.TabIndex = 12;
            this.labelAirE.Text = "Air: Lockheed XF-90";
            // 
            // pictureBoxGroundE
            // 
            this.pictureBoxGroundE.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxGroundE.Location = new System.Drawing.Point(915, 313);
            this.pictureBoxGroundE.Name = "pictureBoxGroundE";
            this.pictureBoxGroundE.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxGroundE.TabIndex = 13;
            this.pictureBoxGroundE.TabStop = false;
            // 
            // labelGroundE
            // 
            this.labelGroundE.AutoSize = true;
            this.labelGroundE.Location = new System.Drawing.Point(912, 346);
            this.labelGroundE.Name = "labelGroundE";
            this.labelGroundE.Size = new System.Drawing.Size(122, 13);
            this.labelGroundE.TabIndex = 14;
            this.labelGroundE.Text = "Gorund: Special Service";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Coins: ";
            // 
            // labelCoins
            // 
            this.labelCoins.AutoSize = true;
            this.labelCoins.Location = new System.Drawing.Point(45, 0);
            this.labelCoins.Name = "labelCoins";
            this.labelCoins.Size = new System.Drawing.Size(13, 13);
            this.labelCoins.TabIndex = 16;
            this.labelCoins.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(399, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Health: ";
            // 
            // labelHealth
            // 
            this.labelHealth.AutoSize = true;
            this.labelHealth.Location = new System.Drawing.Point(449, -1);
            this.labelHealth.Name = "labelHealth";
            this.labelHealth.Size = new System.Drawing.Size(13, 13);
            this.labelHealth.TabIndex = 18;
            this.labelHealth.Text = "0";
            // 
            // LevelBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1052, 593);
            this.Controls.Add(this.labelHealth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelCoins);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelGroundE);
            this.Controls.Add(this.pictureBoxGroundE);
            this.Controls.Add(this.labelAirE);
            this.Controls.Add(this.pictureBoxAirE);
            this.Controls.Add(this.labelVehicleE);
            this.Controls.Add(this.pictureBoxVehicleE);
            this.Controls.Add(this.labelEnemies);
            this.Controls.Add(this.labelGround);
            this.Controls.Add(this.labelAir);
            this.Controls.Add(this.labelVehicle);
            this.Controls.Add(this.labelPlayers);
            this.Controls.Add(this.pictureBoxAir);
            this.Controls.Add(this.pictureBoxVehicle);
            this.Controls.Add(this.pictureBoxGround);
            this.Controls.Add(this.pictureBox1);
            this.Name = "LevelBase";
            this.Text = "Cold War game";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MVP_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGround)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVehicle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVehicleE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAirE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroundE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer gameTick;
        private System.Windows.Forms.PictureBox pictureBoxGround;
        private System.Windows.Forms.PictureBox pictureBoxVehicle;
        private System.Windows.Forms.PictureBox pictureBoxAir;
        private System.Windows.Forms.Label labelPlayers;
        private System.Windows.Forms.Label labelVehicle;
        private System.Windows.Forms.Label labelAir;
        private System.Windows.Forms.Label labelGround;
        private System.Windows.Forms.Label labelEnemies;
        private System.Windows.Forms.PictureBox pictureBoxVehicleE;
        private System.Windows.Forms.Label labelVehicleE;
        private System.Windows.Forms.PictureBox pictureBoxAirE;
        private System.Windows.Forms.Label labelAirE;
        private System.Windows.Forms.PictureBox pictureBoxGroundE;
        private System.Windows.Forms.Label labelGroundE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCoins;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelHealth;
    }
}

