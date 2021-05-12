using Stock.Dataset.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Interfaces
{
    interface ITableCashRegisters
    {
        productsold get(long _id);
        List<productsold> search(long _id_invoice, out double _sum);
        string add(productsold _productsold);
        string edit(productsold _productsold);
        string delete(long _id);
    }
}
