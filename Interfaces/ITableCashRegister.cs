using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Interfaces
{
    interface ITableCashRegister
    {
        int add(CashRegister _CashRegister);
        int edit(CashRegister _CashRegister);
        List<CashRegister> getAll();
        int delete(CashRegister _CashRegister);
    }
}
