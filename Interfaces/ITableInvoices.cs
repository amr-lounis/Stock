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
        soldinvoice get(long _id);
        List<soldinvoice> search(string _value,DateTime _begin,DateTime _end, ref int _this_page, out string _data_out);
        int add(soldinvoice _Invoice);
        int edit(soldinvoice _Invoice);
        int delete(soldinvoice _Invoice);
    }
}
