using LibraryManage.BusinessLogic;
using LibraryManage.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManage.Presentation
{
    public partial class fUsers : Form
    {
        private UserLibrary _userLibrary; 
        public fUsers()
        {
            InitializeComponent();
         
            dtgvUsers.DataSource = _dataTable;
            _userLibrary = new UserLibrary();

        }

        public static void Loadtable()
        {
            _dataTable.Columns.Add("stt");
            _dataTable.Columns.Add("fullname");
            _dataTable.Columns.Add("username");
            _dataTable.Columns.Add("email");
            _dataTable.Columns.Add("phone");
            _dataTable.Columns.Add("permission");
            _dataTable.Columns.Add("create");
        }
        public static DataTable _dataTable = new DataTable();
        private async void fUsers_Load(object sender, EventArgs e)
        {
            var data = Service._permisstions;
            foreach (var per in data)
            {
                cb_permission.Items.Add(per.name);
            }
            Service._listUsers.Clear();
            fUsers._dataTable.Rows.Clear();
            _userLibrary.GetUsers();

        }

        private void dtgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dtgvUsers.SelectedRows;
            if (selectedRows.Count > 0)
            {
                for (int i = 0; i < selectedRows.Count; i++)
                {
                    this.txt_fname.Text = _dataTable.Rows[selectedRows[i].Index][1].ToString();
                    this.txt_username.Text = _dataTable.Rows[selectedRows[i].Index][2].ToString();
                    this.txt_email.Text = _dataTable.Rows[selectedRows[i].Index][3].ToString();
                    this.txtphone.Text = _dataTable.Rows[selectedRows[i].Index][4].ToString();             
                    this.cb_permission.Text = _dataTable.Rows[selectedRows[i].Index][5].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.txt_username.Text;
            string password = this.txt_password.Text;
            string fullname = this.txt_fname.Text;
            string email = this.txt_email.Text;
            string phone = this.txtphone.Text;
            int permission = Service._permisstions.Find(x => x.name.Equals(cb_permission.Text)).id;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(fullname) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(phone) && permission != 0)
            {
                _userLibrary.InsertUser(fullname, username, email, phone, permission, password);
            }
            else
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = this.txt_username.Text;
            string fullname = this.txt_fname.Text;
            string email = this.txt_email.Text;
            string phone = this.txtphone.Text;
            int permission = Service._permisstions.Find(x => x.name.Equals(cb_permission.Text)).id;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(fullname) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(phone) && permission != 0)
            {
                _userLibrary.EditUser(fullname, username, email, phone, permission);
            }
            else
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string username = this.txt_username.Text;

            if (!string.IsNullOrEmpty(username))
            {
                _userLibrary.DeleteUser(username);
            }
            else
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string content = txt_content.Text;
            if (string.IsNullOrEmpty(content))
            {
                _dataTable.Rows.Clear();
                _userLibrary.GetUsers();
                return;
            }
            string _findBy = "fullname";
            if (radioButton2.Checked)
            {
                _findBy = "username";
            }
            if (radioButton3.Checked)
            {
                _findBy = "email";  
            }
            _dataTable.Rows.Clear();
            _userLibrary.FindUsers(content, _findBy);
           

        }
    }
}
