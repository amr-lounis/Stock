using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Interfaces
{
    public interface ITableProducts
    {
        int add(Product_M _Product);
        int edit(Product_M _Product);
        List<Product_M> getPage(ref int this_page);
        int delete(Product_M _Product);
    }
}
