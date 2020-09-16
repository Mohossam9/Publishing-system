using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication12
{
    public partial class DeleteAdmin_admin : Form
    {

        public static bool check (SqlConnection con,TextBox t)
        {
            if(t.Text!="")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        



        public static void Deleteadmin(SqlConnection con,TextBox t)
        {
            SqlCommand cmd = new SqlCommand("Deleteadmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter username = new SqlParameter("@adminname", t.Text);
            cmd.Parameters.Add(username);
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            rdr.Close();

        }



        public static bool Checkadmin(SqlConnection con, string username)
        {

            SqlCommand cmd6 = new SqlCommand("Checkadmin", con);
            cmd6.CommandType = CommandType.StoredProcedure;
            SqlParameter input = new SqlParameter("@username", username);
            cmd6.Parameters.Add(input);
            SqlDataReader rdr6 = cmd6.ExecuteReader();
            if (rdr6.Read())
            {
                rdr6.Close();
                return true;
            }
            rdr6.Close();
            return false;
        }




        public DeleteAdmin_admin()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSI68QP\\MOHAMEDHOSSAM;Initial Catalog=PublishingSystem;Integrated Security=True");
            con.Open();
            if (check(con, textBox1))
            {
                if (Checkadmin(con, textBox1.Text))
                {
                    Deleteadmin(con, textBox1);
                    MessageBox.Show("Admin has been deleted");
                }
                else
                {
                    MessageBox.Show("Incorrect admin name");
                }
                con.Close();
                new Admins_controls().Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Please Enter Username");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Admins_controls().Show();
            Hide();
        }

        private void DeleteAdmin_admin_Load(object sender, EventArgs e)
        {

        }
    }
}
