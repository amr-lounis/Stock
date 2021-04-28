using Stock.Interfaces;
using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Controllers
{
    public class CTableUsers : ITableUsers
    {
        int a = 0, b = 999;
        Random r = new Random();
        //-------------------------------------------------------------------------------------
        public List<User> page(ref int this_page)
        {
            Console.WriteLine("backward_page");
            List<User> lo = new List<User>();
            for (int i = 0; i < 10; i++) lo.Add(new User
            {
                ID = string.Format("{0}", r.Next(a, b)),
                ACTIVITY = string.Format("{0}", r.Next(a, b)),
                ADDRESS = string.Format("{0}", r.Next(a, b)),
                ROLE = string.Format("{0}", r.Next(a, b)),
                CITY = string.Format("{0}", r.Next(a, b)),
                COUNTRY = string.Format("{0}", r.Next(a, b)),
                DESCRIPTION = string.Format("{0}", r.Next(a, b)),
                EMAIL = string.Format("{0}", r.Next(a, b)),
                FAX = string.Format("{0}", r.Next(a, b)),
                MONEY_ACCOUNT = string.Format("{0}", r.Next(a, b)),
                NAME = string.Format("{0}", r.Next(a, b)),
                NIF = string.Format("{0}", r.Next(a, b)),
                NRC = string.Format("{0}", r.Next(a, b)),
                PASSWORD = string.Format("{0}", r.Next(a, b)),
                PHONE = string.Format("{0}", r.Next(a, b)),
                WEBSITE = string.Format("{0}", r.Next(a, b)),
            });
            Console.WriteLine(this_page);
            int pageMax = 5;
            if (this_page < 0) this_page = 0;
            if (this_page > pageMax) this_page = pageMax;
            return lo;
        }
        //-------------------------------------------------------------------------------------
        public User add(User user)
        {
            Console.WriteLine("add");
            User o = new User
            {
                ID = string.Format("{0}", r.Next(a, b)),
                ACTIVITY = string.Format("{0}", r.Next(a, b)),
                ADDRESS = string.Format("{0}", r.Next(a, b)),
                ROLE = string.Format("{0}", r.Next(a, b)),
                CITY = string.Format("{0}", r.Next(a, b)),
                COUNTRY = string.Format("{0}", r.Next(a, b)),
                DESCRIPTION = string.Format("{0}", r.Next(a, b)),
                EMAIL = string.Format("{0}", r.Next(a, b)),
                FAX = string.Format("{0}", r.Next(a, b)),
                MONEY_ACCOUNT = string.Format("{0}", r.Next(a, b)),
                NAME = string.Format("{0}", r.Next(a, b)),
                NIF = string.Format("{0}", r.Next(a, b)),
                NRC = string.Format("{0}", r.Next(a, b)),
                PASSWORD = string.Format("{0}", r.Next(a, b)),
                PHONE = string.Format("{0}", r.Next(a, b)),
                WEBSITE = string.Format("{0}", r.Next(a, b)),
            };
            return o;
        }
        //-------------------------------------------------------------------------------------
        public User edit(User user)
        {
            Console.WriteLine("edit");
            User o = new User
            {
                ID = string.Format("{0}", r.Next(a, b)),
                ACTIVITY = string.Format("{0}", r.Next(a, b)),
                ADDRESS = string.Format("{0}", r.Next(a, b)),
                ROLE = string.Format("{0}", r.Next(a, b)),
                CITY = string.Format("{0}", r.Next(a, b)),
                COUNTRY = string.Format("{0}", r.Next(a, b)),
                DESCRIPTION = string.Format("{0}", r.Next(a, b)),
                EMAIL = string.Format("{0}", r.Next(a, b)),
                FAX = string.Format("{0}", r.Next(a, b)),
                MONEY_ACCOUNT = string.Format("{0}", r.Next(a, b)),
                NAME = string.Format("{0}", r.Next(a, b)),
                NIF = string.Format("{0}", r.Next(a, b)),
                NRC = string.Format("{0}", r.Next(a, b)),
                PASSWORD = string.Format("{0}", r.Next(a, b)),
                PHONE = string.Format("{0}", r.Next(a, b)),
                WEBSITE = string.Format("{0}", r.Next(a, b)),
            };
            return o;
        }
        //-------------------------------------------------------------------------------------
        public int delete(String ID)
        {
            Console.WriteLine("delete:"+ID);
            return 1;
        }
        //-------------------------------------------------------------------------------------
    }
}
