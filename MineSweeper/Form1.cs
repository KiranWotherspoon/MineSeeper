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

            //load scores on program start
            LoadScores();
        }

        //start with the menu screen on the form
        private void Form1_Load(object sender, EventArgs e)
        {
            MenuScreen ms = new MenuScreen();
            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);
            Form f = this.FindForm();
            f.Controls.Add(ms);
        }

        //changes the usercontrol on the form and centers it
        public static void ChangeScreen(UserControl current, string next)
        {
            Form f = ActiveForm.FindForm();
            f.Controls.Remove(current);
            UserControl ns = null;
            switch (next)
            {
                case "MenuScreen":
                    ns = new MenuScreen();
                    break;
                case "GameScreen":
                    ns = new GameScreen();
                    break;
                case "ScoreScreen":
                    ns = new ScoreScreen();
                    break;
                default:
                    break;
            }
            ns.Location = new Point((f.Width - ns.Width) / 2, (f.Height - ns.Height) / 2); 
            f.Controls.Add(ns);
            ns.Focus();
        }

        //function to draw borders of any screen
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

        //loads the score from an xml
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

        //saves the score to an xml
        public static void SaveScores()
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
