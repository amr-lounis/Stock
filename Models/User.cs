using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Models
{
    public class User
    {
        int a = 0, b = 999;
        static Random r = new Random();
        public User()
        {
            ID = string.Format("{0}", r.Next(a, b));
            ACTIVITY = string.Format("{0}", r.Next(a, b));
            ADDRESS = string.Format("{0}", r.Next(a, b));
            ROLE = string.Format("{0}", r.Next(a, b));
            CITY = string.Format("{0}", r.Next(a, b));
            COUNTRY = string.Format("{0}", r.Next(a, b));
            DESCRIPTION = string.Format("{0}", r.Next(a, b));
            EMAIL = string.Format("{0}", r.Next(a, b));
            FAX = string.Format("{0}", r.Next(a, b));
            MONEY_ACCOUNT = string.Format("{0}", r.Next(a, b));
            NAME = string.Format("{0}", r.Next(a, b));
            NIF = string.Format("{0}", r.Next(a, b));
            NRC = string.Format("{0}", r.Next(a, b));
            PASSWORD = string.Format("{0}", r.Next(a, b));
            PHONE = string.Format("{0}", r.Next(a, b));
            WEBSITE = string.Format("{0}", r.Next(a, b));
        }

        public string ID { get; set; }
        public string NAME { get; set; }
        public string PASSWORD { get; set; }
        public string ROLE { get; set; }
        public string ACTIVITY { get; set; }
        public string MONEY_ACCOUNT { get; set; }
        public string DESCRIPTION { get; set; }
        public string NRC { get; set; }
        public string NIF { get; set; }
        public string ADDRESS { get; set; }
        public string CITY { get; set; }
        public string COUNTRY { get; set; }
        public string PHONE { get; set; }
        public string FAX { get; set; }
        public string WEBSITE { get; set; }
        public string EMAIL { get; set; }
    }
}
