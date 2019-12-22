using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Households
    {
        DL.Registrations.Households householdDL = new DL.Registrations.Households();
        public DataTable List(String keyword)
        {
            return householdDL.List(keyword);
        }

        public EL.Registrations.Households Select(EL.Registrations.Households householdEL)
        {
            return householdDL.Select(householdEL);
        }

        public long Insert(EL.Registrations.Households householdEL)
        {
            return householdDL.Insert(householdEL);
        }

        public Boolean Update(EL.Registrations.Households householdEL)
        {
            return householdDL.Update(householdEL);
        }

        public Boolean Delete(EL.Registrations.Households householdEL)
        {
            return householdDL.Delete(householdEL);
        }
    }
}
