using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace Sobith_forma
{
    public partial class WebLogine : Form
    {
      
            public WebLogine()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void WebLogine_Load(object sender, EventArgs e)

        {
            MessageBox.Show(richTextBox1.GetType().Name);

            richTextBox1.Text =
 "Software Install hone ke Baaad Ek Baar IP Block Check Karna Jaroori Hai.\n" +
 "Achche Result ke liye Aapko Local System Istemal Karna hai. VPS PE IP Block ka issue jyada aata hai.\n" +
 "Booking se pahle aapko apna mobile ek baar Flight mode daalke wapas net Connect karna hai.\n" +
 "Agar broadband use kar rahe hain to router ko 2 minute ke liye band karke wapas chalu karna hai.";


          
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
