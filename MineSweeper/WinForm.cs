using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class WinForm : Form
    {
        private static WinForm winForm;
        private static DialogResult buttonResult = new DialogResult();

        public WinForm()
        {
            InitializeComponent();
            WinLabels();
        }

        public static DialogResult Show()

        {
            winForm = new WinForm();
            winForm.ShowDialog();

            return buttonResult;
        }

        private static void ButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Text)
            {
                case "Continue":
                    buttonResult = DialogResult.Cancel;
                    break;
                case "Exit Game":
                    buttonResult = DialogResult.Abort;
                    break;
            }

            winForm.Close();

        }

        private void WinLabels ()
        {
            movesLabel.Text = "Moves taken: " + GameScreen.moves;
            timeLabel.Text = "Time Taken: " + GameScreen.gameTime;
            scoreLabel.Text = "Total score: " + GameScreen.score;
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            buttonResult = DialogResult.Cancel;
            winForm.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            buttonResult = DialogResult.Abort;
            winForm.Close();
        }


        private void continueButton_Enter(object sender, EventArgs e)
        {
            continueButton.BackColor = Color.DimGray;
        }

        private void continueButton_Leave_1(object sender, EventArgs e)
        {
            continueButton.BackColor = Color.Gainsboro;
        }

        private void exitButton_Enter_1(object sender, EventArgs e)
        {
            exitButton.BackColor = Color.DimGray;
        }

        private void exitButton_Leave_1(object sender, EventArgs e)
        {
            exitButton.BackColor = Color.Gainsboro;
        }
    }
}
