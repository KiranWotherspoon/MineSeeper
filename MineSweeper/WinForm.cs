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

        static List<string> letters = new List<string>(new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "V", "X", "Y", "Z" });

        static List<string> names = new List<string>();

        static int firstIndex = 0;

        static int secondIndex = 0;

        static int thirdIndex = 0;

        string name;

        int counter = 1;

        string letterOne = letters[firstIndex];
        string letterTwo = letters[secondIndex];
        string letterThree = letters[thirdIndex];

        public WinForm()
        {
            InitializeComponent();

            //change the information labels
            WinLabels();
            //set all the letters to A
            firstIndex = 0;
            secondIndex = 0;
            thirdIndex = 0;
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
            //put all the game information in the labels
            movesLabel.Text = "Moves taken: " + GameScreen.moves;
            timeLabel.Text = "Time Taken: " + GameScreen.gameTime;
            scoreLabel.Text = "Total score: " + GameScreen.score;
        }

        private void LabelFocus ()
        {
            //change the back colour of all labels to correctly show which one is selected
            letterLabelOne.BackColor = Color.DarkGray;
            letterLabelTwo.BackColor = Color.DarkGray;
            letterLabelThree.BackColor = Color.DarkGray;
            exitLabel.BackColor = Color.DarkGray;
            continueLabel.BackColor = Color.DarkGray;

            switch (counter)
            {
                case 1:
                    letterLabelOne.BackColor = Color.BlanchedAlmond;
                    break;
                case 2:
                    letterLabelTwo.BackColor = Color.BlanchedAlmond;
                    break;
                case 3:
                    letterLabelThree.BackColor = Color.BlanchedAlmond;
                    break;
                case 4:
                    continueLabel.BackColor = Color.BlanchedAlmond;
                    break;
                case 5:
                    exitLabel.BackColor = Color.BlanchedAlmond;
                    break;
                default:
                    break;
            }
        }

        private void WinForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //changes the label in focus, the letters for the name, exits out of the screen
            switch (e.KeyCode)
            {
                case Keys.Right:
                    counter++;
                    if (counter == 6) { counter = 1; }
                    LabelFocus();
                    break;
                case Keys.Left:
                    counter--;
                    if (counter == 0) { counter = 5; }
                    LabelFocus();
                    break;
                case Keys.Up:
                    switch (counter)
                    {
                        case 1:
                            firstIndex++;
                            if (firstIndex == 26) { firstIndex = 1; }
                            letterLabelOne.Text = letters[firstIndex];
                            letterLabelOne.Refresh();
                            break;
                        case 2:
                            secondIndex++;
                            if (secondIndex == 26) { secondIndex = 1; }
                            letterLabelTwo.Text = letters[secondIndex];
                            letterLabelTwo.Refresh();
                            break;
                        case 3:
                            thirdIndex++;
                            if (thirdIndex == 26) { thirdIndex = 1; }
                            letterLabelThree.Text = letters[thirdIndex];
                            letterLabelThree.Refresh();
                            break;
                    }
                    break;
                case Keys.Down:
                    switch (counter)
                    {
                        case 1:
                            firstIndex--;
                            if (firstIndex == -1) { firstIndex = 25; }
                            letterLabelOne.Text = letters[firstIndex];
                            letterLabelOne.Refresh();
                            break;
                        case 2:
                            secondIndex--;
                            if (secondIndex == -1) { secondIndex = 25; }
                            letterLabelTwo.Text = letters[secondIndex];
                            letterLabelTwo.Refresh();
                            break;
                        case 3:
                            thirdIndex--;
                            if (thirdIndex == -1) { thirdIndex = 25; }
                            letterLabelThree.Text = letters[thirdIndex];
                            letterLabelThree.Refresh();
                            break;
                    }
                    break;
                case Keys.Enter:
                    if (counter == 4)
                    {
                        name = letters[firstIndex] + letters[secondIndex] + letters[thirdIndex];

                        score s = new score(GameScreen.score, name);
                        Form1.scores.Add(s);

                        buttonResult = DialogResult.Cancel;
                        winForm.Close();
                    }
                    else if (counter == 5)
                    {
                        name = letters[firstIndex] + letters[secondIndex] + letters[thirdIndex];

                        score s = new score(GameScreen.score, name);
                        Form1.scores.Add(s);

                        buttonResult = DialogResult.Abort;
                        winForm.Close();
                    }
                    break;
            }
        }
    }
}
