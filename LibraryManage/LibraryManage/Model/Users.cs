using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManage.Model
{
    public class Users
    {
        public string id {  get; set; }
        public string fullname {  get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int permission { get; set; }
        public string createdAt { get; set; }

        Users() { }
      
    }

    public class Permission
    {
        public int id { get; set; }
        public string name { get; set; }
        public Permission(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }

    public class BookStatus
    {
        public int id { get; set; }
        public string name { get; set; }
        public BookStatus(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }

}
