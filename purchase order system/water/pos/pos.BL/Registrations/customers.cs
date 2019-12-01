using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pos.DL;

namespace pos.BL.Registrations
{
    public class customers
    {
        pos.DL.Registrations.customers customerDL = new pos.DL.Registrations.customers();

        public DataTable List(string keywords)
        {
            return customerDL.List(keywords);
        }


        public long Insert(pos.EL.Registrations.customers customerEL)
        {
            return customerDL.Insert(customerEL);
        }

        public bool Update(pos.EL.Registrations.customers customerEL)
        {
            return customerDL.Update(customerEL);
        }


        public bool Delete(pos.EL.Registrations.customers customerEL)
        {
            return customerDL.Delete(customerEL);
        }
    }
}
