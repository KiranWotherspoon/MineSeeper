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
        public static List<score> scores = new List<score>();

        public Form1()
        {
            InitializeComponent();
            MenuScreen ms = new MenuScreen();
            Form f = this.FindForm();
            f.Controls.Add(ms);

            LoadScores();
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

        public static void LoadScores()
        {
            XmlReader reader = XmlReader.Create("Resources/highScore.xml");

            while (reader.Read())
            {
                string points;
                string name;
                reader.ReadToFollowing("points");
                points = reader.ReadString();
                reader.ReadToFollowing("name");
                name = reader.ReadString();

                if (name != "")
                {
                    score s = new score(Convert.ToInt32(points), name);
                    scores.Add(s);
                }
            }

            reader.Close();
        }

        public static void SaveScores ()
        {
            XmlWriter writer = XmlWriter.Create("Resources/highScore.xml");

            writer.WriteStartElement("highscore");
            for (int i = 0; i < 6; i++)
            {
                writer.WriteStartElement("score");
                writer.WriteElementString("points", scores[i].points.ToString());
                writer.WriteElementString("name", scores[i].name.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Close();
        }
    }
}
