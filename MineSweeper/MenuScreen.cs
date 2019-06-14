using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace MineSweeper
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
            playButton.Focus();
        }

        private void MenuScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw the border
            Form1.DrawBorders(this.Height, this.Width, 20, e.Graphics);

            //draw the images so the screen isnt blank
            e.Graphics.DrawImage(Properties.Resources.bombBlock, 50, 120, 60, 60);
            e.Graphics.DrawImage(Properties.Resources.flagBlock, 400, 230, 60, 60);
            e.Graphics.DrawImage(Properties.Resources.oneBlock, 385, 360, 60, 60);
            e.Graphics.DrawImage(Properties.Resources.twoBlock, 75, 420, 60, 60);
            e.Graphics.DrawImage(Properties.Resources.eightBlock, 70, 270, 60, 60);
            e.Graphics.DrawImage(Properties.Resources.falseBomb, 420, 30, 60, 60);
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            //when the player clicks play show a difficulty selection
            playButton.Visible = scoreButton.Visible = false;
            easyButton.Visible = mediumButton.Visible = hardButton.Visible = true;
            easyButton.Focus();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //if on the difficult selection go back to regular main menu
            if (easyButton.Visible)
            {
                playButton.Visible = scoreButton.Visible = true;
                easyButton.Visible = mediumButton.Visible = hardButton.Visible = false;
            }
            //exit the game
            else
            {
                Form1.SaveScores();
                Application.Exit();
            }
        }
        //change to the appropriate screen
        #region Change Screens
        private void scoreButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, "ScoreScreen");
        }

        private void easyButton_Click(object sender, EventArgs e)
        {
            Form1.difficulty = "easy";
            Form1.ChangeScreen(this, "GameScreen");
        }

        private void mediumButton_Click(object sender, EventArgs e)
        {
            Form1.difficulty = "medium";
            Form1.ChangeScreen(this, "GameScreen");
        }

        private void hardButton_Click(object sender, EventArgs e)
        {
            Form1.difficulty = "hard";
            Form1.ChangeScreen(this, "GameScreen");
        }
        #endregion

        //Changes the back colours of the buttons when hovered
        #region Change Backcolours
        private void easyButton_Enter(object sender, EventArgs e)
        {
            easyButton.BackColor = Color.Gray;
        }

        private void easyButton_Leave(object sender, EventArgs e)
        {
            easyButton.BackColor = Color.Gainsboro;
        }

        private void playButton_Enter(object sender, EventArgs e)
        {
            playButton.BackColor = Color.Gray;
        }

        private void playButton_Leave(object sender, EventArgs e)
        {
            playButton.BackColor = Color.Gainsboro;
        }

        private void mediumButton_Enter(object sender, EventArgs e)
        {
            mediumButton.BackColor = Color.Gray;
        }

        private void mediumButton_Leave(object sender, EventArgs e)
        {
            mediumButton.BackColor = Color.Gainsboro;
        }

        private void scoreButton_Enter(object sender, EventArgs e)
        {
            scoreButton.BackColor = Color.Gray;
        }

        private void scoreButton_Leave(object sender, EventArgs e)
        {
            scoreButton.BackColor = Color.Gainsboro;
        }

        private void hardButton_Enter(object sender, EventArgs e)
        {
            hardButton.BackColor = Color.Gray;
        }

        private void hardButton_Leave(object sender, EventArgs e)
        {
            hardButton.BackColor = Color.Gainsboro;
        }

        private void exitButton_Enter(object sender, EventArgs e)
        {
            exitButton.BackColor = Color.Gray;
        }

        private void exitButton_Leave(object sender, EventArgs e)
        {
            exitButton.BackColor = Color.Gainsboro;
        }
        #endregion
    }
}
