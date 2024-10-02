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
    public class BookManageLibrary
    {
        private BookManageRepository _bookManageRepository = new BookManageRepository();


        public async Task GetManage()
        {
            Service._bookManage = await _bookManageRepository.getManage();
            if (Service._bookManage != null)
            {
                foreach (var user in Service._bookManage)
                {
                    DataRow row = fManage._dataTable.NewRow();
                    row[0] = fManage._dataTable.Rows.Count;
                    row[1] = user.masv;
                    row[2] = user.name;
                    row[3] = user.phone;
                    row[4] = user.nameclass;
                    row[5] = user.bookborrow;
                    row[6] = user.quantity;
                    row[7] = user.dateborrow;
     
                    //
                    if (user.daterepay == user.dateborrow)
                    {
                        row[8] = "Chưa trả";
                    }
                    else
                    {
                        row[8] = user.daterepay;
                    }
                    row[9] = Service.getBookStatus(user.status);

                    fManage._dataTable.Rows.Add(row);
                }
            }

        }

        public void FindBooks(string content, string valuaFind)
        {
            for (int i = 0; i < Service._bookManage.Count; i++)
            {
                var user = Service._bookManage[i];
                if (user != null)
                {
                    if (valuaFind.Equals("masv") && user.masv.ToLower().Contains(content.ToLower()))
                    {
                        // Insert table
                        DataRow row = fManage._dataTable.NewRow();
                        row[0] = fManage._dataTable.Rows.Count;
                        row[1] = user.masv;
                        row[2] = user.name;
                        row[3] = user.phone;
                        row[4] = user.nameclass;
                        row[5] = user.bookborrow;
                        row[6] = user.quantity;
                        row[7] = user.dateborrow;
                        if (user.daterepay == user.dateborrow)
                        {
                            row[8] = "Chưa trả";
                        }
                        else
                        {
                            row[8] = user.daterepay;
                        }
                        row[9] = Service.getBookStatus(user.status);
                        fManage._dataTable.Rows.Add(row);

                    }

                    if (valuaFind.Equals("name") && user.name.ToLower().Contains(content.ToLower()))
                    {

                        DataRow row = fManage._dataTable.NewRow();
                        row[0] = fManage._dataTable.Rows.Count;
                        row[1] = user.masv;
                        row[2] = user.name;
                        row[3] = user.phone;
                        row[4] = user.nameclass;
                        row[5] = user.bookborrow;
                        row[6] = user.quantity;
                        row[7] = user.dateborrow;
                        if (user.daterepay == user.dateborrow)
                        {
                            row[8] = "Chưa trả";
                        }
                        else
                        {
                            row[8] = user.daterepay;
                        }
                        row[9] = Service.getBookStatus(user.status);

                        fManage._dataTable.Rows.Add(row);
                    }

                    if (valuaFind.Equals("phone") && user.phone.ToLower().Contains(content.ToLower()))
                    {
                        DataRow row = fManage._dataTable.NewRow();
                        row[0] = fManage._dataTable.Rows.Count;
                        row[1] = user.masv;
                        row[2] = user.name;
                        row[3] = user.phone;
                        row[4] = user.nameclass;
                        row[5] = user.bookborrow;
                        row[6] = user.quantity;
                        row[7] = user.dateborrow;
                        if (user.daterepay == user.dateborrow)
                        {
                            row[8] = "Chưa trả";
                        }
                        else
                        {
                            row[8] = user.daterepay;
                        }
                        row[9] = Service.getBookStatus(user.status);
                        fManage._dataTable.Rows.Add(row);
                    }
                }
            }
        }
        public async Task InsertManage(object data)
        {
           
            var user = await _bookManageRepository.InsertManage(data);
            if (user != null && user.status == 1)
            {
                Service._bookManage.Clear();
                fManage._dataTable.Rows.Clear();
                GetManage();
            }
            else
            {
                MessageBox.Show(user.message);
            }
        }
        public async Task DeleteBook(string data)
        {

            var user = await _bookManageRepository.DeleteManage(data);
            if (user != null && user.status == 1)
            {
                Service._bookManage.Clear();
                fManage._dataTable.Rows.Clear();
                GetManage();
            }
            else
            {
                MessageBox.Show(user.message);
            }
        }
        public async Task EditManage(object data)
        {

            var user = await _bookManageRepository.EditManage(data);
            if (user != null && user.status == 1)
            {
                Service._bookManage.Clear();
                fManage._dataTable.Rows.Clear();
                GetManage();
            }
            else
            {
                MessageBox.Show(user.message);
            }
        }
    }
}
