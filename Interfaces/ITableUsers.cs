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
        List<User_M> getPage(ref int this_page);
        int add(User_M _User);
        int edit(User_M _User);
        int delete(User_M _User);
    }
}
