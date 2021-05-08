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
                    NAME = "admin"
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
    }
}
