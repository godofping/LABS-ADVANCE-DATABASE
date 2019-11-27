using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WATER_REFILLING_STATION.BL.REGISTRATIONS
{
    public class customers
    {
        DL.REGISTRATIONS.customers customerDL = new DL.REGISTRATIONS.customers();

        public DataTable List(string keywords)
        {
            return customerDL.List(keywords);
        }


        public long Insert(EL.REGISTRATIONS.customers customerEL)
        {
            return customerDL.Insert(customerEL);
        }


        public bool Delete(EL.REGISTRATIONS.customers customerEL)
        {
            return customerDL.Delete(customerEL);
        }

    }
}
