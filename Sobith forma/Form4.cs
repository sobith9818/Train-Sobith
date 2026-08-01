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
    public partial class Form4 : Form
    {
        private readonly string connectionString = @"Data Source=C:\Users\ksobi\source\repos\Sobith forma\Sobith forma\bin\Debug\Mass.db;Version=3;";
        public Form4()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.Close();
        }

       

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
         

        }

        private void Form4_Load(object sender, EventArgs e)
        {



            try
            {

                // Table create
                CreateIRCTCAccountsTable();

                // Database data Grid में show
                LoadIRCTCAccounts();
                dataGridView1.Columns[0].Visible = false;

            }
            catch
            {

                MessageBox.Show("this is erro");



            }
 }




        private void CreateIRCTCAccountsTable()
        {

            using (SQLiteConnection con =
                 new SQLiteConnection(connectionString))
            {
                con.Open();

                string query = @"
                    CREATE TABLE IF NOT EXISTS IRCTCAccounts
                    (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,

                        Username TEXT NOT NULL UNIQUE,

                        Password TEXT NOT NULL
                    );
                ";

                using (SQLiteCommand cmd =
                       new SQLiteCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }









        private void button2_Click(object sender, EventArgs e)
        {
  
            string username = textBox1.Text.Trim();
            string password = textBox2.Text;


            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show(
                    "User ID डालें।",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                textBox1.Focus();

                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Password डालें।",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                textBox2.Focus();

                return;
            }



            try {






                using (SQLiteConnection con =
                      new SQLiteConnection(connectionString))
                {

                    con.Open();

                    // ================================
                    // UPDATE
                    // ================================
                    if (SelectedId > 0)
                    {
                        string checkUpdate = @"
    SELECT COUNT(*)
    FROM IRCTCAccounts
    WHERE Username=@Username
    AND Id<>@Id";

                        using (SQLiteCommand checkCmd =
                            new SQLiteCommand(checkUpdate, con))
                        {
                            checkCmd.Parameters.AddWithValue("@Username", username);
                            checkCmd.Parameters.AddWithValue("@Id", SelectedId);

                            long count = Convert.ToInt64(checkCmd.ExecuteScalar());

                            if (count > 0)
                            {
                                MessageBox.Show(
                                    "यह User ID पहले से मौजूद है।",
                                    "Duplicate User ID",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                return;
                            }
                        }

                        string updateQuery = @"
    UPDATE IRCTCAccounts
    SET
        Username=@Username,
        Password=@Password
    WHERE Id=@Id";

                        using (SQLiteCommand cmd =
                            new SQLiteCommand(updateQuery, con))
                        {
                            cmd.Parameters.AddWithValue("@Username", username);
                            cmd.Parameters.AddWithValue("@Password", password);
                            cmd.Parameters.AddWithValue("@Id", SelectedId);

                            int rows = cmd.ExecuteNonQuery();

                            if (rows > 0)
                            {
                                MessageBox.Show(
                                    "IRCTC ID Successfully Update हो गई।",
                                    "Success",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                        }

                        SelectedId = 0;

                        textBox1.Clear();
                        textBox2.Clear();

                        textBox1.Focus();

                        LoadIRCTCAccounts();

                        return;
                    }

                    string checkQuery = @"
                        SELECT COUNT(*)
                        FROM IRCTCAccounts
                        WHERE Username = @Username;
                    ";


                    using (SQLiteCommand checkCmd =
                          new SQLiteCommand(checkQuery, con))
                    {


                        checkCmd.Parameters.AddWithValue(
                           "@Username",
                           username
                       );
                        long count =
                           Convert.ToInt64(
                               checkCmd.ExecuteScalar()
                           );


                        if (count > 0) {


                            MessageBox.Show(
                                "यह User ID पहले से मौजूद है।",
                                "Duplicate User ID",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                                );

                            textBox1.Focus();
                            textBox1.SelectAll();

                            return;
                        }


                    }


                    // =================================
                    // INSERT USER + PASSWORD
                    // =================================

                    string insertQuery = @"
                        INSERT INTO IRCTCAccounts
                        (
                            Username,
                            Password
                        )
                        VALUES
                        (
                            @Username,
                            @Password
                        );
                    ";

                    using (SQLiteCommand cmd =
                         new SQLiteCommand(insertQuery, con))
                    {

                        cmd.Parameters.AddWithValue(
                         "@Username",
                         username
                     );

                        cmd.Parameters.AddWithValue(
                            "@Password",
                            password
                        );


                        int rows =
                            cmd.ExecuteNonQuery();


                        // =================================
                        // INSERT SUCCESS CHECK
                        // =================================

                        if (rows > 0)
                        {
                            MessageBox.Show(
                                "IRCTC ID Successfully Add हो गई।",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }


                        else
                        {
                            MessageBox.Show(
                                "IRCTC ID Save नहीं हुई।",
                                "Save Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );

                            return;
                        }

                    }

                }

                textBox1.Clear();
                textBox2.Clear();

                textBox1.Focus();

                // =====================================
                // GRID REFRESH
                // =====================================

                LoadIRCTCAccounts();


            }

            catch (SQLiteException ex)
            {


                if (ex.ResultCode == SQLiteErrorCode.Constraint)
                {
                    MessageBox.Show(
                        "यह User ID पहले से मौजूद है।",
                        "Duplicate User ID",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    textBox1.Focus();
                    textBox1.SelectAll();
                }
                else
                {
                    MessageBox.Show(
                        "Database Error:\n\n" +
                        ex.Message,
                        "SQLite Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error:\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }






        }




        private void LoadIRCTCAccounts()
        {


            try {
                dataGridView1.Rows.Clear(); // check delete kar nahi line par 
                using (SQLiteConnection con =
                         new SQLiteConnection(connectionString))
                {
                    con.Open();


                    string query = @"
                        SELECT
                            Id,
                            Username,
                            Password
                        FROM IRCTCAccounts
                        ORDER BY Id DESC;
                    ";



                    using (SQLiteCommand cmd =
                         new SQLiteCommand(query, con))
                    {
                        using (SQLiteDataReader reader =
                             cmd.ExecuteReader())
                        {


                            //this gied add
                            while (reader.Read())
                            {
                                string username =
                                   reader["Username"].ToString();

                                string password =
                                    reader["Password"].ToString();

                                int id = Convert.ToInt32(reader["Id"]);
                                // =========================
                                // आपके existing design की
                                // 7 columns SAME रहेंगी
                                // =========================

                                dataGridView1.Rows.Add(
                                    
                                     id,// User ID
                                    username,
                                    password,       // Password
                                    "erro",         // Total Pnr
                                    "0000000000",   // Mobile num
                                    "Active",       // Active
                                    "Delete",       // Delete
                                    "View"          // History
                                );

                               
                            }

                                
                        }
                    }
                }







            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(
                       "Grid Data Load नहीं हुआ।\n\n" +
                       ex.Message,
                       "Database Error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error
                   );


            }

            catch (Exception ex)
            {
                MessageBox.Show(
                    "Grid Error:\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }


        }
        private int SelectedId = 0;  // this is value to connpt to find ara 


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void eventclickdel(object sender, DataGridViewCellEventArgs e)
        {



            // Username Column
            if (e.ColumnIndex == 1)
            {
                SelectedId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                return;
            }

            // Password Column
            if (e.ColumnIndex == 2)
            {
                SelectedId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                return;
            }


            if (e.RowIndex < 0)
                return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "delete")
            {


                DialogResult result = MessageBox.Show(
           "Do you want to delete this account ?",
           "Delete",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;


                try
                {

                    int id = Convert.ToInt32(
                                        dataGridView1.Rows[e.RowIndex].Cells[0].Value);

                    using (SQLiteConnection con = new SQLiteConnection(connectionString))
                    {

                        con.Open();
                        string sql =
                  "DELETE FROM IRCTCAccounts WHERE Id=@Id";

                        using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                        {

                            cmd.Parameters.AddWithValue("@Id", id);

                            //cmd.ExecuteNonQuery();
                            int rows = cmd.ExecuteNonQuery();
                            
                            ; 
                        }
                    }


                    LoadIRCTCAccounts();

                    MessageBox.Show(
                        "Account Deleted Successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);


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



        }


    }
}
