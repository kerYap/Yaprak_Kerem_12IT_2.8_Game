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
            this.pictureBoxAir = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAir)).BeginInit();
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
            this.gameTick.Enabled = true;
            this.gameTick.Interval = 10;
            this.gameTick.Tick += new System.EventHandler(this.Tick);
            // 
            // pictureBoxAir
            // 
            this.pictureBoxAir.BackColor = System.Drawing.SystemColors.MenuText;
            this.pictureBoxAir.Location = new System.Drawing.Point(997, 12);
            this.pictureBoxAir.Name = "pictureBoxAir";
            this.pictureBoxAir.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxAir.TabIndex = 1;
            this.pictureBoxAir.TabStop = false;
            // 
            // LevelBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1039, 593);
            this.Controls.Add(this.pictureBoxAir);
            this.Controls.Add(this.pictureBox1);
            this.Name = "LevelBase";
            this.Text = "Cold War game";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MVP_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer gameTick;
        private System.Windows.Forms.PictureBox pictureBoxAir;
    }
}

