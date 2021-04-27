using Stock.Interfaces;
using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.C
{
    public class CUsers : ITableUsers
    {
        int a = 0, b = 999;
        Random r = new Random();
        public User add(User user)
        {
            Console.WriteLine("add");
            User o = new User
            {
                ID = "" + r.Next(a, b),
                ACTIVITY = "" + r.Next(a, b),
                ADDRESS = "" + r.Next(a, b),
                CATEGORY = "" + r.Next(a, b),
                CITY = "" + r.Next(a, b),
                COUNTRY = "" + r.Next(a, b),
                DESCRIPTION = "" + r.Next(a, b),
                EMAIL = "" + r.Next(a, b),
                FAX = "" + r.Next(a, b),
                MONEY_ACCOUNT = "" + r.Next(a, b),
                NAME = "" + r.Next(a, b),
                NIF = "" + r.Next(a, b),
                NRC = "" + r.Next(a, b),
                PASSWORD = "" + r.Next(a, b),
                PHONE = "" + r.Next(a, b),
                WEBSITE = "" + r.Next(a, b),
            };
            return o;
        }

        public List<User> backward_page(int this_page)
        {
            Console.WriteLine("backward_page");
            List<User> lo = new List<User>();
            for (int i = 0; i < 10; i++) lo.Add(new User
            {
                ID = "" + r.Next(a, b),
                ACTIVITY = "" + r.Next(a, b),
                ADDRESS = "" + r.Next(a, b),
                CATEGORY = "" + r.Next(a, b),
                CITY = "" + r.Next(a, b),
                COUNTRY = "" + r.Next(a, b),
                DESCRIPTION = "" + r.Next(a, b),
                EMAIL = "" + r.Next(a, b),
                FAX = "" + r.Next(a, b),
                MONEY_ACCOUNT = "" + r.Next(a, b),
                NAME = "" + r.Next(a, b),
                NIF = "" + r.Next(a, b),
                NRC = "" + r.Next(a, b),
                PASSWORD = "" + r.Next(a, b),
                PHONE = "" + r.Next(a, b),
                WEBSITE = "" + r.Next(a, b),
            });
            return lo;
        }

        public int delete(String ID)
        {
            Console.WriteLine("delete:"+ID);
            return 1;
        }

        public User edit(User user)
        {
            Console.WriteLine("edit");
            User o = new User
            {
                ID = "" + r.Next(a, b),
                ACTIVITY = "" + r.Next(a, b),
                ADDRESS = "" + r.Next(a, b),
                CATEGORY = "" + r.Next(a, b),
                CITY = "" + r.Next(a, b),
                COUNTRY = "" + r.Next(a, b),
                DESCRIPTION = "" + r.Next(a, b),
                EMAIL = "" + r.Next(a, b),
                FAX = "" + r.Next(a, b),
                MONEY_ACCOUNT = "" + r.Next(a, b),
                NAME = "" + r.Next(a, b),
                NIF = "" + r.Next(a, b),
                NRC = "" + r.Next(a, b),
                PASSWORD = "" + r.Next(a, b),
                PHONE = "" + r.Next(a, b),
                WEBSITE = "" + r.Next(a, b),
            };
            return o;
        }

        public List<User> forward_page(int this_page)
        {
            Console.WriteLine("forward_page");
            List<User> lo = new List<User>();
            for (int i = 0; i < 10; i++) lo.Add(new User
            {
                ID = "" + r.Next(a, b),
                ACTIVITY = "" + r.Next(a, b),
                ADDRESS = "" + r.Next(a, b),
                CATEGORY = "" + r.Next(a, b),
                CITY = "" + r.Next(a, b),
                COUNTRY = "" + r.Next(a, b),
                DESCRIPTION = "" + r.Next(a, b),
                EMAIL = "" + r.Next(a, b),
                FAX = "" + r.Next(a, b),
                MONEY_ACCOUNT = "" + r.Next(a, b),
                NAME = "" + r.Next(a, b),
                NIF = "" + r.Next(a, b),
                NRC = "" + r.Next(a, b),
                PASSWORD = "" + r.Next(a, b),
                PHONE = "" + r.Next(a, b),
                WEBSITE = "" + r.Next(a, b),
            });
            return lo;
        }
    }
}
