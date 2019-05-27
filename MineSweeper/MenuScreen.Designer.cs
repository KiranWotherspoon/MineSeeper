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
            this.exitButton = new System.Windows.Forms.Button();
            this.scoreButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.easyButton = new System.Windows.Forms.Button();
            this.mediumButton = new System.Windows.Forms.Button();
            this.hardButton = new System.Windows.Forms.Button();
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
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Gainsboro;
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.exitButton.FlatAppearance.BorderSize = 5;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(188, 380);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(123, 64);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.Enter += new System.EventHandler(this.exitButton_Enter);
            this.exitButton.Leave += new System.EventHandler(this.exitButton_Leave);
            // 
            // scoreButton
            // 
            this.scoreButton.BackColor = System.Drawing.Color.Gainsboro;
            this.scoreButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.scoreButton.FlatAppearance.BorderSize = 5;
            this.scoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scoreButton.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreButton.Location = new System.Drawing.Point(188, 244);
            this.scoreButton.Name = "scoreButton";
            this.scoreButton.Size = new System.Drawing.Size(123, 64);
            this.scoreButton.TabIndex = 5;
            this.scoreButton.Text = "Highscores";
            this.scoreButton.UseVisualStyleBackColor = false;
            this.scoreButton.Click += new System.EventHandler(this.scoreButton_Click);
            this.scoreButton.Enter += new System.EventHandler(this.scoreButton_Enter);
            this.scoreButton.Leave += new System.EventHandler(this.scoreButton_Leave);
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.Gainsboro;
            this.playButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.playButton.FlatAppearance.BorderSize = 5;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.Location = new System.Drawing.Point(188, 120);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(123, 67);
            this.playButton.TabIndex = 1;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            this.playButton.Enter += new System.EventHandler(this.playButton_Enter);
            this.playButton.Leave += new System.EventHandler(this.playButton_Leave);
            // 
            // easyButton
            // 
            this.easyButton.BackColor = System.Drawing.Color.Gainsboro;
            this.easyButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.easyButton.FlatAppearance.BorderSize = 5;
            this.easyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.easyButton.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyButton.Location = new System.Drawing.Point(188, 120);
            this.easyButton.Name = "easyButton";
            this.easyButton.Size = new System.Drawing.Size(123, 67);
            this.easyButton.TabIndex = 14;
            this.easyButton.Text = "Beginner";
            this.easyButton.UseVisualStyleBackColor = false;
            this.easyButton.Visible = false;
            this.easyButton.Click += new System.EventHandler(this.easyButton_Click);
            this.easyButton.Enter += new System.EventHandler(this.easyButton_Enter);
            this.easyButton.Leave += new System.EventHandler(this.easyButton_Leave);
            // 
            // mediumButton
            // 
            this.mediumButton.BackColor = System.Drawing.Color.Gainsboro;
            this.mediumButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.mediumButton.FlatAppearance.BorderSize = 5;
            this.mediumButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mediumButton.Font = new System.Drawing.Font("Sitka Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mediumButton.Location = new System.Drawing.Point(188, 207);
            this.mediumButton.Name = "mediumButton";
            this.mediumButton.Size = new System.Drawing.Size(123, 64);
            this.mediumButton.TabIndex = 15;
            this.mediumButton.Text = "Intermediate";
            this.mediumButton.UseVisualStyleBackColor = false;
            this.mediumButton.Visible = false;
            this.mediumButton.Click += new System.EventHandler(this.mediumButton_Click);
            this.mediumButton.Enter += new System.EventHandler(this.mediumButton_Enter);
            this.mediumButton.Leave += new System.EventHandler(this.mediumButton_Leave);
            // 
            // hardButton
            // 
            this.hardButton.BackColor = System.Drawing.Color.Gainsboro;
            this.hardButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.hardButton.FlatAppearance.BorderSize = 5;
            this.hardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hardButton.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hardButton.Location = new System.Drawing.Point(188, 295);
            this.hardButton.Name = "hardButton";
            this.hardButton.Size = new System.Drawing.Size(123, 64);
            this.hardButton.TabIndex = 16;
            this.hardButton.Text = "Expert";
            this.hardButton.UseVisualStyleBackColor = false;
            this.hardButton.Visible = false;
            this.hardButton.Click += new System.EventHandler(this.hardButton_Click);
            this.hardButton.Enter += new System.EventHandler(this.hardButton_Enter);
            this.hardButton.Leave += new System.EventHandler(this.hardButton_Leave);
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.hardButton);
            this.Controls.Add(this.mediumButton);
            this.Controls.Add(this.easyButton);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button scoreButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button easyButton;
        private System.Windows.Forms.Button mediumButton;
        private System.Windows.Forms.Button hardButton;
    }
}
