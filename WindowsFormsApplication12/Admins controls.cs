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
    public partial class Admins_controls : Form
    {
        public Admins_controls()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            new Addadmin().Show();
            Hide();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Registeration().Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new DeleteAdmin_admin().Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new DeleteUser().Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new WelcomeSystem_Admin_().Show();
            Hide();
        }

        private void Admins_controls_Load(object sender, EventArgs e)
        {

        }
    }
}
