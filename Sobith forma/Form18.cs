using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sobith_forma
{
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {



            this.Close();
        }

        private void Form18_Load(object sender, EventArgs e)
        {


            panel2.Controls.Clear();
            UserControl6 uc = new UserControl6();
            //uc.Dock = DockStyle.Fill;

            panel2.Controls.Add(uc);

        }

        private void button2_Click(object sender, EventArgs e)
        {


            panel2.Controls.Clear();
            UserControl6 uc = new UserControl6();
            //uc.Dock = DockStyle.Fill;

            panel2.Controls.Add(uc);

        }

        private void button3_Click(object sender, EventArgs e)
        {


            panel2.Controls.Clear();
            RestorePage uc = new RestorePage();
            //uc.Dock = DockStyle.Fill;

            panel2.Controls.Add(uc);

        }

        private void button4_Click(object sender, EventArgs e)
        {

            panel2.Controls.Clear();
            Delete uc = new Delete();
            //uc.Dock = DockStyle.Fill;

            panel2.Controls.Add(uc);
        }
    }
}
