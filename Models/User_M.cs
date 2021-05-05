using Stock.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Models
{
    public class User_M
    {
        public User_M()
        {
            ID = "0";
            NAME = Helper.random();
            GENDER = Helper.random();
            PASSWORD = Helper.random();
            ROLE = Helper.random();
            ACTIVITY = Helper.random();
            MONEY_ACCOUNT = Helper.random();
            DESCRIPTION = Helper.random();
            NRC = Helper.random();
            NIF = Helper.random();
            ADDRESS = Helper.random();
            CITY = Helper.random();
            COUNTRY = Helper.random();
            PHONE = Helper.random();
            FAX = Helper.random();
            WEBSITE = Helper.random();
            EMAIL = Helper.random();
        }

        public string ID { get; set; }
        public string NAME { get; set; }
        public string GENDER { get; set; }
        public string PASSWORD { get; set; }
        public string ROLE { get; set; }
        public string ACTIVITY { get; set; }
        public string MONEY_ACCOUNT { get; set; }
        public string DESCRIPTION { get; set; }
        public string NRC { get; set; }
        public string NIF { get; set; }
        public string ADDRESS { get; set; }
        public string CITY { get; set; }
        public string COUNTRY { get; set; }
        public string PHONE { get; set; }
        public string FAX { get; set; }
        public string WEBSITE { get; set; }
        public string EMAIL { get; set; }
    }
}
