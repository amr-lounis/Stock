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
        List<Product> backward_page(int this_page);
        List<Product> forward_page(int this_page);
        Product add(Product product);
        Product edit(Product product);
        int delete(String ID);
    }
}
