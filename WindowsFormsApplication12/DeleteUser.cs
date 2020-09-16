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
    public partial class DeleteUser : Form
    {

        public static bool check(SqlConnection con,TextBox t)
        {
            if (t.Text == "")
                return false;

            return true;
        }


        public static void Deleteuser(SqlConnection con,TextBox t)
        {
            SqlCommand cmd = new SqlCommand("Delete from users where Name=@username",con);
            SqlParameter username = new SqlParameter("@username", t.Text);
            cmd.Parameters.Add(username);
            cmd.ExecuteNonQuery();
        }


        public static bool checkname(SqlConnection con,TextBox t)
        {
            SqlCommand cmd = new SqlCommand("select Name from users",con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                if(t.Text==(string)rdr["Name"])
                {
                    rdr.Close();
                    return true;
                }

            }
            rdr.Close();
            return false;

        }





        public DeleteUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSI68QP\\MOHAMEDHOSSAM;Initial Catalog=PublishingSystem;Integrated Security=True");
            con.Open();
            if(check(con,textBox1))
            {
                if (checkname(con, textBox1))
                {
                    Deleteuser(con, textBox1);
                    MessageBox.Show("User has been removed");
                    con.Close();
                    new Admins_controls().Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("No user has this name");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Admins_controls().Show();
            Hide();
        }

        private void DeleteUser_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
