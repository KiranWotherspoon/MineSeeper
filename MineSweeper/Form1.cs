using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MineSweeper
{
    public partial class Form1 : Form
    {
        public static string difficulty;
        public static List<score> highScore = new List<score>();

        public Form1()
        {
            InitializeComponent();
            MenuScreen ms = new MenuScreen();
            Form f = this.FindForm();
            f.Controls.Add(ms);
        }

        public static void ChangeScreen(UserControl uc, UserControl us)
        {
            Form f = ActiveForm.FindForm();
            f.Controls.Remove(uc);
            f.Controls.Add(us);
            us.Focus();
        }

        public static void DrawBorders(int height, int width, int border, Graphics g)
        {
            g.DrawImage(Properties.Resources.border, 0, 0, border, height);
            g.DrawImage(Properties.Resources.borderHorizontal, 0, 0, width, border);
            g.DrawImage(Properties.Resources.border, width - border, 0, border, height);
            g.DrawImage(Properties.Resources.borderHorizontal, 0, height - border, width, border);
            g.DrawImage(Properties.Resources.borderCornerTL, 0, 0, border, border);
            g.DrawImage(Properties.Resources.borderCornerTR, width - border, 0, border, border);
            g.DrawImage(Properties.Resources.borderCornerBR, width - border, height - border, border, border);
            g.DrawImage(Properties.Resources.borderCorner, 0, height - border, border, border);
        }

        public static void ReadScores()
        {
            XmlReader reader = XmlReader.Create(Properties.Resources.highScores);

            while (reader.Read())
            {
                score s = new score();

                reader.ReadToFollowing("score");
                s.points = Convert.ToInt16(reader.GetAttribute("point"));
                s.name = reader.GetAttribute("name");

                if (s.points != 0)
                {
                    highScore.Add(s);
                }
            }
        }

        public static void SaveScores ()
        {
            //highScores.Add();
            highScore.Sort();

            //XmlWriter writer = new XmlWriter(Properties.Resources.highScores);
        }
    }
}
