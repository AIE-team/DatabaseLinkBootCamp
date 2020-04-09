using System;
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

        //connection to database (connection string)
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-110CBOF\SQLEXPRESS;Initial Catalog=CrossCammpus1;Integrated Security=True");


        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open(); 

                var qeury = "Select * from LoginDetails where username = @username and userpassword =@password";
                var command = new SqlCommand(qeury, con);

                command.Parameters.AddWithValue("@username", txtName.Text);
                command.Parameters.AddWithValue("@password", txtPass.Text);

                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    DetailForm ifd = new DetailForm();
                    ifd.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }   
}
