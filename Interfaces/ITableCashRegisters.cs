using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Interfaces
{
    interface ITableCashRegisters
    {
        CashRegister_M get(string _ID);
        List<CashRegister_M> getAll();
        int add(CashRegister_M _CashRegister);
        int edit(CashRegister_M _CashRegister);
        int delete(CashRegister_M _CashRegister);
    }
}
