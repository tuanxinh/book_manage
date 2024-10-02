using LibraryManage.Controller;
using LibraryManage.DataAccess;
using LibraryManage.Model;
using LibraryManage.Presentation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManage.BusinessLogic
{
    public class UserLibrary
    {
        private readonly UserRepository _userRepository;

        

        public UserLibrary()
        {
            _userRepository = new UserRepository();
        }
        public async Task UserLoginAsync(string username, string password)
        {
            try
            {
               
                var login = await _userRepository.LoginAsync(username, password);

                if (login != null && login.status == 1)
                {
                    Service._users = login.users;
                    fMain fMain = new fMain();
                    fMain.Show();
                }
                else
                {
                    MessageBox.Show(login.message);
                }
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }
            
        }
        public void FindUsers(string content, string valuaFind)
        {
            for (int i = 0; i < Service._listUsers.Count; i++)
            {
                var user = Service._listUsers[i];
                if (user != null)
                {
                    if (valuaFind.Equals("fullname") && user.fullname.ToLower().Contains(content.ToLower()))
                    {
                        // Insert table
                        DataRow row = fUsers._dataTable.NewRow();
                        row["stt"] = fUsers._dataTable.Rows.Count;
                        row["username"] = user.username;
                        row["fullname"] = user.fullname;
                        row["phone"] = user.phone;
                        row["email"] = user.email;
                        row["permission"] = Service._permisstions.Find(x => x.id == user.permission).name;
                        row["create"] = Service.ConvertDatetime(user.createdAt);
                        fUsers._dataTable.Rows.Add(row);

                    }

                    if (valuaFind.Equals("username") && user.username.ToLower().Contains(content.ToLower()))
                    {
                        // Insert table
                        DataRow row = fUsers._dataTable.NewRow();
                        row["stt"] = fUsers._dataTable.Rows.Count;
                        row["username"] = user.username;
                        row["fullname"] = user.fullname;
                        row["phone"] = user.phone;
                        row["email"] = user.email;
                        row["permission"] = Service._permisstions.Find(x => x.id == user.permission).name;
                        row["create"] = Service.ConvertDatetime(user.createdAt);
                        fUsers._dataTable.Rows.Add(row);
                    }

                    if (valuaFind.Equals("email") && user.email.ToLower().Contains(content.ToLower()))
                    {
                        // Insert table
                        DataRow row = fUsers._dataTable.NewRow();
                        row["stt"] = fUsers._dataTable.Rows.Count;
                        row["username"] = user.username;
                        row["fullname"] = user.fullname;
                        row["phone"] = user.phone;
                        row["email"] = user.email;
                        row["permission"] = Service._permisstions.Find(x => x.id == user.permission).name;
                        row["create"] = Service.ConvertDatetime(user.createdAt);
                        fUsers._dataTable.Rows.Add(row);
                    }
                }
            }
        }
        public async Task GetUsers() 
        { 
            Service._listUsers = await _userRepository.GetUserAsync();
            if (Service._listUsers != null) 
            {
                foreach (var user in Service._listUsers) 
                {
                    DataRow row = fUsers._dataTable.NewRow();
                    row["stt"] = fUsers._dataTable.Rows.Count;
                    row["username"] = user.username; 
                    row["fullname"] = user.fullname;
                    row["phone"] = user.phone;
                    row["email"] = user.email;
                    row["permission"] = Service._permisstions.Find(x => x.id == user.permission).name;
                    row["create"] = Service.ConvertDatetime(user.createdAt);
                    fUsers._dataTable.Rows.Add(row);
                }
            }

        }

        public async Task InsertUser(string fullname, string username, string email, string phone, int permission,string password)
        {
            var data = new { fullname, username, email, phone, permission , password };    
            var user = await _userRepository.RegisterUser(data);
            if (user != null && user.status == 1) 
            {
                Service._listUsers.Clear();
                fUsers._dataTable.Rows.Clear();
                GetUsers();
            }
            else
            {
                MessageBox.Show(user.message);
            }
        }

        public async Task EditUser(string fullname, string username, string email, string phone, int permission)
        {
            var data = new { fullname, username, email, phone, permission };
            var user = await _userRepository.EditUser(data);
            if (user != null && user.status == 1)
            {
                Service._listUsers.Clear();
                fUsers._dataTable.Rows.Clear();
                GetUsers();
            }
            else
            {
                MessageBox.Show(user.message);
            }
        }

        public async Task DeleteUser( string username)
        {
           
            var user = await _userRepository.DeleteUser(username);
            if (user != null && user.status == 1)
            {
                Service._listUsers.Clear();
                fUsers._dataTable.Rows.Clear();
                GetUsers();
            }
            else
            {
                MessageBox.Show(user.message);
            }
        }
    }
}
