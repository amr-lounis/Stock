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
        sold_product get(long _id);
        List<sold_product> searchByInvoice(long _id_invoice);
        string add(sold_product _productsold);
        string edit(sold_product _productsold);
        string edit(long _id, string _column, object _value);
        string delete(long _id);
    }
}
