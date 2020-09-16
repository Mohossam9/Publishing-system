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
    public partial class WelcomeSystem : Form
    {   

        //1 return news with newest date
        public static DateTime Getmaxdate(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("select MAX(Date) as Date from News", con);
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            DateTime date = (DateTime)rdr["Date"];
            rdr.Close();
            return date;
        }



        //2 return table of latest news to be viewed in datagrid

            public static DataTable GetLatestnews (SqlConnection con,DateTime date,DataGridView G)
        {

            SqlCommand cmd2 = new SqlCommand("Getlastnews", con);
            cmd2.CommandType = CommandType.StoredProcedure;
            SqlParameter news = new SqlParameter("@date", date);
            cmd2.Parameters.Add(news);
            DataTable view = new DataTable();
            view.Columns.Add("Title");
            view.Columns.Add("Type");
            view.Columns.Add("content");
            SqlDataReader rdr2 = cmd2.ExecuteReader();
            DataRow row;
            while (rdr2.Read())
            {
                row = view.NewRow();
                row["Title"] = rdr2["Title"];
                row["Type"] = rdr2["Type"];
                row["content"] = rdr2["Content"];
                view.Rows.Add(row);
            }
            rdr2.Close();
            con.Close();
            G.DataSource = view;
            return view;
        }
    
        //2 Get news category
        

            public static void Getnewscategory(SqlConnection con, string type, DataGridView D)
        {

            SqlCommand cmd = new SqlCommand("Getnewscategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter types = new SqlParameter("@type", type);
            cmd.Parameters.Add(types);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable view = new DataTable();
            view.Columns.Add("Title");
            view.Columns.Add("Type");
            view.Columns.Add("content");
            DataRow row;
            while (rdr.Read())
            {
                row = view.NewRow();
                row["Title"] = rdr["Title"];
                row["Type"] = rdr["Type"];
                row["content"] = rdr["Content"];
                view.Rows.Add(row);
            }
            rdr.Close();
            con.Close();
            D.DataSource = view;
        }
        

        //3 Logout delete activity of user
        public static void Logout(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Delete from Active", con);
            cmd.ExecuteNonQuery();
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





        public static string Getusername(SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand("select Username from Active", con);
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            string username = (string)rdr["Username"];
            rdr.Close();
            return username;
        }







        public WelcomeSystem()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSI68QP\\MOHAMEDHOSSAM;Initial Catalog=PublishingSystem;Integrated Security=True");
            con.Open();
            DateTime date = Getmaxdate(con);
            GetLatestnews(con, date, dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSI68QP\\MOHAMEDHOSSAM;Initial Catalog=PublishingSystem;Integrated Security=True");
            con.Open();
            Getnewscategory(con, "Sport", dataGridView1);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSI68QP\\MOHAMEDHOSSAM;Initial Catalog=PublishingSystem;Integrated Security=True");
            con.Open();
            Getnewscategory(con, "Politics", dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSI68QP\\MOHAMEDHOSSAM;Initial Catalog=PublishingSystem;Integrated Security=True");
            con.Open();
            Getnewscategory(con, "Economy", dataGridView1);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSI68QP\\MOHAMEDHOSSAM;Initial Catalog=PublishingSystem;Integrated Security=True");
            con.Open();
            Getnewscategory(con, "Art", dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSI68QP\\MOHAMEDHOSSAM;Initial Catalog=PublishingSystem;Integrated Security=True");
            con.Open();
            Getnewscategory(con, "Business", dataGridView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSI68QP\\MOHAMEDHOSSAM;Initial Catalog=PublishingSystem;Integrated Security=True");
            con.Open();
            Getnewscategory(con, "Education", dataGridView1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSI68QP\\MOHAMEDHOSSAM;Initial Catalog=PublishingSystem;Integrated Security=True");
            con.Open();
            Getnewscategory(con, "Health", dataGridView1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSI68QP\\MOHAMEDHOSSAM;Initial Catalog=PublishingSystem;Integrated Security=True");
            con.Open();
            Getnewscategory(con, "Accidents", dataGridView1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new Request().Show();
            Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSI68QP\\MOHAMEDHOSSAM;Initial Catalog=PublishingSystem;Integrated Security=True");
            con.Open();
            Logout(con);
            Close();
        }




        private void WelcomeSystem_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSI68QP\\MOHAMEDHOSSAM;Initial Catalog=PublishingSystem;Integrated Security=True");
            con.Open();
            string username = Getusername(con);
            if(Checkadmin(con,username))
            {
                new WelcomeSystem_Admin_().Show();
                Hide();
            }
            else
            {
                Logout(con);
                new Login().Show();
                Hide();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
