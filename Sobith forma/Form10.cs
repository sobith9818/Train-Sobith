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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

     

        private void button2_Click(object sender, EventArgs e)
        {
            Form11 showes= new Form11();
            showes.Show();
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
         

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form12 sh=new Form12();
            sh.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form13 sh=new Form13(); 
            sh.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form14 sh=new Form14(); 
            sh.Show();  
        }
    }
}
