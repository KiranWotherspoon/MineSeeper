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
    public partial class Form1 : Form
    {
        public static string difficulty;

        public Form1()
        {
            InitializeComponent();
            MenuScreen ms = new MenuScreen();
            Form f = this.FindForm();
            f.Controls.Add(ms);
        }

        public static void ChangeScreen (UserControl uc, UserControl us)
        {
            Form f = ActiveForm.FindForm();
            f.Controls.Remove(uc);
            f.Controls.Add(us);
            us.Focus();
        }
    }
}
