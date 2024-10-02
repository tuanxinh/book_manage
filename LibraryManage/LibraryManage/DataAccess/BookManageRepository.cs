
using LibraryManage.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataRequestHelperLibrary;
namespace LibraryManage.DataAccess
{
    public class BookManageRepository
    {
        private DataRequestHelper _requestHelper;
        private readonly string _baseAdress = "http://localhost:3001/";
        public BookManageRepository()
        {
            _requestHelper = new DataRequestHelper(_baseAdress);
        }
        public async Task<MessBooks> InsertManage(object value)
        {
            try
            {
                var data = await _requestHelper.PostJsonDataAsync<MessBooks>("manage/register", value);
                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public async Task<MessBooks> DeleteManage(string masv)
        {
            try
            {
                var data = await _requestHelper.DeleteJsonDataAsync<MessBooks>($"manage/del/{masv}");
                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        public async Task<MessBooks> EditManage(object value)
        {
            try
            {
                var data = await _requestHelper.PutJsonDataAsync<MessBooks>("manage/edit", value);
                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        public async Task<List<BookManage>> getManage()
        {
            try
            {
                var data = await _requestHelper.GetJsonDataAsync<List<BookManage>>("manage/get");
                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
