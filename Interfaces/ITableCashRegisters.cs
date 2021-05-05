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
        int add(CashRegister_M _CashRegister);
        int edit(CashRegister_M _CashRegister);
        List<CashRegister_M> getAll();
        int delete(CashRegister_M _CashRegister);
    }
}
