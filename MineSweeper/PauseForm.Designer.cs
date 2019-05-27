namespace MineSweeper
{
    partial class PauseForm
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
            this.continueButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // continueButton
            // 
            this.continueButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.continueButton.FlatAppearance.BorderSize = 5;
            this.continueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.continueButton.Font = new System.Drawing.Font("Sitka Small", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueButton.Location = new System.Drawing.Point(65, 53);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(151, 54);
            this.continueButton.TabIndex = 0;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            this.continueButton.Enter += new System.EventHandler(this.continueButton_Enter);
            this.continueButton.Leave += new System.EventHandler(this.continueButton_Leave);
            // 
            // exitButton
            // 
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.exitButton.FlatAppearance.BorderSize = 5;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Sitka Small", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(65, 151);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(151, 54);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // PauseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(275, 275);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.continueButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PauseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PauseForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Button exitButton;
    }
}