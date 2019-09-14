using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pos.BL.Registrations
{
    public class Customers
    {
        public bool Insert(pos.EL.Registrations.Customers cus)
        {
            pos.DL.Registrations.Customers customerDL = new pos.DL.Registrations.Customers();
            if (customerDL.Insert(cus))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
