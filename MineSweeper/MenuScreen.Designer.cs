namespace MineSweeper
{
    partial class MenuScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.hardButton = new System.Windows.Forms.RadioButton();
            this.medButton = new System.Windows.Forms.RadioButton();
            this.easyButton = new System.Windows.Forms.RadioButton();
            this.exitButton = new System.Windows.Forms.Button();
            this.scoreButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 55);
            this.label1.TabIndex = 13;
            this.label1.Text = "Minesweeper";
            // 
            // hardButton
            // 
            this.hardButton.AutoSize = true;
            this.hardButton.Location = new System.Drawing.Point(315, 200);
            this.hardButton.Name = "hardButton";
            this.hardButton.Size = new System.Drawing.Size(55, 17);
            this.hardButton.TabIndex = 12;
            this.hardButton.TabStop = true;
            this.hardButton.Text = "Expert";
            this.hardButton.UseVisualStyleBackColor = true;
            // 
            // medButton
            // 
            this.medButton.AutoSize = true;
            this.medButton.Location = new System.Drawing.Point(315, 176);
            this.medButton.Name = "medButton";
            this.medButton.Size = new System.Drawing.Size(83, 17);
            this.medButton.TabIndex = 11;
            this.medButton.TabStop = true;
            this.medButton.Text = "Intermediate";
            this.medButton.UseVisualStyleBackColor = true;
            // 
            // easyButton
            // 
            this.easyButton.AutoSize = true;
            this.easyButton.Checked = true;
            this.easyButton.Location = new System.Drawing.Point(315, 153);
            this.easyButton.Name = "easyButton";
            this.easyButton.Size = new System.Drawing.Size(67, 17);
            this.easyButton.TabIndex = 10;
            this.easyButton.TabStop = true;
            this.easyButton.Text = "Beginner";
            this.easyButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(181, 411);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(123, 64);
            this.exitButton.TabIndex = 9;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // scoreButton
            // 
            this.scoreButton.Location = new System.Drawing.Point(181, 283);
            this.scoreButton.Name = "scoreButton";
            this.scoreButton.Size = new System.Drawing.Size(123, 64);
            this.scoreButton.TabIndex = 8;
            this.scoreButton.Text = "Highscores";
            this.scoreButton.UseVisualStyleBackColor = true;
            this.scoreButton.Click += new System.EventHandler(this.scoreButton_Click);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(181, 150);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(123, 67);
            this.playButton.TabIndex = 7;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hardButton);
            this.Controls.Add(this.medButton);
            this.Controls.Add(this.easyButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.scoreButton);
            this.Controls.Add(this.playButton);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(510, 550);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MenuScreen_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton hardButton;
        private System.Windows.Forms.RadioButton medButton;
        private System.Windows.Forms.RadioButton easyButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button scoreButton;
        private System.Windows.Forms.Button playButton;
    }
}
