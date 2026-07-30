using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sobith_forma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Application.Exit();

        }
        


       

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             
        }

        private void button1_Enter(object sender, EventArgs e)
        {


            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;

        }

        private void button1_Leave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
            button1.ForeColor = Color.White;
        }

        private void button2_Eenter(object sender, EventArgs e)
        {

            button2.BackColor = Color.White;
            button2.ForeColor = Color.Black;
        }

        private void button2_Leave(object sender, EventArgs e)
        {

            button2.BackColor = Color.Green;
            button2.ForeColor = Color.White;
        }

        private void Btn_submitCLik(object sender, EventArgs e)
        {
            lable4.Visible = true;
            lable4.Value = 0;
            Lodinglable.Text = "Loding";

            timer1.Start();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (lable4.Value < 100)
            {
                lable4.Value += 2;
                Lodinglable.Text = "Loading... " + lable4.Value + "%";
            }
            else
            {
                timer1.Stop();

                Lodinglable.Text = "✔ Completed";
                MessageBox.Show("Data Submitted Successfully!",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();




            }
        }

        private void lable4_Click(object sender, EventArgs e)
        {

        }
    }
}
