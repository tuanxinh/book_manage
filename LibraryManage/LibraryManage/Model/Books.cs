using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManage.Model
{
    public class Books
    {
        public int id {  get; set; }

        public string title { get; set; }

        public string author { get; set; }

        public string category { get; set; }

        public int quantity { get; set; }

        public string createdAt { get; set; }

        Books() { }
    }
}
