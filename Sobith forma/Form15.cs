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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


        private void Form15_Load(object sender, EventArgs e)
        {
            panel2.Controls.Clear();

            UserControl1 uc = new UserControl1();


            panel2.Controls.Add(uc);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();

            UserControl1 uc = new UserControl1();
            //uc.Dock = DockStyle.Fill;

            panel2.Controls.Add(uc);




        }

     

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();

            UserControl2 uc = new UserControl2();

            //uc.Dock = DockStyle.Fill;
            panel2.Controls.Add(uc);



        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();

            UserControl3 uc = new UserControl3();

            //uc.Dock = DockStyle.Fill;
            panel2.Controls.Add(uc);
        }
    }
}
