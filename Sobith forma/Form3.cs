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
    public partial class Form3 : Form
    {
        Form8 f8;
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private Form8 ikikfrm8;
        public Form3()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;

        }

        private void Form3_Load(object sender, EventArgs e)
        {

            Rectangle screen = Screen.PrimaryScreen.WorkingArea;

            this.Location = new Point(
               (screen.Width - this.Width) / 2,
                  screen.Height - this.Height - 10
                     );

            if (Properties.Settings.Default.StartDate == DateTime.MinValue)
            {
                Properties.Settings.Default.StartDate = DateTime.Today;
                Properties.Settings.Default.Save();
            }

            DateTime startDate = Properties.Settings.Default.StartDate;
            int daysUsed = (DateTime.Today - startDate).Days;
            int daysLeft = 30 - daysUsed;

            if (daysLeft > 0)
            {
                label6.Text = "Days Left : " + daysLeft;
            }
            else
            {
                label6.Text = "Trial Expired";
            }

        }

        private void Dorpe(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
 "Do you want to close Mass Software?",
 "Exit",
 MessageBoxButtons.YesNo,
 MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }




        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 fv = new Form4();
            fv.Show();  
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form5 f5 = new Form5();
            f5.Owner = this;
            f5.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //Form8 f8 = new Form8();
            //f8.Owner = this;
            //f8.Show();

            //if (f8 == null || f8.IsDisposed)
            //{
            //    f8 = new Form8();
            //    f8.Owner = this;
            //    f8.Show();
            //}
            //else
            //{
            //    f8.BringToFront();
            //}


            if (f8 == null || f8.IsDisposed)
            {
                f8 = new Form8();
                f8.Owner = this;
                f8.Show();

                f8.AddAllTickets();
            }
            else
            {
                f8.BringToFront();
                f8.AddAllTickets();
            }



            //Form8 f = new Form8();
            //f.Show();
            //f.AddAllTickets();


        }

        private void button5_Click(object sender, EventArgs e)
        {


            Form10 sh = new Form10();
             sh.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form15 sh = new Form15();
            sh.Show ();
        }

        private void button7_Click(object sender, EventArgs e)
        {
               Form16 sh= new Form16();
            sh.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form18 sh = new Form18();
            sh.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            WebLogine sh = new WebLogine();
            sh.Show();
        }
    }
}
