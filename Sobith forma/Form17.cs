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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            panel2.Controls.Clear();

            UserControl4 uc = new UserControl4();
            //uc.Dock = DockStyle.Fill;

            panel2.Controls.Add(uc);



        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form17_Load(object sender, EventArgs e)
        {

            panel2.Controls.Clear();
            UserControl4 uc = new UserControl4();
            //uc.Dock = DockStyle.Fill;

            panel2.Controls.Add(uc);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            UserControl5 uc = new UserControl5();
            //uc.Dock = DockStyle.Fill;

            panel2.Controls.Add(uc);
        }
    }
}
