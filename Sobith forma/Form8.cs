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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

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





        public void AddAllTickets()
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

            dataGridView1.Rows.Clear();

            //foreach (Ticket t in DataStore.Tickets)
            //{
            //    dataGridView1.Rows.Add(
            //          //t.Id,
            //        t.numercount,
            //        t.passdelsts,
            //        t.From,
            //        t.To,
            //        t.Date,
            //        t.Quota,
            //        t.ClassType,
            //        "Slot-1",
            //        "0",
            //        "0",
            //        "Open",
            //        "Login",
            //        "Edit",
            //        "Delete"
            //    );
            //}

            for (int i = 0; i < DataStore.Tickets.Count; i++)
            {
                Ticket t = DataStore.Tickets[i];

                // Number Update
                t.numercount = (i + 1).ToString();

                dataGridView1.Rows.Add(
                    t.numercount,
                    t.passdelsts,
                    t.From,
                    t.To,
                    t.Date,
                    t.Quota,
                    t.ClassType,
                    "Slot-1",
                    "0",
                    "0",
                    "Open",
                    "Login",
                    "Edit",
                    "Delete"
                );
            }




        }

        private void CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Column13")
                {
                    MessageBox.Show(dataGridView1.Columns[e.ColumnIndex].Name);

                    Form5 f5 = new Form5();

                    f5.EditIndex = e.RowIndex;

                    f5.LoadTicket(DataStore.Tickets[e.RowIndex]);

                    f5.ShowDialog();

                    AddAllTickets();
                }


            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Column14")
            {
                //DialogResult result = MessageBox.Show(
                //    "Delete this ticket?",
                //    "Confirm",
                //    MessageBoxButtons.YesNo,
                //    MessageBoxIcon.Question);

                //if (result == DialogResult.Yes)
                //{
                //    DataStore.Tickets.RemoveAt(e.RowIndex);

                //    AddAllTickets();

                //    MessageBox.Show("Ticket Deleted Successfully");
                //}




                if (MessageBox.Show("Delete this ticket?",
       "Confirm",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataStore.Tickets.RemoveAt(e.RowIndex);

                    AddAllTickets();

                    MessageBox.Show("Ticket Deleted Successfully");
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {


            DialogResult result = MessageBox.Show(
       "Are you sure you want to delete all tickets?",
       "Confirm",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // List ka saara data delete
                DataStore.Tickets.Clear();

                // DataGridView ki saari rows delete
                dataGridView1.Rows.Clear();

                MessageBox.Show("All Tickets Deleted Successfully");

                this.Close();
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


                f.From = row.Cells[2].Value.ToString();
                f.To = row.Cells[3].Value.ToString();
                f.Date = row.Cells[4].Value.ToString();
                 
                // अगर Ticket object में है
                f.TrainNo = DataStore.Tickets[i].TrainNo;
                

                f.Quota = row.Cells[5].Value.ToString();
                f.ClassType = row.Cells[6].Value.ToString();




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
    }
}
