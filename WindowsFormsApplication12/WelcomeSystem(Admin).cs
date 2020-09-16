using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication12
{
    public partial class WelcomeSystem_Admin_ : Form
    {
        public WelcomeSystem_Admin_()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new WelcomeSystem().Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Request_Window().Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Admins_controls().Show();
            Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void WelcomeSystem_Admin__Load(object sender, EventArgs e)
        {

        }
    }
}
