using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Interfaces
{
    interface ITableInvoices
    {
        Invoice_M get(string _ID);
        List<Invoice_M> getPage(ref int this_page);
        int add(Invoice_M _Invoice);
        int edit(Invoice_M _Invoice);
        int delete(Invoice_M _Invoice);
    }
}
