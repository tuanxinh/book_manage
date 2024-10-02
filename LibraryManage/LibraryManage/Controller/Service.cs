using LibraryManage.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManage.Controller
{
    public class Service
    {
        public static Users _users;
        public static List<Users> _listUsers = new List<Users>();
        public static List<Books> _books = new List<Books>();
        public static List<BookManage> _bookManage = new List<BookManage>();

        public static string getPermission(int id)
        {
            return _permisstions.Find(x => x.id == id).name;
        }
        public static string getBookStatus(int id)
        {
            return _bookStatus.Find(x => x.id == id).name;
        }

        public static List<Permission> _permisstions = new List<Permission>
        {
            new Permission(0, ""),
            new Permission(99, "Admin"),
            new Permission(1, "Thủ thư"),
        };
        public static List<BookStatus> _bookStatus = new List<BookStatus>
        {
            new BookStatus(-1, ""),
            new BookStatus(0, "Đang mượn"),
            new BookStatus(1, "Đã trả"),
        };
        public static string ConvertDatetime(string date)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.Parse(date, null, DateTimeStyles.RoundtripKind);
            DateTime dateTimeInVietnam = dateTimeOffset.ToOffset(TimeSpan.FromHours(7)).DateTime;
            string formattedDateTime = dateTimeInVietnam.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            return formattedDateTime;
        }
    }
}
