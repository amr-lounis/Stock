using Stock.Interfaces;
using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.C
{
    public class CTableProducts : ITableProduct
    {
        public Product add(Product product)
        {
            return new Product();
        }

        public List<Product> backward_page(int this_page)
        {
            return new List<Product>();
        }

        public int delete(int ID)
        {
            return 0;
        }

        public Product edit(Product product)
        {
            return new Product();
        }

        public List<Product> forward_page(int this_page)
        {
            return new List<Product>();
        }
    }
}
