using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace Sobith_forma
{
    public partial class Form5 : Form
    {

        private readonly string connectionString = @"Data Source=C:\Users\ksobi\source\repos\Sobith forma\Sobith forma\bin\Debug\Mass.db;Version=3;";

        public int EditIndex = -1;
        string classType;
        Form5 f5;
        private List<Station> stations;

        public Form5()
        {
            InitializeComponent();


        }

        private void l_SelectedIndexChanged(object sender, EventArgs e)
        {
                   
        }

     

        private void press(object sender, KeyPressEventArgs e)
        {
            
        }

       

        private void Form5_Load(object sender, EventArgs e)

        {
           















            string json = File.ReadAllText("railwayStationsList.json");

            StationRoot root = JsonConvert.DeserializeObject<StationRoot>(json);

            stations = root.stations;

          




            listBox1.Visible = false;
            listBox2.Visible = false;
            comboBox1.Items.AddRange(new object[]
            {
        "Select Train Type",
    "Rajdhani-R",
    "Duranto-D",
    "Mail/Express-E",
    "Shatabdi-S",
    "GaribRath-Yuva-G",
    "TEJAS Express-T",
    "JANSHATABDI Express-J"
 });

            comboBox1.SelectedIndex = 0;








            comboBox2.Items.AddRange(new object[]
    {


        "Select Class",
    "First Class AC(1A)",
    "Executive Car(EC)",
    "First Class(FC)",
    "AC 2-tier(2A)",
    "AC 3-tier(3A)",
    "AC Chair Car(CC)",
    "Sleeper(SL)",
    "Second Sitting(2S)",
    "AC 3-tier eco(3E)",
    "Vistadome AC (EV)",
    "Anubhuti Class (EA)"


    });


            comboBox3.Items.AddRange(new object[] {
            
              "Slot-1",
              "Slot-2"
            
            
            
            });



            comboBox4.Items.AddRange(new object[] {

              "Netbanking/Wallet",
              "Credit/Debit Cards"



            });


            comboBox5.Items.AddRange(new object[] {
                    "ipay-QR_ipay@qr",
                    "PayTM-QR_paytm@qr"



            });






            comboBox2.SelectedIndex = 0;
            

            DataGridViewComboBoxColumn colSex =
         (DataGridViewComboBoxColumn)dataGridView1.Columns["colSex"];

            colSex.Items.Add("M");
            colSex.Items.Add("F");
            DataGridViewComboBoxColumn Berth =
       (DataGridViewComboBoxColumn)dataGridView1.Columns["Berth"];
            Berth.Items.Add("Choose Berth");

            dataGridView1.Rows.Add(6);

            for (int i = 0; i < 6; i++)
            {
               dataGridView1.Rows[i].Cells[0].Value = i + 1;
                dataGridView1.Rows[i].Cells["colSex"].Value = "M";
                dataGridView1.Rows[i].Cells["Berth"].Value = "Choose Berth";


            }



            try {

                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();

                    string query = @"
        CREATE TABLE IF NOT EXISTS Bookings
        (
            BookingId INTEGER PRIMARY KEY AUTOINCREMENT,

            FromStation TEXT NOT NULL,
            ToStation TEXT NOT NULL,

            JourneyDate TEXT NOT NULL,

            TrainNo TEXT NOT NULL,

            ClassType TEXT NOT NULL,

            Quota TEXT NOT NULL,

            Mobile TEXT NOT NULL DEFAULT '9000000000'
        );";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("this is ok");
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(
                    "Database Error\n\n" + ex.Message,
                    "SQLite Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);


            }


            

         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.RowCount = 6;

                for (int i = 0; i < 6; i++)
                {
                    dataGridView1.Rows[i].Cells["Column1"].Value = i + 1;
                }
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.RowCount = 4;

                for (int i = 0; i < 4; i++)
                {
                    dataGridView1.Rows[i].Cells["Column1"].Value = i + 1;
                }
            }
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.RowCount = 4;

                for (int i = 0; i < 4; i++)
                {
                    dataGridView1.Rows[i].Cells["Column1"].Value = i + 1;
                }
            }
        }

       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cellenterevent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 &&
       dataGridView1.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                dataGridView1.BeginEdit(true);

                if (dataGridView1.EditingControl is ComboBox cb)
                {
                    cb.DroppedDown = true;
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void ChangePaymentMethod()
        {
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
        }

        private void Clickallforma(object sender, EventArgs e)
        {
            ChangePaymentMethod();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (stations == null)
                return;
            listBox1.Items.Clear();
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {


                listBox1.Visible = false;
                return;
               
            }

            string search = textBox1.Text.Trim().ToUpper();
            var result = stations.Where(x =>
      x.stnCode.ToUpper().Contains(search) ||
      x.stnName.ToUpper().Contains(search));

            foreach (var item in result)
            {
                listBox1.Items.Add(item);
            }

            listBox1.Visible = listBox1.Items.Count > 0;






        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            if (stations == null)
                return;

            listBox2.Items.Clear();
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {


                listBox2.Visible = false;
                return;

            }

            string search = textBox3.Text.Trim().ToUpper();
            var result = stations.Where(x =>
      x.stnCode.ToUpper().Contains(search) ||
      x.stnName.ToUpper().Contains(search));

            foreach (var item in result)
            {
                listBox2.Items.Add(item);
            }

            listBox2.Visible = listBox2.Items.Count > 0;
        }

        private void clickText(object sender, EventArgs e)
        {
            ChangePaymentMethod();
        }

        private void Textboxclickseocnd(object sender, EventArgs e)
        {
            ChangePaymentMethod();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            // From Station Check
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please Select From Station.");
                textBox1.Focus();
                return;
            }

            // To Station Check
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please Select To Station.");
                textBox3.Focus();
                return;
            }

            // Same Station Check
            if (textBox1.Text.Trim().ToUpper() == textBox3.Text.Trim().ToUpper())
            {
                MessageBox.Show("From and To Station cannot be same.\nPlease Change Station.");
                textBox3.Focus();
                return;
            }






            //Form6 fv = new Form6(textBox1.Text.Trim(), textBox3.Text.Trim(), dateTimePicker1.Value.ToString("dd-MM-yyyy"));
            //fv.Show();

            Form6 f6 = new Form6(textBox1.Text.Trim(), textBox3.Text.Trim(), dateTimePicker1.Value.ToString("dd-MM-yyyy"));
            f6.Owner = this;
            this.Hide();
            f6.ShowDialog();
            //f6.Show();






        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem != null)
            {
                Station station = (Station)listBox1.SelectedItem;

                textBox1.Text = station.stnCode;
                listBox1.Visible = false;
            }
        }

        private void Entervalue(object sender, EventArgs e)
        {
            
        }

        private void secondclick(object sender, EventArgs e)
        {

        }



        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                Station station = (Station)listBox2.SelectedItem;

                textBox3.Text = station.stnCode;
                listBox2.Visible = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        


        public void GetTrainData(string trainNo, string quota ,string formes,string classType,string trainName,string totalfare)
        {
            //string trainName
            this.classType = classType;

          
  

              textBox6.Text = trainNo;
            textBox4.Text = formes;
            label12.Text = totalfare;
            // Quota
            dataGridView1.Rows.Clear();

            if (trainName.Contains("RAJDHANI"))
                comboBox1.SelectedItem = "Rajdhani-R";
            else if (trainName.Contains("DURONTO"))
                comboBox1.SelectedItem = "Duranto-D";
            else if (trainName.Contains("SHATABDI"))
                comboBox1.SelectedItem = "Shatabdi-S";
            else if (trainName.Contains("GARIB RATH"))
                comboBox1.SelectedItem = "GaribRath-Yuva-G";
            else if (trainName.Contains("TEJAS"))
                comboBox1.SelectedItem = "TEJAS Express-T";
            else if (trainName.Contains("JAN SHATABDI"))
                comboBox1.SelectedItem = "JANSHATABDI Express-J";
            else
                comboBox1.SelectedItem = "Mail/Express-E";





            if (classType == "1A")
                comboBox2.SelectedItem = "First Class AC(1A)";
            else if (classType == "2A")
                comboBox2.SelectedItem = "AC 2-tier(2A)";
            else if (classType == "3A")
                comboBox2.SelectedItem = "AC 3-tier(3A)";
            else if (classType == "SL")
                comboBox2.SelectedItem = "Sleeper(SL)";
            else if (classType == "CC")
                comboBox2.SelectedItem = "AC Chair Car(CC)";
            else if (classType == "2S")
                comboBox2.SelectedItem = "Second Sitting(2S)";
            else if (classType == "3E")
                comboBox2.SelectedItem = "AC 3-tier eco(3E)";
            else if (classType == "EA")
                comboBox2.SelectedItem = "Anubhuti Class (EA)";
            else if (classType == "EC")
                comboBox2.SelectedItem = "Executive Car(EC)";
            else if (classType == "EV")
                comboBox2.SelectedItem = "Vistadome AC (EV)";
            else if (classType == "FC")
                comboBox2.SelectedItem = "First Class(FC)";






            // GN = 6 Passenger
            if (quota == "GN")
            {
                dataGridView1.RowCount = 6;

                for (int i = 0; i < 6; i++)
                {
                    dataGridView1.Rows[i].Cells["Column1"].Value = i + 1;
                    dataGridView1.Rows[i].Cells["colSex"].Value = "M";
                    dataGridView1.Rows[i].Cells["Berth"].Value = "Choose Berth";
                }
            }

            // TQ या PT = 4 Passenger
            else if (quota == "TQ" || quota == "PT")
            {
                dataGridView1.RowCount = 4;

                for (int i = 0; i < 4; i++)
                {
                    dataGridView1.Rows[i].Cells["Column1"].Value = i + 1;
                    dataGridView1.Rows[i].Cells["colSex"].Value = "M";
                    dataGridView1.Rows[i].Cells["Berth"].Value = "Choose Berth";
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {






            string msg = "";

            // From
            if (string.IsNullOrWhiteSpace(textBox1.Text))
                msg += "Please Select From Station\n";

            // To
            if (string.IsNullOrWhiteSpace(textBox3.Text))
                msg += "Please Select To Station\n";

            // Same Station
            if (textBox1.Text.Trim().ToUpper() == textBox3.Text.Trim().ToUpper())
                msg += "From And To Station Cannot Be Same\n";

            // Train
            if (string.IsNullOrWhiteSpace(textBox6.Text))
                msg += "Please Find Train\n";

            // Passenger Check
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];

                // अगर पूरी Row खाली है तो आगे मत Check करो
                if (row.Cells["Column2"].Value == null &&
                    row.Cells["Column3"].Value == null)
                    break;

                // Name
                if (row.Cells["Column2"].Value == null ||
                    string.IsNullOrWhiteSpace(row.Cells["Column2"].Value.ToString()))
                {
                    msg += "Passenger Name Missing (Row " + (i + 1) + ")\n";
                }

                // Age
                if (row.Cells["Column3"].Value == null ||
                    string.IsNullOrWhiteSpace(row.Cells["Column3"].Value.ToString()))
                {
                    msg += "Passenger Age Missing (Row " + (i + 1) + ")\n";
                }

                // Sex
                if (row.Cells["colSex"].Value == null ||
                    string.IsNullOrWhiteSpace(row.Cells["colSex"].Value.ToString()))
                {
                    msg += "Passenger Sex Missing (Row " + (i + 1) + ")\n";
                }
            }

            // अगर कोई भी Error है
            if (msg != "")
            {
                MessageBox.Show(msg, "Validation");
                return;
            }






            string quota = "";

            if (radioButton1.Checked)
                quota = "GN";
            else if (radioButton2.Checked)
                quota = "LD";
            else if (radioButton3.Checked)
                quota = "TQ";
            else if (radioButton4.Checked)
                quota = "PT";

            // Data Save
            //DataStore.numercount = "1";
            //DataStore.passdelsts = textBox8.Text;
            //DataStore.From = textBox1.Text;
            //DataStore.To = textBox3.Text;
            //DataStore.Date = dateTimePicker1.Text;
            //DataStore.TrainNo = textBox6.Text;
            //DataStore.TrainName = textBox7.Text;
            //DataStore.ClassType = classType;
            //DataStore.Quota = quota;


            //DataStore.Tickets.Add(new Ticket()
            //{
            //    numercount = "1",
            //    passdelsts = textBox8.Text,
            //    From = textBox1.Text,
            //    To= textBox3.Text,
            //    Date = dateTimePicker1.Text,
            //    TrainNo = textBox6.Text,
            //    TrainName = textBox7.Text,
            //    ClassType = classType,
            //     Quota = quota




            //});


            Ticket t = new Ticket();

            t.numercount = t.numercount = (DataStore.Tickets.Count + 1).ToString(); ;
            t.passdelsts = textBox8.Text;
            t.From = textBox1.Text;
            t.To = textBox3.Text;
            t.Date = dateTimePicker1.Text;
            t.TrainNo = textBox6.Text;
            t.TrainName = textBox7.Text;
            t.ClassType = classType;
            t.Quota = quota;

            if (EditIndex == -1)
            {
                DataStore.Tickets.Add(t);
            }
            else
            {
                //DataStore.Tickets[EditIndex] = t;   
                t.numercount = DataStore.Tickets[EditIndex].numercount;
                DataStore.Tickets[EditIndex] = t;
            }

            MessageBox.Show("Data Saved Successfully");


            //this is datebase create to find area come chek

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();

                    string query = @"
        INSERT INTO Bookings
        (
            FromStation,
            ToStation,
            JourneyDate,
            TrainNo,
            ClassType,
            Quota,
            Mobile
        )
        VALUES
        (
            @FromStation,
            @ToStation,
            @JourneyDate,
            @TrainNo,
            @ClassType,
            @Quota,
            @Mobile
        );";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FromStation", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@ToStation", textBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@JourneyDate", dateTimePicker1.Value.ToString("dd-MM-yyyy"));
                        cmd.Parameters.AddWithValue("@TrainNo", textBox6.Text.Trim());
                        cmd.Parameters.AddWithValue("@ClassType", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@Quota", quota);
                        cmd.Parameters.AddWithValue("@Mobile", textBox5.Text.Trim());

                        int rows = cmd.ExecuteNonQuery();
                        MessageBox.Show("ok this erro chck to finarea whit");
                        if (rows > 0)
                        {
                            MessageBox.Show("Booking Saved Successfully");
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
















            this.Close();



        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {





        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }


        public void LoadTicket(Ticket t)
        {
            textBox8.Text = t.passdelsts;
            textBox1.Text = t.From;
            textBox3.Text = t.To;
            dateTimePicker1.Text = t.Date;
            textBox6.Text = t.TrainNo;
            textBox7.Text = t.TrainName;

            classType = t.ClassType;

            if (t.Quota == "GN")
                radioButton1.Checked = true;
            else if (t.Quota == "LD")
                radioButton2.Checked = true;
            else if (t.Quota == "TQ")
                radioButton3.Checked = true;
            else if (t.Quota == "PT")
                radioButton4.Checked = true;
        }   
    }
}
