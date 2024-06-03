namespace Yaprak_Kerem_12IT_2_8_Game
{
    partial class MVP
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
            this.pictureBoxPlayerModel = new System.Windows.Forms.PictureBox();
            this.gameTick = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayerModel)).BeginInit();
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
            // pictureBoxPlayerModel
            // 
            this.pictureBoxPlayerModel.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pictureBoxPlayerModel.Location = new System.Drawing.Point(975, 12);
            this.pictureBoxPlayerModel.Name = "pictureBoxPlayerModel";
            this.pictureBoxPlayerModel.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxPlayerModel.TabIndex = 1;
            this.pictureBoxPlayerModel.TabStop = false;
            this.pictureBoxPlayerModel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPlayerModel_MouseClick);
            this.pictureBoxPlayerModel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPlayerModel_MouseMove);
            // 
            // gameTick
            // 
            this.gameTick.Enabled = true;
            this.gameTick.Interval = 10;
            // 
            // MVP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1039, 561);
            this.Controls.Add(this.pictureBoxPlayerModel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MVP";
            this.Text = "Cold War game";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MVP_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayerModel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBoxPlayerModel;
        private System.Windows.Forms.Timer gameTick;
    }
}

