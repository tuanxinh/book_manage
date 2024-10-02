using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManage.Model
{
    public class MessUsers
    {
        public int status { get; set; }

        public string message { get; set; }

        public Users users { get; set; }

        MessUsers() { }
    }

    public class MessBooks
    {
        public int status { get; set; }

        public string message { get; set; }

        MessBooks() { }
    }
}
