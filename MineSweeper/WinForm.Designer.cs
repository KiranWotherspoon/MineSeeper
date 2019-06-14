namespace MineSweeper
{
    partial class WinForm
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.movesLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.letterLabelOne = new System.Windows.Forms.Label();
            this.letterLabelTwo = new System.Windows.Forms.Label();
            this.letterLabelThree = new System.Windows.Forms.Label();
            this.continueLabel = new System.Windows.Forms.Label();
            this.exitLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Sitka Small", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(5, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(290, 50);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Nice Job!";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // movesLabel
            // 
            this.movesLabel.Font = new System.Drawing.Font("Sitka Small", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movesLabel.Location = new System.Drawing.Point(9, 59);
            this.movesLabel.Name = "movesLabel";
            this.movesLabel.Size = new System.Drawing.Size(286, 28);
            this.movesLabel.TabIndex = 1;
            this.movesLabel.Text = "label2";
            this.movesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeLabel
            // 
            this.timeLabel.Font = new System.Drawing.Font("Sitka Small", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(4, 107);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(291, 28);
            this.timeLabel.TabIndex = 2;
            this.timeLabel.Text = "label3";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scoreLabel
            // 
            this.scoreLabel.Font = new System.Drawing.Font("Sitka Small", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(6, 151);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(289, 28);
            this.scoreLabel.TabIndex = 3;
            this.scoreLabel.Text = "label4";
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // letterLabelOne
            // 
            this.letterLabelOne.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.letterLabelOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterLabelOne.Location = new System.Drawing.Point(50, 199);
            this.letterLabelOne.Name = "letterLabelOne";
            this.letterLabelOne.Size = new System.Drawing.Size(69, 75);
            this.letterLabelOne.TabIndex = 6;
            this.letterLabelOne.Text = "A";
            // 
            // letterLabelTwo
            // 
            this.letterLabelTwo.BackColor = System.Drawing.Color.DarkGray;
            this.letterLabelTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterLabelTwo.Location = new System.Drawing.Point(125, 199);
            this.letterLabelTwo.Name = "letterLabelTwo";
            this.letterLabelTwo.Size = new System.Drawing.Size(69, 75);
            this.letterLabelTwo.TabIndex = 7;
            this.letterLabelTwo.Text = "A";
            // 
            // letterLabelThree
            // 
            this.letterLabelThree.BackColor = System.Drawing.Color.DarkGray;
            this.letterLabelThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterLabelThree.Location = new System.Drawing.Point(200, 199);
            this.letterLabelThree.Name = "letterLabelThree";
            this.letterLabelThree.Size = new System.Drawing.Size(69, 75);
            this.letterLabelThree.TabIndex = 8;
            this.letterLabelThree.Text = "A";
            // 
            // continueLabel
            // 
            this.continueLabel.AutoSize = true;
            this.continueLabel.BackColor = System.Drawing.Color.DarkGray;
            this.continueLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.continueLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.continueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueLabel.Location = new System.Drawing.Point(12, 292);
            this.continueLabel.Name = "continueLabel";
            this.continueLabel.Size = new System.Drawing.Size(138, 35);
            this.continueLabel.TabIndex = 9;
            this.continueLabel.Text = "Go Again";
            // 
            // exitLabel
            // 
            this.exitLabel.AutoSize = true;
            this.exitLabel.BackColor = System.Drawing.Color.DarkGray;
            this.exitLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.exitLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitLabel.Location = new System.Drawing.Point(205, 292);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.Size = new System.Drawing.Size(66, 35);
            this.exitLabel.TabIndex = 10;
            this.exitLabel.Text = "Exit";
            // 
            // WinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(300, 340);
            this.Controls.Add(this.exitLabel);
            this.Controls.Add(this.continueLabel);
            this.Controls.Add(this.letterLabelThree);
            this.Controls.Add(this.letterLabelTwo);
            this.Controls.Add(this.letterLabelOne);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.movesLabel);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WinForm";
            this.Load += new System.EventHandler(this.WinForm_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.WinForm_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label movesLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label letterLabelOne;
        private System.Windows.Forms.Label letterLabelTwo;
        private System.Windows.Forms.Label letterLabelThree;
        private System.Windows.Forms.Label continueLabel;
        private System.Windows.Forms.Label exitLabel;
        public System.Windows.Forms.Label titleLabel;
    }
}