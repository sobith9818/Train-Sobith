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
        public partial class Form7 : Form
        {
        private string _trainName;
        private string totalfare;
        public Form7(

                 string trainNo,
        string journeyDate,
        string from,
        string to,
        string classType,
        string quota,
        string train_name,
         string fare

     )


            {
                InitializeComponent();

                label9.Text = trainNo;
                label10.Text = journeyDate;
                label11.Text = from;
                label12.Text = to;
                label13.Text = classType;
                label14.Text = quota;
                      _trainName = train_name;   // सीधे variable में store
            totalfare = fare;


        }
        
         
        




        private void Button1_Click(object sender, EventArgs e)
            {
                    this.DialogResult = DialogResult.Cancel;
           



            //f5.GetTrainData(


            //              label9.Text,   // Train Number
            //        label14.Text
            //        // Quota


            //    );
            this.DialogResult = DialogResult.OK;
                this.Close();
            }

            private void    label1_Click(object sender, EventArgs e)
            {

            }

            private void Form7_Load(object sender, EventArgs e)
            {

            }

            private void button3_Click(object sender, EventArgs e)
            {


                this.Close();
            }

            private void button2_Click(object sender, EventArgs e)
            {
            

            
          

                this.DialogResult = DialogResult.OK;


            //MessageBox.Show(this.Owner == null ? "Form6 NULL" : "Form6 OK");
            Form6 f6 = (Form6)this.Owner;
            //MessageBox.Show(f6.Owner == null ? "Form5 NULL" : "Form5 OK");
            Form5 f5 = (Form5)f6.Owner;

               


            f5.GetTrainData(


                          label9.Text,   // Train Number
                    label14.Text,
                    label11.Text,
                    label13.Text,
                    _trainName,
                    totalfare

                // Quota


                );
            //f5.Show();     // Form5 दिखाओ
            //f6.Close();    // Form6 बंद करो



            this.Close();
            }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }
