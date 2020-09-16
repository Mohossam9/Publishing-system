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
    public partial class Login : Form
 {
        public Login()
        {
            InitializeComponent();
        }




        //1 
        public static bool CheckLogin(SqlConnection con,TextBox t1,TextBox t2)
        {
            SqlCommand cmd = new SqlCommand("Logininfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter input1 = new SqlParameter("@username", t1.Text);
            cmd.Parameters.Add(input1);
            SqlParameter input2 = new SqlParameter("@password", t2.Text);
            cmd.Parameters.Add(input2);
            SqlDataReader rdr = cmd.ExecuteReader();
            if(rdr.Read())
            {
                rdr.Close();
                return true;
            }
            rdr.Close();
            return false;
        }



        //2
        public static void Insertintoactive(SqlConnection con,TextBox t)
        {
            SqlCommand cmd2 = new SqlCommand("insert into Active(Username) values (@username)", con);
            SqlParameter input_id = new SqlParameter("@username", t.Text);
            cmd2.Parameters.Add(input_id);
            cmd2.ExecuteNonQuery();
        }


        //3
        public static bool GetintoWelcomeAdmin(SqlConnection con, TextBox t)

        {
            string username = t.Text;
            SqlCommand cmd3 = new SqlCommand("Checkadmin", con);
            cmd3.CommandType = CommandType.StoredProcedure;
            SqlParameter user_name = new SqlParameter("@username", username);
            cmd3.Parameters.Add(user_name);
            SqlDataReader rdr2 = cmd3.ExecuteReader();
            if (rdr2.Read())
            {
                rdr2.Close();
                return true;
            }
            rdr2.Close();
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSI68QP\\MOHAMEDHOSSAM;Initial Catalog=PublishingSystem;Integrated Security=True");
            con.Open();
            if (CheckLogin(con,textBox1,textBox2))
            {
                Insertintoactive(con, textBox1);
                if (GetintoWelcomeAdmin(con, textBox1))
                {
                    new WelcomeSystem_Admin_().Show();
                    Hide();
                }
                else
                {
                    new WelcomeSystem().Show();
                    Hide();
                }
            }
            else
            {
                MessageBox.Show("invalid username or password Please try again Or register");
            }
            con.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
                
                new Registeration().Show();
                this.Hide();
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
