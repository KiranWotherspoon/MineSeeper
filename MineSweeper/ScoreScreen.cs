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
    public partial class ScoreScreen : UserControl
    {
        public ScoreScreen()
        {
            InitializeComponent();
            DrawScores();
        }

        private void ScoreScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    MenuScreen ms = new MenuScreen();
                    Form1.ChangeScreen(this, ms);
                    break;
            }
        }

        private void DrawScores ()
        {

        }

        private void ScoreScreen_Paint(object sender, PaintEventArgs e)
        {
            Form1.DrawBorders(this.Height, this.Width, 20, e.Graphics);
        }
    }
}
