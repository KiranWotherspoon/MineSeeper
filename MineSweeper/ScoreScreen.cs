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

        List<Label> pointLabels = new List<Label>();
        List<Label> nameLabels = new List<Label>();

        public ScoreScreen()
        {
            InitializeComponent();
            Form1.scores = Form1.scores.OrderByDescending(x => x.points).ThenBy(y => y.name).ToList();

            pointLabels.Add(pointLabel1); pointLabels.Add(pointLabel2); pointLabels.Add(pointLabel3); pointLabels.Add(pointLabel4); pointLabels.Add(pointLabel5); pointLabels.Add(pointLabel6);
            nameLabels.Add(nameLabel1); nameLabels.Add(nameLabel2); nameLabels.Add(nameLabel3); nameLabels.Add(nameLabel4); nameLabels.Add(nameLabel5); nameLabels.Add(nameLabel6);
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

            for (int i = 0; i < pointLabels.Count(); i++)
            {
                pointLabels[i].Text = Form1.scores[i].points.ToString();
                nameLabels[i].Text = Form1.scores[i].name;
            }
        }
    }
}
