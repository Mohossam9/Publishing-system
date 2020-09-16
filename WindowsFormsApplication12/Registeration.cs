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
    public partial class Registeration : Form
    {
        public Registeration()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSI68QP\\MOHAMEDHOSSAM;Initial Catalog=PublishingSystem;Integrated Security=True");
            con.Open();
            comboBox1.Items.Add("Male");
            comboBox1.Items.Add("Female");
            con.Close();
        }


        //1
        public static void Insertintousers(SqlConnection con,TextBox t1,TextBox t2,TextBox t3,TextBox t4,TextBox t5,TextBox t6,TextBox t7,ComboBox c1,DateTimePicker d1)
        {

            SqlCommand cmd = new SqlCommand("insert into users values (@username,@password,@email,@gender,@phone,@country,@city,@street,@birthdate)", con);
            cmd.CommandType = CommandType.Text;
            SqlParameter input1 = new SqlParameter("@username", t1.Text);
            cmd.Parameters.Add(input1);
            SqlParameter input2 = new SqlParameter("@password", t2.Text);
            cmd.Parameters.Add(input2);
            SqlParameter input3 = new SqlParameter("@email", t3.Text);
            cmd.Parameters.Add(input3);
            SqlParameter input4 = new SqlParameter("@gender", c1.SelectedItem);
            cmd.Parameters.Add(input4);
            SqlParameter input5 = new SqlParameter("@birthdate", d1.Value);
            cmd.Parameters.Add(input5);
            SqlParameter input6 = new SqlParameter("@phone", t4.Text);
            cmd.Parameters.Add(input6);
            SqlParameter input7 = new SqlParameter("@country", t5.Text);
            cmd.Parameters.Add(input7);
            SqlParameter input8 = new SqlParameter("@city", t6.Text);
            cmd.Parameters.Add(input8);
            SqlParameter input9 = new SqlParameter("@street", t7.Text);
            cmd.Parameters.Add(input9);
            cmd.ExecuteNonQuery();
        }

        //2
        public static bool Checkinformations(SqlConnection con, TextBox t1, TextBox t2, TextBox t3, TextBox t4, TextBox t5, TextBox t6, TextBox t7, ComboBox c1)
        {

            if(t1.Text=="" || t2.Text=="" || t3.Text==""||t4.Text==""|| t5.Text=="" ||t6.Text==""||t7.Text==""||c1==null)
            {
                return false;
            }

            return true;
        }


        //check previous form if it was adduser
        public static bool checkform(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("select * from Active",con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if(rdr.Read())
            {
                rdr.Close();
                return true;
            }
            else
            {
                rdr.Close();
                return false;
            }

        }







        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSI68QP\\MOHAMEDHOSSAM;Initial Catalog=PublishingSystem;Integrated Security=True");
            con.Open();
            if (Checkinformations(con, textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, comboBox1))
            {
                Insertintousers(con, textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, comboBox1, dateTimePicker1);
                MessageBox.Show("You have requested successfully");
                new Login().Show();
                Hide();
            }
            else
                MessageBox.Show("Please enter your informations correctly");
            con.Close();
        }




        private void Registeration_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSI68QP\\MOHAMEDHOSSAM;Initial Catalog=PublishingSystem;Integrated Security=True");
            con.Open();
            if (checkform(con))
            {
                new Admins_controls().Show();
                Hide();
            }
            else
            {
                new Login().Show();
                Hide();
            }
            con.Close();
        }
    }
}
