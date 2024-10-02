using LibraryManage.BusinessLogic;
using LibraryManage.Controller;
using LibraryManage.DataAccess;
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
    public partial class fManage : Form
    {
        private BookRepository _bookRepository = new BookRepository();
        private BookManageLibrary _bookManageLibrary;
        public fManage()
        {
            InitializeComponent();
      


            dtgvManage.DataSource = _dataTable;
            _bookManageLibrary = new BookManageLibrary();

        }
        public static void Loadtable()
        {

            _dataTable.Columns.Add("stt");
            _dataTable.Columns.Add("masv");
            _dataTable.Columns.Add("name");
            _dataTable.Columns.Add("phone");
            _dataTable.Columns.Add("class");
            _dataTable.Columns.Add("bookborrow");
            _dataTable.Columns.Add("quantity");
            _dataTable.Columns.Add("dateborrow");
            _dataTable.Columns.Add("daterepay");
            _dataTable.Columns.Add("status");
        }
        public static DataTable _dataTable = new DataTable();
        private async void fManage_Load(object sender, EventArgs e)
        {
            Service._books = await _bookRepository.GetBooksAsync();

            var books = Service._books;
            foreach(var item in books)
            {
                cb_books.Items.Add(item.title);
            }
            var manage = Service._bookStatus;
            foreach (var item2 in manage)
            {
                cb_bookstatus.Items.Add(item2.name);
            }

            _bookManageLibrary.GetManage();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string masv = this.txt_masv.Text;
            string name = this.txt_name.Text;
            string phone = this.txt_phone.Text;
            string nameclass = txt_class.Text;
            string bookborrow = cb_books.Text;
            int quantity = int.Parse(this.txt_quantity.Text);
            string dateborrow = date_borrow.Text;
            string daterepay = date_borrow.Text;
            int status = Service._bookStatus.Find(x => x.name.Equals(cb_bookstatus.Text)).id;
            var data = new
            {
                masv,
                name,
                nameclass, phone,
                bookborrow, quantity, dateborrow,
                daterepay, status
            };
            if (!string.IsNullOrEmpty(masv) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(dateborrow) && quantity > 0)
            {
                _bookManageLibrary.InsertManage(data);
            }
            else
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
            }
        }

        private void dtgvManage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dtgvManage.SelectedRows;
            if (selectedRows.Count > 0)
            {
                for (int i = 0; i < selectedRows.Count; i++)
                {
                    this.txt_masv.Text = _dataTable.Rows[selectedRows[i].Index][1].ToString();
                    this.txt_name.Text = _dataTable.Rows[selectedRows[i].Index][2].ToString();
                    this.txt_phone.Text = _dataTable.Rows[selectedRows[i].Index][3].ToString();
                    this.txt_class.Text = _dataTable.Rows[selectedRows[i].Index][4].ToString();
                    this.cb_books.Text = _dataTable.Rows[selectedRows[i].Index][5].ToString();
                    this.txt_quantity.Text = _dataTable.Rows[selectedRows[i].Index][6].ToString();
                    this.date_borrow.Text = _dataTable.Rows[selectedRows[i].Index][7].ToString();
                    this.cb_bookstatus.Text =  _dataTable.Rows[selectedRows[i].Index][9].ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string masv = this.txt_masv.Text;
            string name = this.txt_name.Text;
            string phone = this.txt_phone.Text;
            string nameclass = txt_class.Text;
            string bookborrow = cb_books.Text;
            int quantity = int.Parse(this.txt_quantity.Text);
            string dateborrow = date_borrow.Text;
            string daterepay = date_borrow.Text;
            int status = Service._bookStatus.Find(x => x.name.Equals(cb_bookstatus.Text)).id;
           
            if (!string.IsNullOrEmpty(masv) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(dateborrow) && quantity > 0)
            {
                var data = new
                {
                    masv,
                    name,
                    nameclass,
                    phone,
                    bookborrow,
                    quantity,
                    dateborrow,
                    daterepay,
                    status
                };

                _bookManageLibrary.EditManage(data);
            }
            else
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
            }
        }

        private void dtgvManage_CellValueChanged(object sender, DataGridViewCellEventArgs e) {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string masv = this.txt_masv.Text;

            if (!string.IsNullOrEmpty(masv))
            {
                _bookManageLibrary.DeleteBook(masv);
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
                _bookManageLibrary.GetManage();
                return;
            }
            string _findBy = "masv";
            if (radioButton2.Checked)
            {
                _findBy = "name";
            }
            if (radioButton3.Checked)
            {
                _findBy = "phone";
            }
            _dataTable.Rows.Clear();
            _bookManageLibrary.FindBooks(content, _findBy);
        }
    }
}
