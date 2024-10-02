using DataRequestHelperLibrary;
using LibraryManage.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManage.DataAccess
{
    public class UserRepository
    {
        private readonly DataRequestHelper _dataRequestHelper;

        private readonly string _baseAdress = "http://localhost:3001/";
        public UserRepository()
        {
            _dataRequestHelper = new DataRequestHelper(_baseAdress);
        }

        public async Task<MessUsers> LoginAsync(string username, string password)
        {
            try
            {
                var loginData = new { username, password };
                var response = await _dataRequestHelper.PostJsonDataAsync<MessUsers>("users/login", loginData);
                return response;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public async Task<List<Users>> GetUserAsync()
        {
            List<Users> users = new List<Users>();
            users = await _dataRequestHelper.GetJsonDataAsync<List<Users>>("users/get");
            return users;
        }

        public async Task<MessUsers> RegisterUser(object data)
        {
            try
            {
                var response = await _dataRequestHelper.PostJsonDataAsync<MessUsers>("users/register", data);
                return response;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }


        public async Task<MessUsers> EditUser(object data)
        {
            try
            {
                var response = await _dataRequestHelper.PutJsonDataAsync<MessUsers>("users/edit", data);
                return response;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public async Task<MessUsers> DeleteUser(string username)
        {
            try
            {
              
                var response = await _dataRequestHelper.DeleteJsonDataAsync<MessUsers>($"users/del/{username}");
                return response;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
