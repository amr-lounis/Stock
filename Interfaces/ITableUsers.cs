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
        List<User> page(ref int this_page);
        User add(User user);
        User edit(User user);
        int delete(string ID);
    }
}
