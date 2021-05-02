using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jigsaw_Puzzle
{
    public partial class frmTrophies : Form
    {
        public frmTrophies()
        {
            InitializeComponent();
        }

        private void frmTrophies_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            var TrophyQuery = from Trophy in context.Trophies
                              group Trophy by Trophy.DateTime;
            int i = 1;
            this.listBox1.Items.Add("#- \tDate/Time\t\tCompletion Time (Sec)");
            foreach (var trophy in TrophyQuery)
            {
                foreach (var t in trophy)
                {
                    this.listBox1.Items.Add(i+"- \t"+t.DateTime+"\t\t"+t.CompletionTime);
                    i++;
                }
            }
        }
    }
}
