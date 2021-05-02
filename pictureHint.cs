using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jigsaw_Puzzle
{
    public partial class pictureHint : Form
    {
        public pictureHint()
        {
            InitializeComponent();
        }
        int Appearance_Time;
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.Close();
        }

        private void pictureHint_Load(object sender, EventArgs e)
        {
            Appearance_Time = 100;
            this.lblTimer.Text = "10";
            this.timer1.Start();
            this.pictureBox1.Image = Properties.Resources.puzzle_1;
            this.pictureBox2.Image = Properties.Resources.puzzle_1_hint;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Appearance_Time == 0) { 
                this.Close();
                this.timer1.Stop();
            }
            else
            {
                this.lblTimer.Text =  Appearance_Time+"";
                Appearance_Time--;
            }
        }
    }
}
