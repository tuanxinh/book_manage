using LibraryManage.Controller;
using LibraryManage.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManage.Presentation
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            fUsers.Loadtable();
            fManage.Loadtable();
            fBooks.LoadTable();
            if (Service._users.permission == 1)
            {
                button1.Enabled = false;
            }

            lbl_username.Text = Service._users.username;
            lbl_permission.Text = Service._permisstions.Find(x => x.id == Service._users.permission).name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fUsers fUsers = new fUsers();
            fUsers.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fBooks fUsers = new fBooks();
            fUsers.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fManage fUsers = new fManage();
            fUsers.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
