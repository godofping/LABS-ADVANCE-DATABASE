using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.BL.Registrations
{
    public class customers
    {
        DL.Registrations.customers customerDL = new DL.Registrations.customers();

        public DataTable List(string keywords)
        {
            return customerDL.List(keywords);
        }

        public EL.Registrations.customers Select(EL.Registrations.customers customerEL)
        {
            return customerDL.Select(customerEL);
        }

        public long Insert(EL.Registrations.customers customerEL)
        {
            return customerDL.Insert(customerEL);
        }

        public bool Update(EL.Registrations.customers customerEL)
        {
            return customerDL.Update(customerEL);
        }

        public bool Delete(EL.Registrations.customers customerEL)
        {
            return customerDL.Delete(customerEL);
        }
    }
}
