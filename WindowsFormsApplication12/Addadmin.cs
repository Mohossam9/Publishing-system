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
    public partial class Addadmin : Form
    {




        public static Int64 Finduserpass(SqlConnection con,TextBox t)
        {

            SqlCommand cmd = new SqlCommand("Getuserpass", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter username = new SqlParameter("@username", t.Text);
            cmd.Parameters.Add(username);
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            Int64 pass =(Int64)rdr["Password"];
            rdr.Close();
            return pass;

        }




        public static void insertintoadmins(SqlConnection con,TextBox t,Int64 pass)
        {
            SqlCommand cmd = new SqlCommand("insert into Admins values (@Name,@Password)", con);
            SqlParameter username = new SqlParameter("@Name", t.Text);
            cmd.Parameters.Add(username);
            SqlParameter password = new SqlParameter("@Password", pass);
            cmd.Parameters.Add(password);
            cmd.ExecuteNonQuery();
        }


        public static bool check (SqlConnection con,TextBox t1)
        {
            if(t1.Text=="")
            {
                return false;
            }
            return true;
        }






        public Addadmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSI68QP\\MOHAMEDHOSSAM;Initial Catalog=PublishingSystem;Integrated Security=True");
            con.Open();
            if (check(con, textBox1))
            {
                Int64 userpass=Finduserpass(con, textBox1);
                insertintoadmins(con, textBox1, userpass);
                MessageBox.Show( "He is admin now");
                con.Close();
                new WelcomeSystem_Admin_().Show();
                Hide();
                
            }
            else
            {
                MessageBox.Show("Please enter correct Username");
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new WelcomeSystem_Admin_().Show();
            Hide();
        }
    }
}
