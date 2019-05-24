using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
            Refresh();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (easyButton.Checked) { Form1.difficulty = "easy"; }
            else if (medButton.Checked) { Form1.difficulty = "medium"; }
            else { Form1.difficulty = "hard"; }
            
            GameScreen gs = new GameScreen();
            Form1.ChangeScreen(this, gs);
            
        }

        private void MenuScreen_Paint(object sender, PaintEventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void scoreButton_Click(object sender, EventArgs e)
        {

        }
    }
}
