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
        productsold get(int _id);
        List<productsold> getAll();
        int add(productsold _CashRegister);
        int edit(productsold _CashRegister);
        int delete(productsold _CashRegister);
    }
}
