
using LibraryManage.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManage
{
    public partial class fLogin : Form
    {

        private UserLibrary _userLibrary;
        public fLogin()
        {
            InitializeComponent();
            _userLibrary = new UserLibrary();
        }
       
        private void fLogin_Load(object sender, EventArgs e)
        {
           
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string username = txtuser.Text;
            string password = txtpass.Text;


            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password)) 
            {
                 _userLibrary.UserLoginAsync(username, password);
                //this.Close();
            }
            else
            {
                MessageBox.Show("Chưa nhập thông tin");
            }
            
        }
    }
}
