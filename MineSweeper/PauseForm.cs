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
    public partial class PauseForm : Form
    {
        private static PauseForm pauseForm;
        private static DialogResult buttonResult = new DialogResult();

        public PauseForm()
        {
            InitializeComponent();
        }

        public static DialogResult Show()

        {
            pauseForm = new PauseForm();
            pauseForm.ShowDialog();

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

            pauseForm.Close();

        }

        //changes back colour of the buttons
        #region Change Backcolours
        private void continueButton_Click(object sender, EventArgs e)
        {
            buttonResult = DialogResult.Cancel;
            pauseForm.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            buttonResult = DialogResult.Abort;
            pauseForm.Close();
        }

        private void continueButton_Enter(object sender, EventArgs e)
        {
            continueButton.BackColor = Color.DimGray;
        }

        private void continueButton_Leave(object sender, EventArgs e)
        {
            continueButton.BackColor = Color.Gainsboro;
        }

        private void exitButton_Enter(object sender, EventArgs e)
        {
            exitButton.BackColor = Color.DimGray;
        }

        private void exitButton_Leave(object sender, EventArgs e)
        {
            exitButton.BackColor = Color.Gainsboro;
        }
        #endregion
    }
}
