using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sobith_forma
{

    

    public partial class Form9 : Form
    {

        private readonly string connectionString =@"Data Source=C:\Users\ksobi\source\repos\Sobith forma\Sobith forma\bin\Debug\Mass.db;Version=3;";
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


        private void LoadIRCTCAccounts()
        {
            try
            {
                comboBox1.Items.Clear();

                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();

                    //string query = @"SELECT Username
                    //         FROM IRCTCAccounts
                    //         ORDER BY Username";

                    string query = "SELECT Username FROM IRCTCAccounts";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //comboBox1.Items.Add(reader["Username"].ToString());

                                comboBox1.Items.Add(reader.GetString(0));
                                //MessageBox.Show("Total User : " + comboBox1.Items.Count);
                            }
                        }
                    }
                }

                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void AddControl(Control ctrl)
        {
            // Button पर MouseDown मत लगाओ
            //if (!(ctrl is Button))
            //{
            //    ctrl.MouseDown += Form_MouseDown;
            //}

            if (!(ctrl is Button) &&
                   !(ctrl is ComboBox))
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
            LoadIRCTCAccounts();



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
            
            this.Close();
            
        }


        private void button2_Click(object sender, EventArgs e)
        {

            

            if (IsPair)
            {

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try {
            //    using (SQLiteConnection con = new SQLiteConnection(connectionString))
            //    {
            //        con.Open();
            //        string query = @"SELECT Password
            //                 FROM IRCTCAccounts
            //                 WHERE Username=@Username";
            //        using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            //        {

            //            cmd.Parameters.AddWithValue("@Username", comboBox1.Text);
            //            object result = cmd.ExecuteScalar();

            //        }
            //    }


            //}
            //catch (Exception ex)

            //{
            //    MessageBox.Show(ex.Message);
            //}


            
        }


        //private void LoadIRCTCAccounts()
        //{
        //    comboBox1.Items.Clear();

        //    using (SQLiteConnection con = new SQLiteConnection(connectionString))
        //    {
        //        con.Open();

        //        string query = "SELECT Username FROM IRCTCAccounts ORDER BY Username";

        //        using (SQLiteCommand cmd = new SQLiteCommand(query, con))
        //        using (SQLiteDataReader reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                comboBox1.Items.Add(reader["Username"].ToString());
        //            }
        //        }
        //    }

        //    if (comboBox1.Items.Count > 0)
        //        comboBox1.SelectedIndex = 0;
        //}
    }
}
