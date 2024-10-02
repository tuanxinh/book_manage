using LibraryManage.Controller;
using LibraryManage.DataAccess;
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
    public class BookLibrary
    {

        private readonly BookRepository _bookRepository;



        public BookLibrary()
        {
            _bookRepository = new BookRepository();
        }

       
       
        public async Task GetBooks()
        {
            Service._books = await _bookRepository.GetBooksAsync();
            if (Service._books != null)
            {
                foreach (var user in Service._books)
                {
                    DataRow row = fBooks._dataTable.NewRow();
                    row["stt"] = fBooks._dataTable.Rows.Count;
                    row["title"] = user.title;
                    row["author"] = user.author;
                    row["category"] = user.category;
                    row["quantity"] = user.quantity;
                    row["create"] = Service.ConvertDatetime(user.createdAt);
                    fBooks._dataTable.Rows.Add(row);
                }
            }

        }
        public void FindBooks(string content, string valuaFind)
        {
            for (int i = 0; i < Service._books.Count; i++)
            {
                var user = Service._books[i];
                if (user != null)
                {
                    if (valuaFind.Equals("title") && user.title.ToLower().Contains(content.ToLower()))
                    {
                        // Insert table
                        DataRow row = fBooks._dataTable.NewRow();
                        row["stt"] = fBooks._dataTable.Rows.Count;
                        row["title"] = user.title;
                        row["author"] = user.author;
                        row["category"] = user.category;
                        row["quantity"] = user.quantity;
                        row["create"] = Service.ConvertDatetime(user.createdAt);
                        fBooks._dataTable.Rows.Add(row);

                    }

                    if (valuaFind.Equals("author") && user.author.ToLower().Contains(content.ToLower()))
                    {
                  
                        DataRow row = fBooks._dataTable.NewRow();
                        row["stt"] = fBooks._dataTable.Rows.Count;
                        row["title"] = user.title;
                        row["author"] = user.author;
                        row["category"] = user.category;
                        row["quantity"] = user.quantity;
                        row["create"] = Service.ConvertDatetime(user.createdAt);
                        fBooks._dataTable.Rows.Add(row);
                    }

                    if (valuaFind.Equals("category") && user.category.ToLower().Contains(content.ToLower()))
                    {
                        DataRow row = fBooks._dataTable.NewRow();
                        row["stt"] = fBooks._dataTable.Rows.Count;
                        row["title"] = user.title;
                        row["author"] = user.author;
                        row["category"] = user.category;
                        row["quantity"] = user.quantity;
                        row["create"] = Service.ConvertDatetime(user.createdAt);
                        fBooks._dataTable.Rows.Add(row);
                    }
                }
            }
        }
        public async Task InsertBooks(string title, string author, string category, int quantity)
        {
            var data = new { title, author, category, quantity };
            var user = await _bookRepository.AddBook(data);
            if (user != null && user.status == 1)
            {
                Service._books.Clear();
                fBooks._dataTable.Rows.Clear();
                GetBooks();
            }
            else
            {
                MessageBox.Show(user.message);
            }
        }

        public async Task EditBook(string title, string author, string category ,int quantity)
        {
            var data = new { title, author, category, quantity };
            var user = await _bookRepository.EditBook(data);
            if (user != null && user.status == 1)
            {
                Service._books.Clear();
                fBooks._dataTable.Rows.Clear();
                GetBooks();
            }
            else
            {
                MessageBox.Show(user.message);
            }
        }

        public async Task DeleteBook(string title)
        {

            var user = await _bookRepository.DeleteBook(title);
            if (user != null && user.status == 1)
            {
                Service._books.Clear();
                fBooks._dataTable.Rows.Clear();
                GetBooks();
            }
            else
            {
                MessageBox.Show(user.message);
            }
        }
    }
}
