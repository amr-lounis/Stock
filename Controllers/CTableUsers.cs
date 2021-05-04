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
        List<User> list = new List<User>();
        //-------------------------------------------------------------------------------------
        public int add(User user)
        {
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
            list.Add(o);
            return 1;
        }
        //-------------------------------------------------------------------------------------
        public int edit(User user)
        {
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
            list[list.FindIndex(x => x.ID == user.ID)] = o;
            return 1;
        }
        //-------------------------------------------------------------------------------------
        public List<User> getPage(ref int this_page)
        {
            int pageMax = 5;
            if (this_page < 0) this_page = 0;
            if (this_page > pageMax) this_page = pageMax;
            return list;
        }
        //-------------------------------------------------------------------------------------
        public int delete(User _User)
        {
            list.RemoveAt(list.FindIndex(o => o.ID == _User.ID));
            return 1;
        }
        //-------------------------------------------------------------------------------------
    }
}
