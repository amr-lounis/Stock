using Stock.Dataset.Model;
using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Interfaces
{
    interface ITableUsers
    {
        user get(long _id);
        List<user> search(string _value, ref int _this_page);
        int add(user _user);
        int edit(user _user);
        int delete(user _user);
    }
}
