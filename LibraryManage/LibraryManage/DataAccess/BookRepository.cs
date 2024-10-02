using DataRequestHelperLibrary;
using LibraryManage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LibraryManage.DataAccess
{
    public class BookRepository
    {
        private readonly DataRequestHelper _dataRequestHelper;

        private readonly string _baseAdress = "http://localhost:3001/";
        public BookRepository()
        {
            _dataRequestHelper = new DataRequestHelper(_baseAdress);
        }
        public async Task<List<Books>> GetBooksAsync()
        {
            List<Books> books = new List<Books>();
            books = await _dataRequestHelper.GetJsonDataAsync<List<Books>>("books/get");
            return books;
        }
        public async Task<MessBooks> AddBook(object data)
        {
            try
            {
                var response = await _dataRequestHelper.PostJsonDataAsync<MessBooks>("books/register", data);
                return response;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public async Task<MessBooks> EditBook(object data)
        {
            try
            {
                var response = await _dataRequestHelper.PutJsonDataAsync<MessBooks>("books/edit", data);
                return response;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public async Task<MessBooks> DeleteBook(string title)
        {
            try
            {
                var response = await _dataRequestHelper.DeleteJsonDataAsync<MessBooks>($"books/del/{title}");
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
