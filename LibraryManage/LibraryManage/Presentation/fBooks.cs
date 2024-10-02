using LibraryManage.BusinessLogic;
using LibraryManage.Controller;
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
    public partial class fBooks : Form
    {
        private BookLibrary _bookLibrary;
        public fBooks()
        {
            InitializeComponent();

            dtgvBooks.DataSource = _dataTable;  
            _bookLibrary = new BookLibrary();
        }
        public static void LoadTable()
        {
            _dataTable.Columns.Add("stt");
            _dataTable.Columns.Add("title");
            _dataTable.Columns.Add("author");
            _dataTable.Columns.Add("category");
            _dataTable.Columns.Add("quantity");
            _dataTable.Columns.Add("create");
        }
        public static DataTable _dataTable = new DataTable();
        private void button1_Click(object sender, EventArgs e)
        {
            string title = this.txt_title.Text;
            string author = this.txt_author.Text;
            string category = this.txt_category.Text;
            int quantity = int.Parse(this.txt_quantity.Text);
           
            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(author) && !string.IsNullOrEmpty(category) && quantity > 0)
            {
                _bookLibrary.InsertBooks(title, author, category, quantity);
            }
            else
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
            }
        }

        private void fBooks_Load(object sender, EventArgs e)
        {
            _dataTable.Rows.Clear();
            _bookLibrary.GetBooks();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string title = this.txt_title.Text;
            string author = this.txt_author.Text;
            string category = this.txt_category.Text;
            int quantity = int.Parse(this.txt_quantity.Text);


            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(author) && !string.IsNullOrEmpty(category) && quantity > 0)
            {
                _bookLibrary.EditBook(title, author, category, quantity);
            }
            else
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string title = this.txt_title.Text;

            if (!string.IsNullOrEmpty(title))
            {
                _bookLibrary.DeleteBook(title);
            }
            else
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
            }
        }

        private void dtgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dtgvBooks.SelectedRows;
            if (selectedRows.Count > 0)
            {
                for (int i = 0; i < selectedRows.Count; i++)
                {
                    this.txt_title.Text = _dataTable.Rows[selectedRows[i].Index][1].ToString();
                    this.txt_author.Text = _dataTable.Rows[selectedRows[i].Index][2].ToString();
                    this.txt_category.Text = _dataTable.Rows[selectedRows[i].Index][3].ToString();
                    this.txt_quantity.Text = _dataTable.Rows[selectedRows[i].Index][4].ToString();
                   
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string content = txt_content.Text;
            if (string.IsNullOrEmpty(content))
            {
                _dataTable.Rows.Clear();
                _bookLibrary.GetBooks();
                return;
            }
            string _findBy = "title";
            if (radioButton2.Checked)
            {
                _findBy = "author";
            }
            if (radioButton3.Checked)
            {
                _findBy = "category";
            }
            _dataTable.Rows.Clear();
            _bookLibrary.FindBooks(content, _findBy);
        }
    }
}
