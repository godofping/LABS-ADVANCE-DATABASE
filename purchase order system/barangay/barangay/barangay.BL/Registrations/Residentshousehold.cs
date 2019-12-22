using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Residentshousehold
    {
        DL.Registrations.Residentshousehold residenthouseholdDL = new DL.Registrations.Residentshousehold();
        public EL.Registrations.Residentshousehold Select(EL.Registrations.Residentshousehold residenthouseholdEL)
        {
            return residenthouseholdDL.Select(residenthouseholdEL);
        }

        public long Insert(EL.Registrations.Residentshousehold residenthouseholdEL)
        {
            return residenthouseholdDL.Insert(residenthouseholdEL);
        }

        public Boolean Update(EL.Registrations.Residentshousehold residenthouseholdEL)
        {
            return residenthouseholdDL.Update(residenthouseholdEL);
        }

        public Boolean Delete(EL.Registrations.Residentshousehold residenthouseholdEL)
        {
            return residenthouseholdDL.Delete(residenthouseholdEL);
        }
    }
}
