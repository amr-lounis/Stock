using Stock.Classes;
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
        static List<User_M> list = new List<User_M>();
        //-------------------------------------------------------------------------------------
        public User_M get(string _ID)
        {
            return list.Find(o => o.ID == _ID);
        }
        //-------------------------------------------------------------------------------------
        public List<User_M> getPage(ref int this_page)
        {
            int pageMax = 5;
            if (this_page < 0) this_page = 0;
            if (this_page > pageMax) this_page = pageMax;
            return list;
        }
        //-------------------------------------------------------------------------------------
        public int add(User_M _User)
        {
            if (_User.ID.Equals("0")) _User.ID = Helper.random();
            list.Add(_User);
            return 1;
        }
        //-------------------------------------------------------------------------------------
        public int edit(User_M _User)
        {
            var o = list.Find(x => x.ID == _User.ID);
            o.ACTIVITY = _User.ACTIVITY;
            o.ADDRESS = _User.ADDRESS;
            o.ROLE = _User.ROLE;
            o.CITY = _User.CITY;
            o.COUNTRY = _User.COUNTRY;
            o.DESCRIPTION = _User.DESCRIPTION;
            o.EMAIL = _User.EMAIL;
            o.FAX = _User.FAX;
            o.MONEY_ACCOUNT = _User.MONEY_ACCOUNT;
            o.NAME = _User.NAME;
            o.NIF = _User.NIF;
            o.NRC = _User.NRC;
            o.PASSWORD = _User.PASSWORD;
            o.PHONE = _User.PHONE;
            o.WEBSITE = _User.WEBSITE;

            list[list.FindIndex(x => x.ID == _User.ID)] = o;
            return 1;
        }
        //-------------------------------------------------------------------------------------
        public int delete(User_M _User)
        {
            list.RemoveAt(list.FindIndex(o => o.ID == _User.ID));
            return 1;
        }
        //-------------------------------------------------------------------------------------
    }
}
