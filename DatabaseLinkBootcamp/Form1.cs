﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseLinkBootcamp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                //connection to database (connection string)
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-110CBOF\SQLEXPRESS;Initial Catalog=CrossCammpus1;Integrated Security=True");

                // Open connection
                con.Open();

                //Create a sql command & prep app for sql query 
                SqlCommand cmd = con.CreateCommand();

                //Create the type of command
                cmd.CommandType = CommandType.Text;

                //type out the query 

                cmd.CommandText = "SELECT * FROM UpdateInfo";

                DataTable d = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(d);

                dgvDisplay.DataSource = d;


                //close connection
                con.Close();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
