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
        invoicesold get(long _id);
        long GetID_NonValid();
        List<invoicesold> search(string _value,DateTime _begin,DateTime _end, ref int _this_page, out string _data_out);
        string add(invoicesold _Invoice);
        string edit(invoicesold _Invoice);
        string delete(long _id);
    }
}
