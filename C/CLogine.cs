﻿using Stock.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.C
{
    public class CLogin : ILogin
    {
        public bool Login(string p_user, string p_password)
        {
            return ((p_user == "admin") && (p_password == "admin")) ? true : false;  
        }
    }
}
