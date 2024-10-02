using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManage.Model
{
    public class BookManage
    {
        public string masv { get; set; }
        public string name { get; set; }
        public string nameclass { get; set; }
        public string phone { get; set; }
        public string bookborrow { get; set; }
        public string quantity { get; set; }
        public DateTime dateborrow { get; set; }
        public DateTime daterepay { get; set; }
        public int status { get; set; }

        public BookManage() { }

    }
}
