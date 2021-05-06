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
        Product_M get(string _ID);
        List<Product_M> getPage(ref int this_page);
        int add(Product_M _Product);
        int edit(Product_M _Product);
        int delete(Product_M _Product);
    }
}
