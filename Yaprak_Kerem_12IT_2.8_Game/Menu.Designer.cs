namespace Yaprak_Kerem_12IT_2_8_Game
{
    partial class Menu
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
            this.buttonRunTutorial = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonRunTutorial
            // 
            this.buttonRunTutorial.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRunTutorial.Location = new System.Drawing.Point(12, 12);
            this.buttonRunTutorial.Name = "buttonRunTutorial";
            this.buttonRunTutorial.Size = new System.Drawing.Size(281, 23);
            this.buttonRunTutorial.TabIndex = 0;
            this.buttonRunTutorial.Text = "&Start Tutorial";
            this.buttonRunTutorial.UseVisualStyleBackColor = true;
            this.buttonRunTutorial.Click += new System.EventHandler(this.buttonRunTutorial_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(281, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "&Level 1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 128);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonRunTutorial);
            this.Name = "Menu";
            this.Text = "Cold War TD : Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRunTutorial;
        private System.Windows.Forms.Button button1;
    }
}