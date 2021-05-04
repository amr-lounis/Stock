using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Interfaces
{
    public interface ITableProduct
    {
        int add(Product _Product);
        int edit(Product _Product);
        List<Product> getPage(ref int this_page);
        int delete(Product _Product);
    }
}
