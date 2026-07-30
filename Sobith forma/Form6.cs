using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Windows.Forms;

namespace Sobith_forma
{
    public partial class Form6 : Form

    {

        private string fromStation;
        private string toStation;
        private string journeyDate;
        private string trainNo;
        private string from;
        private string to;
        private string classType;
        private string quota;
         private string fare;


        private string train_name ;
        


        public Form6(string value1, string value2, string value3)
        {
            InitializeComponent();
            fromStation = value1;
            toStation = value2;
            journeyDate = value3;

            //this.FormClosed += Form6;
            this.FormClosed += clsoeforem;



        }



        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void Form6_Load(object sender, EventArgs e)
        {
            CheckRadioButtons();

            try
            {
                // First API
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("x-api-key", "irctc_a19d79341c223002cb612b3498e70c26aff2ee1b8311c594");

                string url = $"https://railkit-api.rajivdubey.dev/api/searchTrainBetweenStations/{fromStation}/{toStation}?date={journeyDate}";

                string json = await client.GetStringAsync(url);
                

                ApiResponse result =
                    JsonConvert.DeserializeObject<ApiResponse>(json);
                
                dataGridView1.Rows.Clear();

                foreach (Train train in result.data) {

                    dataGridView1.Rows.Add(
                        train.train_no,
                        train.train_name,
                        train.from_stn_code,
                        train.from_time,
                        train.to_stn_code,
                        train.to_time,
                        train.distance,
                        train.duration,
                        "Y", "Y", "Y", "Y", "Y", "Y", "Y",
                        "1A", "2A", "3A", "X", "X", "SL", "X", "3E", "X", "X", "X"
                 



                );

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




















        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

            


        }

        private async void ApiCllevnts(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            //string classType = dataGridView1.Columns[e.ColumnIndex].HeaderText;


            //string classType =
            //    dataGridView1.Rows[e.RowIndex]
            //    .Cells[e.ColumnIndex].Value.ToString();

            classType =
                dataGridView1.Rows[e.RowIndex]
                .Cells[e.ColumnIndex].Value.ToString();

            if (classType == "X")
            {
                MessageBox.Show("Class Not Available");
                return;
            }

            // केवल Class Columns पर क्लिक होने पर
            if (classType == "1A" || classType == "2A" || classType == "3A" ||
                classType == "SL" || classType == "CC" || classType == "2S" ||
                classType == "3E" || classType == "EA" || classType == "EC" ||
                classType == "EV")
            {


            

            //string trainNo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //string from = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //string to = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            trainNo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                train_name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                from = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                to = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();





                //string quota = "GN";

                //if (radioButton1.Checked) quota = "TQ";
                //else if (radioButton2.Checked) quota = "PT";    
                //else if (radioButton3.Checked) quota = "GN";
                //else if (radioButton4.Checked) quota = "LD";


                quota = "GN";

                if (radioButton1.Checked) quota = "TQ";
                else if (radioButton2.Checked) quota = "PT";
                else if (radioButton3.Checked) quota = "GN";
                else if (radioButton4.Checked) quota = "LD";

                //MessageBox.Show(trainNo);
                //MessageBox.Show(from);
                //MessageBox.Show(to);


                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("x-api-key", "irctc_a19d79341c223002cb612b3498e70c26aff2ee1b8311c594");


                string url2 =
                    $"https://railkit-api.rajivdubey.dev/api/getAvailability/{trainNo}/{from}/{to}/{journeyDate}/{classType}/{quota}";
               ;

                      
                string json = await client.GetStringAsync(url2);

               
                AvailabilityResponse a =
                    JsonConvert.DeserializeObject<AvailabilityResponse>(json);

                //MessageBox.Show(a.data.availability[0].availabilityText);
                //MessageBox.Show(a.data.availability[0].rawStatus);
                button2.Visible = true;
                label5.Visible = true;
                //MessageBox.Show(a.data.fare.totalFare.ToString());
                    fare= a.data.fare.totalFare.ToString();
                label5.Text = fare;
                button2.Text = a.data.availability[0].rawStatus;




               


            }
        
        


    }   

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 fv7 = new Form7(



                            trainNo,
                journeyDate,
                from,
                to,
                classType,
                quota,
                train_name,
                fare


                );




            //fv7.Show();
            fv7.Owner = this;
            //fv7.ShowDialog();

            DialogResult result = fv7.ShowDialog();

            if (result == DialogResult.OK)
            {


        //           if (this.Owner != null)
        //{
        //    this.Owner.Show();
        //} 

        // Form6 बंद करो
        this.Close();
                //this.Close();


            }

            

            //if (fv7.ShowDialog() == DialogResult.OK)
            //{

            //    this.Close();


            //}
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }




        private void CheckRadioButtons()
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;

            TimeSpan showTime = new TimeSpan(1, 0, 0);    // 05:00 AM
            TimeSpan hideTime = new TimeSpan(11, 20, 0);  // 11:20 AM

            bool visible = currentTime >= showTime && currentTime <= hideTime;

            radioButton1.Visible = visible;
            radioButton2.Visible = visible;
        }

        private void clsoeforem(object sender, FormClosedEventArgs e)
        {

            this.Owner.Show();

        }
    }
}
