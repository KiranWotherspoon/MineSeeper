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
        public static List<string> scores = new List<string>();

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
            XmlReader reader = XmlReader.Create("Resources/Score.xml");

            while (reader.Read())
            {
                string s;
                reader.ReadToFollowing("points");
                s = reader.ReadString();

                if (s != null)
                {
                    scores.Add(s);
                }
            }

        }

        public static void SaveScores ()
        {
            scores.Sort();

            XmlWriter writer = XmlWriter.Create(Properties.Resources.Score);

            writer.WriteStartElement("highscores");

            int counter = 0;
            for (int i = scores.Count - 1; i >= 0; i--)
            {
                writer.WriteStartElement("score");
                writer.WriteElementString("points", scores[i]);
                writer.WriteEndElement();
                counter++;
                if (counter > 6) { break; }
            }

            writer.WriteEndElement();
        }
    }
}
