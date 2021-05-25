using Stock.Dataset.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Interfaces
{
    interface ITableInvoices
    {
        sold_invoice get(long _id);
        long GetID_NonValid();
        List<sold_invoice> search(string _value,DateTime _begin,DateTime _end, ref int _this_page, out string _data_out);
        string add(sold_invoice _Invoice);
        string edit(sold_invoice _Invoice);
        string edit(long _id, string _column, object _value);
        string delete(long _id);
    }
}
