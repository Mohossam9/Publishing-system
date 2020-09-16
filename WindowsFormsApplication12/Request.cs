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
    public partial class Request : Form
    {

        //1 get username
        public static string Getusername(SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand("select Username from Active", con);
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            string username= (string)rdr["Username"];
            rdr.Close();
            return username;
        }



        //2 insertinto advertisment
        public static void insertintoadv(SqlConnection con,ComboBox c,TextBox t1,TextBox t2, TextBox t3,DateTimePicker d)
        {

            string Type = (string)c.SelectedItem;
            string Title = t1.Text;
            string Content = t2.Text;
            string Cost = t3.Text;
            DateTime date = d.Value;


            SqlCommand cmd2 = new SqlCommand("insert into Advertisment values(@Type,@Title,@Date,@Cost,@Content)", con);
            SqlParameter input_type = new SqlParameter("@Type", Type);
            cmd2.Parameters.Add(input_type);
            SqlParameter input_Title = new SqlParameter("@Title", Title);
            cmd2.Parameters.Add(input_Title);
            SqlParameter input_date = new SqlParameter("@Date", date);
            cmd2.Parameters.Add(input_date);
            SqlParameter input_Cost = new SqlParameter("@Cost", Cost);
            cmd2.Parameters.Add(input_Cost);
            SqlParameter input_Content = new SqlParameter("@Content", Content);
            cmd2.Parameters.Add(input_Content);
            cmd2.ExecuteNonQuery();
        }



        //3 GetAdvid
        public static int Getadvid(SqlConnection con,string Content)
        {

            SqlCommand cmd3 = new SqlCommand("get_adv_id", con);
            cmd3.CommandType = CommandType.StoredProcedure;
            SqlParameter input_Content2 = new SqlParameter("@Content", Content);
            cmd3.Parameters.Add(input_Content2);
            SqlDataReader rdr3 = cmd3.ExecuteReader();
            rdr3.Read();
            int adv_id = (int)rdr3["Advertisment_ID"];
            rdr3.Close();
            return adv_id;
        }


        //4 Get userid
        public static int Getuserid(SqlConnection con,string username)
        {
            SqlCommand cmd4 = new SqlCommand("select User_ID from users where Name=@username", con);
            SqlParameter input_username = new SqlParameter("@username", username);
            cmd4.Parameters.Add(input_username);
            SqlDataReader rdr4 = cmd4.ExecuteReader();
            rdr4.Read();
            int user_id = (int)rdr4["User_ID"];
            rdr4.Close();
            return user_id;
        }

        //5 insert into User_advertisment table
        public static void insertintoUser_adv(SqlConnection con,int user_id,int adv_id,ComboBox c)
        {

            SqlCommand cmd5 = new SqlCommand("insert into User_advertisment values (@userid,@advid,@payment_method)", con);
            SqlParameter input_avid = new SqlParameter("@userid", user_id);
            cmd5.Parameters.Add(input_avid);
            SqlParameter input_userid = new SqlParameter("@advid", adv_id);
            cmd5.Parameters.Add(input_userid);
            SqlParameter input_pay = new SqlParameter("@payment_method", c.SelectedItem);
            cmd5.Parameters.Add(input_pay);
            cmd5.ExecuteNonQuery();

        }


        //6 check admin
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


        //7 insert into news table
        public static void insertnews(SqlConnection con,string Title,string Type,string Content,DateTimePicker date)
        {

            SqlCommand cmd7 = new SqlCommand("insert into News values(@Title,@Type,@Content,@Date)", con);
            SqlParameter title = new SqlParameter("@Title", Title);
            cmd7.Parameters.Add(title);
            SqlParameter in_Type = new SqlParameter("@Type", Type);
            cmd7.Parameters.Add(in_Type);
            SqlParameter in_Content = new SqlParameter("@Content", Content);
            cmd7.Parameters.Add(in_Content);
            SqlParameter in_date = new SqlParameter("@Date", date.Value);
            cmd7.Parameters.Add(in_date);
            cmd7.ExecuteNonQuery();
        }



        public Request()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSI68QP\\MOHAMEDHOSSAM;Initial Catalog=PublishingSystem;Integrated Security=True");
            con.Open();
            comboBox1.Items.Add("Sport");
            comboBox1.Items.Add("Health");
            comboBox1.Items.Add("Economy");
            comboBox1.Items.Add("Politics");
            comboBox1.Items.Add("Accidents");
            comboBox1.Items.Add("Art");
            comboBox1.Items.Add("Education");
            comboBox1.Items.Add("Business");
            comboBox2.Items.Add("CreditCard");
            comboBox2.Items.Add("Debit");
            con.Close();
        }







        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSI68QP\\MOHAMEDHOSSAM;Initial Catalog=PublishingSystem;Integrated Security=True");
            con.Open();
            string username = Getusername(con);
            int user_id= Getuserid(con, username);
            if (Checkadmin(con, username))
            {
                insertnews(con, textBox1.Text, comboBox1.SelectedItem.ToString(), textBox2.Text, dateTimePicker1);   
                con.Close();
                MessageBox.Show("Advertisment of news has been published");
                new WelcomeSystem().Show();
                Hide();
            }
            
            else
            {
                insertintoadv(con, comboBox1, textBox1, textBox2, textBox3, dateTimePicker1);
                int adv_id = Getadvid(con, textBox2.Text);
                insertintoUser_adv(con, user_id, adv_id, comboBox2);
                MessageBox.Show("Your request under discussion");
                new WelcomeSystem().Show();
                Hide();
                con.Close();
            }
        }

        private void Request_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
 }

