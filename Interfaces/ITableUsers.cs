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
        List<User> getPage(ref int this_page);
        int add(User _User);
        int edit(User _User);
        int delete(User _User);
    }
}
