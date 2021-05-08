using Stock.Dataset.Model;
using Stock.Interfaces;
using Stock.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Controllers
{
    public class TableUsers_CV : ITableUsers
    {
        static List<User_M> list = new List<User_M>();
        //-------------------------------------------------------------------------------------
        public User_M get(string _ID)
        {
            return list.Find(o => o.ID == _ID);
        }
        //-------------------------------------------------------------------------------------
        public List<User_M> search(string _value, ref int _this_page)
        {
            string data_out = "";
            List<user> l = TableUsers_CD.search("",ref _this_page,out  data_out).ToList();
            foreach (user _user in l)
            {
                list.Add(adaptor(_user));
            }
            int pageMax = 5;
            if (_this_page < 0) _this_page = 0;
            if (_this_page > pageMax) _this_page = pageMax;
            return list;
        }
        //-------------------------------------------------------------------------------------
        public int add(User_M _User)
        {

            try
            {
                Entities _db = Entities.GetInstance();
                string s = _db.roles.Single(c => c.ID == 1).NAME;
                Console.WriteLine(s);
                //_db.roles.Remove(_db.roles.Single(c => c.ID == 1));
                //_db.SaveChangesAsync();
                //Console.WriteLine(_db.Database.Exists());
                user t = new user
                {
                    ID = 1,
                    ID_ROLE = null,
                    

                };
                _db.users.Add(t);
                _db.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

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
        public User_M adaptor(user _user)
        {
            var o = new User_M();
            o.ACTIVITY = _user.ACTIVITY;
            o.ADDRESS = _user.ADDRESS;
            o.ROLE = _user.ID_ROLE+"";
            o.CITY = _user.CITY;
            o.COUNTRY = _user.COUNTRY;
            o.DESCRIPTION = _user.DESCRIPTION;
            o.EMAIL = _user.EMAIL;
            o.FAX = _user.FAX;
            o.MONEY_ACCOUNT = _user.MONEY_ACCOUNT+"";
            o.NAME = _user.NAME;
            o.NIF = _user.NIF;
            o.NRC = _user.NRC;
            o.PASSWORD = _user.PASSWORD;
            o.PHONE = _user.PHONE;
            o.WEBSITE = _user.WEBSITE;
            return o;
        }
    }
}
