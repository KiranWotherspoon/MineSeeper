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
        Font titleFont = new Font("Arial", 24);
        SolidBrush drawBrush = new SolidBrush(Color.Red);

        public ScoreScreen()
        {
            InitializeComponent();
            Form1.scores.Sort();
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

        private void ScoreScreen_Paint(object sender, PaintEventArgs e)
        {
            Form1.DrawBorders(this.Height, this.Width, 20, e.Graphics);

            int count = Form1.scores.Count();
            for (int i = 1; i <= 6; i++)
            {
                e.Graphics.DrawString(Form1.scores[count - i], titleFont, drawBrush, 50, 50 * i);
            }
        }
    }
}
