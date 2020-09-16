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
    public partial class Request_Window : Form
    {

        // get advertisment in table 
        public static DataTable Get_one_advrequest(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("select Type,Title,Content,date from Advertisment", con);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable view = new DataTable();
            view.Columns.Add("Type");
            view.Columns.Add("Title");
            view.Columns.Add("Content");
            view.Columns.Add("date");
            DataRow row;
            if (rdr.Read())
            {
                row = view.NewRow();
                row["Type"] = rdr["Type"];
                row["Title"] = rdr["Title"];
                row["Content"] = rdr["Content"];
                row["date"] = rdr["date"];
                view.Rows.Add(row);
                return view;
            }
            else
            {
                MessageBox.Show("No more requests");
                return null;
            }

        }

        //insert in table news
        public static void insertnews(SqlConnection con,string title,string type,string content,DateTime date)
        {

            SqlCommand cmd7 = new SqlCommand("insert into News values(@Title,@Type,@Content,@Date)", con);
            SqlParameter in_title = new SqlParameter("@Title",title);
            cmd7.Parameters.Add(in_title);
            SqlParameter in_Type = new SqlParameter("@Type", type);
            cmd7.Parameters.Add(in_Type);
            SqlParameter in_Content = new SqlParameter("@Content", content);
            cmd7.Parameters.Add(in_Content);
            SqlParameter in_date = new SqlParameter("@Date", date);
            cmd7.Parameters.Add(in_date);
            cmd7.ExecuteNonQuery();
        }

        //delete advertisment from table after admin respond

        public static void Delete_adv(SqlConnection con,string title)
        {
            SqlCommand cmd = new SqlCommand("delete_adv", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter intitle = new SqlParameter("@title", title);
            cmd.Parameters.Add(intitle);
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            rdr.Close();
            
        }

        // delete adv_Id from user_advertisment table

        public static void deleteadvid(SqlConnection con, string Content)
        {

            SqlCommand cmd3 = new SqlCommand("get_adv_id", con);
            cmd3.CommandType = CommandType.StoredProcedure;
            SqlParameter input_Content2 = new SqlParameter("@Content", Content);
            cmd3.Parameters.Add(input_Content2);
            SqlDataReader rdr3 = cmd3.ExecuteReader();
            rdr3.Read();
            int adv_id = (int)rdr3["Advertisment_ID"];
            rdr3.Close();
            SqlCommand cmd = new SqlCommand("delete_adv_id_user_re_table", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter adv = new SqlParameter("@advid", adv_id);
            cmd.Parameters.Add(adv);
            SqlDataReader rdr4 = cmd.ExecuteReader();
            rdr4.Read();
            rdr4.Close();
           
        }


        public Request_Window()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSI68QP\\MOHAMEDHOSSAM;Initial Catalog=PublishingSystem;Integrated Security=True");
            con.Open();
            DataTable view=Get_one_advrequest(con);
            dataGridView1.DataSource = view;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSI68QP\\MOHAMEDHOSSAM;Initial Catalog=PublishingSystem;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select Type,Title,Content,date from Advertisment", con);
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            string type = (string)rdr["Type"];
            string title = (string)rdr["Title"];
            string content = (string)rdr["Content"];
            DateTime date = (DateTime)rdr["date"];
            rdr.Close();
            insertnews(con, title, type, content, date);
            deleteadvid(con, content);
            Delete_adv(con,title);
            MessageBox.Show("Your acception is successful");
            con.Close();
            
        }




        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NSI68QP\\MOHAMEDHOSSAM;Initial Catalog=PublishingSystem;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select Title, Content from Advertisment", con);
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            string title = (string)rdr["Title"];
            string content = (string)rdr["Content"];
            rdr.Close();
            deleteadvid(con, content);
            Delete_adv(con, title);
            MessageBox.Show("Your rejection is successful");
            con.Close();
        }

        private void Request_Window_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            new WelcomeSystem_Admin_().Show();
            Hide();
        }
    }
}
