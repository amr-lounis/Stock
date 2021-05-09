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
        //-------------------------------------------------------------------------------------
        public user get(long _id)
        {
            return TableUsers_CD.Get(_id);
        }
        //-------------------------------------------------------------------------------------
        public List<user> search(string _value, ref int _this_page, out string _data_out)
        {
            try
            {
                string s = "";
                var query = TableUsers_CD.search(_value, ref _this_page, out s);
                _data_out = s;
                return query.ToList();
            }
            catch (Exception){ _data_out = ""; return null; }
        }
        //-------------------------------------------------------------------------------------
        public int add(user _user)
        {
            TableUsers_CD.Add(_user);
            return 1;
        }
        //-------------------------------------------------------------------------------------
        public int edit(user _user)
        {
            TableUsers_CD.Edit(_user);
            return 1;
        }
        //-------------------------------------------------------------------------------------
        public int delete(user _user)
        {
            TableUsers_CD.Delete(_user.ID);
            return 1;
        }
        //-------------------------------------------------------------------------------------
    }
}
