using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sobith_forma
{
    public partial class Form8 : Form
    {
        private readonly string connectionString = @"Data Source=C:\Users\ksobi\source\repos\Sobith forma\Sobith forma\bin\Debug\Mass.db;Version=3;"; 
        public Form8()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void LoadBookings()
        {
            try
            {
                DataGridViewComboBoxColumn slot =
    (DataGridViewComboBoxColumn)dataGridView1.Columns["slot"];
                slot.Items.Clear();
                slot.Items.Add("Slot-1");
                slot.Items.Add("Slot-2");

                DataGridViewComboBoxColumn web =
                    (DataGridViewComboBoxColumn)dataGridView1.Columns["Web"];
                web.Items.Clear();
                web.Items.Add("0");
                web.Items.Add("1");

                DataGridViewComboBoxColumn app =
                    (DataGridViewComboBoxColumn)dataGridView1.Columns["App"];
                app.Items.Clear();
                app.Items.Add("0");
                app.Items.Add("1");

                dataGridView1.Rows.Clear();

                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();

                    string query = @"
            SELECT
                BookingId,
                FromStation,
                ToStation,
                JourneyDate,
                TrainNo,
                ClassType,
                Quota,
                TrainSercherNamePF
            FROM Bookings
            ORDER BY BookingId DESC";
                    
                    
                    int sr = 1;

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                    
                                dataGridView1.Rows.Add(
                                reader["BookingId"].ToString(),
                                        sr++,
                                    reader["TrainSercherNamePF"].ToString(),
                                    reader["FromStation"].ToString(),
                                    reader["ToStation"].ToString(),
                                    reader["JourneyDate"].ToString(),
                                        
                                    reader["ClassType"].ToString(),
                                    reader["Quota"].ToString(),
                                     "Slot-1",                                // SLOT
                                       "0",                                     // Web
                                        "0",                                    // App
                                     "Open",                                 // Open
                                     "Login",                                // Login
                                         "Edit",                                 // Edit
                                      "Delete"

                                );
                            }

                            
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(
                    ex.Message,
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






        private void Form8_Load(object sender, EventArgs e)
        {
            LoadBookings();


            //MessageBox.Show(DataStore.From);
            //MessageBox.Show(DataStore.To);
            //MessageBox.Show(DataStore.Date);
            //MessageBox.Show(DataStore.TrainNo);
            //MessageBox.Show(DataStore.TrainName);
            //MessageBox.Show(DataStore.ClassType);
            //MessageBox.Show(DataStore.Quota);


            //dataGridView1.Rows.Add(
            //DataStore.numercount,
            //DataStore.passdelsts,
            //DataStore.From,        // From
            //DataStore.To,          // To
            //DataStore.Date,        // Date
            //DataStore.Quota,       // QT
            //DataStore.ClassType,   // CLS
            //"Slot-1",              // SLOT
            //"0",
            //"0",// Web
            // "Open",
            //"Login",
            //"Edit",
            //"Delete"

            //              DataGridViewComboBoxColumn slot =
            //            (DataGridViewComboBoxColumn)dataGridView1.Columns["slot"];

            //        slot.Items.Clear();
            //        slot.Items.Add("Slot-1");
            //        slot.Items.Add("Slot-2");

            //        // Web Combo
            //        DataGridViewComboBoxColumn web =
            //            (DataGridViewComboBoxColumn)dataGridView1.Columns["Web"];

            //        web.Items.Clear();
            //        web.Items.Add("0");
            //        web.Items.Add("1");

            //        // App Combo
            //        DataGridViewComboBoxColumn app =
            //            (DataGridViewComboBoxColumn)dataGridView1.Columns["App"];

            //        app.Items.Clear();
            //        app.Items.Add("0");
            //        app.Items.Add("1");

            //        // Data Add
            //        dataGridView1.Rows.Add(
            //            DataStore.numercount,
            //            DataStore.passdelsts,
            //            DataStore.From,
            //            DataStore.To,
            //            DataStore.Date,
            //            DataStore.Quota,
            //            DataStore.ClassType,
            //            "Slot-1",
            //            "0",
            //            "0",
            //            "Open",
            //            "Login",
            //            "Edit",
            //            "Delete"
            //// Name
            //// App
            //);
        }




        //public void AddTicket()
        //{



        //    DataGridViewComboBoxColumn slot =
        //  (DataGridViewComboBoxColumn)dataGridView1.Columns["slot"];

        //    slot.Items.Clear();
        //    slot.Items.Add("Slot-1");
        //    slot.Items.Add("Slot-2");

        //    // Web Combo
        //    DataGridViewComboBoxColumn web =
        //        (DataGridViewComboBoxColumn)dataGridView1.Columns["Web"];

        //    web.Items.Clear();
        //    web.Items.Add("0");
        //    web.Items.Add("1");

        //    // App Combo
        //    DataGridViewComboBoxColumn app =
        //        (DataGridViewComboBoxColumn)dataGridView1.Columns["App"];

        //    app.Items.Clear();
        //    app.Items.Add("0");
        //    app.Items.Add("1");

        //    // Data Add
        //    dataGridView1.Rows.Add(
        //        DataStore.numercount,
        //        DataStore.passdelsts,
        //        DataStore.From,
        //        DataStore.To,
        //        DataStore.Date,
        //        DataStore.Quota,
        //        DataStore.ClassType,
        //        "Slot-1",
        //        "0",
        //        "0",
        //        "Open",
        //        "Login",
        //        "Edit",
        //        "Delete"

        //        );
        //}





      //  public void AddAllTickets() 
      //  {

      //      DataGridViewComboBoxColumn slot =
      //(DataGridViewComboBoxColumn)dataGridView1.Columns["slot"];

      //      slot.Items.Clear();
      //      slot.Items.Add("Slot-1");
      //      slot.Items.Add("Slot-2");

      //      DataGridViewComboBoxColumn web =
      //          (DataGridViewComboBoxColumn)dataGridView1.Columns["Web"];

      //      web.Items.Clear();
      //      web.Items.Add("0");
      //      web.Items.Add("1");

      //      DataGridViewComboBoxColumn app =
      //          (DataGridViewComboBoxColumn)dataGridView1.Columns["App"];

      //      app.Items.Clear();
      //      app.Items.Add("0");
      //      app.Items.Add("1");

          





        //}

        private void CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Column13")
                {
                    //MessageBox.Show(dataGridView1.Columns[e.ColumnIndex].Name);

                    Form5 f5 = new Form5();


                //f5.BookingId = Convert.ToInt32(
                //           dataGridView1.Rows[e.RowIndex].Cells["Column8"].Value);

                f5.IsEdit = true;
                //f5.BookingId = BookingId;
                f5.BookingId = Convert.ToInt32( dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                MessageBox.Show(
    "Before Open Form5" +
    "\nIsEdit = " + f5.IsEdit +
    "\nBookingId = " + f5.BookingId);

                //f5.ShowDialog();

                f5.ShowDialog();

                // Database से Grid दुबारा Load करो
                LoadBookings();

                //f5.EditIndex = e.RowIndex;

                //f5.LoadTicket(DataStore.Tickets[e.RowIndex]);

                //f5.ShowDialog();

                //AddAllTickets();
            }


            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Column14")
            {

                //           if (MessageBox.Show("Delete this Booking ?",
                //"Confirm",
                //MessageBoxButtons.YesNo,
                //MessageBoxIcon.Question) == DialogResult.Yes)
                //           {
                //               try
                //               {
                //                   int bookingId = Convert.ToInt32(
                //                       dataGridView1.Rows[e.RowIndex].Cells["Column8"].Value);

                //                   using (SQLiteConnection con = new SQLiteConnection(connectionString))
                //                   {
                //                       con.Open();

                //                       string query = "DELETE FROM Bookings WHERE BookingId=@BookingId";

                //                       using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                //                       {
                //                           cmd.Parameters.AddWithValue("@BookingId", bookingId);

                //                           cmd.ExecuteNonQuery();

                //                       }

                //                   }

                //                   MessageBox.Show("Booking Deleted Successfully");

                //                   LoadBookings();
                //               }
                //               catch (Exception ex)
                //               {
                //                   MessageBox.Show(ex.Message);
                //               }
                //           }



                if (MessageBox.Show("Delete this Booking ?",
       "Confirm",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        int bookingId = Convert.ToInt32(
                            dataGridView1.Rows[e.RowIndex].Cells["Column8"].Value);

                        using (SQLiteConnection con = new SQLiteConnection(connectionString))
                        {
                            con.Open();

                            // 1. पहले Passengers Delete
                            using (SQLiteCommand cmd = new SQLiteCommand(
                                "DELETE FROM Passengers WHERE BookingId=@BookingId", con))
                            {
                                cmd.Parameters.AddWithValue("@BookingId", bookingId);
                                cmd.ExecuteNonQuery();
                            }

                            // 2. फिर Booking Delete
                            using (SQLiteCommand cmd = new SQLiteCommand(
                                "DELETE FROM Bookings WHERE BookingId=@BookingId", con))
                            {
                                cmd.Parameters.AddWithValue("@BookingId", bookingId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Booking Deleted Successfully");

                        LoadBookings();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
    "Are you sure you want to delete all bookings?",
    "Confirm",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SQLiteConnection con = new SQLiteConnection(connectionString))
                    {
                        con.Open();

                        // Passengers Table Delete
                        using (SQLiteCommand cmd = new SQLiteCommand("DELETE FROM Passengers", con))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        // Bookings Table Delete
                        using (SQLiteCommand cmd = new SQLiteCommand("DELETE FROM Bookings", con))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    LoadBookings();

                    MessageBox.Show("All Bookings Deleted Successfully");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }






        }

        private void button3_Click(object sender, EventArgs e)
        {


            



            int i = 0;

            int startX = 50;
            int startY = 50;

            int formWidth = 320;   // Form9 Width + Gap
            int formHeight = 220;  // Form9 Height + Gap

            int formsPerRow = 4;   // एक लाइन में 4 Form

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                Form9 f = new Form9();


             

                f.From = row.Cells[3].Value.ToString();
                f.To = row.Cells[4].Value.ToString();
                f.Date = row.Cells[5].Value.ToString();
                f.TrainNo = row.Cells[0].Value.ToString();
                f.ClassType = row.Cells[6].Value.ToString();
                f.Quota = row.Cells[7].Value.ToString();


                f.StartPosition = FormStartPosition.Manual;

                int column = i % formsPerRow;
                int rowNo = i / formsPerRow;

                f.Location = new Point(
                    startX + (column * formWidth),
                    startY + (rowNo * formHeight)
                );

                f.Show();

                i++;
            }




        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
