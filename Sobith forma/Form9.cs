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
    public partial class Form9 : Form
    {
        public string From;
        public string To;
        public string TrainNo;
        public string Quota;
        public string ClassType;
        public string Date;

        //private static Form9 pairForm;
        //public bool IsPair = false;
        // 👇 यहां लिखो
        private Form9 pairForm;
        public bool IsPair = false;


        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public Form9()

        {
           

            InitializeComponent();
            //this.MouseDown += mousedow;
            //AddControl(this);  
            // <-- सिर्फ यही Add किया है
            
            AddControl(this);

        }

        // ====== नया Method ======

        private void AddControl(Control ctrl)
        {
            // Button पर MouseDown मत लगाओ
            if (!(ctrl is Button))
            {
                ctrl.MouseDown += Form_MouseDown;
            }

            foreach (Control c in ctrl.Controls)
            {
                AddControl(c);
            }
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)  
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {

            label1.Text = From + "_" + To;
            label2.Text= From + "_" + To;
            label3.Text = TrainNo;
            label4.Text = ClassType;
            label5.Text = Quota;
            label6.Text = Date;



        }

       

        private void mousedow(object sender, MouseEventArgs e)
        {
            //ReleaseCapture();
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("show");
            this.Close();
            
        }


        private void button2_Click(object sender, EventArgs e)
        {

            MessageBox.Show("show they all pari");

            if (IsPair)
            {
                MessageBox.Show("Pair का Pair नहीं बन सकता।");
                return;
            }

            if (pairForm != null && !pairForm.IsDisposed)
            {
                pairForm.Activate();
                pairForm.BringToFront();
                return;
            }

            pairForm = new Form9();

            pairForm.IsPair = true;

            pairForm.From = this.From;
            pairForm.To = this.To;
            pairForm.TrainNo = this.TrainNo;
            pairForm.Quota = this.Quota;
            pairForm.ClassType = this.ClassType;
            pairForm.Date = this.Date;

            pairForm.StartPosition = FormStartPosition.Manual;
            pairForm.Location = new Point(this.Right + 10, this.Top);

            pairForm.FormClosed += (s, ev) =>
            {
                pairForm = null;
            };

            pairForm.Show();



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
