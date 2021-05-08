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
        User_M get(string _ID);
        List<User_M> search(string _value, ref int _this_page);
        int add(User_M _User);
        int edit(User_M _User);
        int delete(User_M _User);
    }
}
