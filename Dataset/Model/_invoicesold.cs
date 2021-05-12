
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Dataset.Model
{
    public partial class invoicesold
    {
        public invoicesold()
        {
            ID_USERS = 1L;
            ID_CUSTOMERS = 1L;
            DESCRIPTION = "";
            DATE = "";
            VALIDATION = 0L;
            MONEY_WITHOUT_ADDEDD = 0;
            MONEY_TAX = 0;
            MONEY_STAMP = 0;
            MONEY_TOTAL = 0;
            MONEY_PAID = 0;
            MONEY_UNPAID = 0;
        }
    }
}
