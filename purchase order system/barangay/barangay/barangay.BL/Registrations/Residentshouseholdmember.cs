using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Residentshouseholdmember
    {
        DL.Registrations.Residentshouseholdmember residenthouseholdmemberDL = new DL.Registrations.Residentshouseholdmember();
        public EL.Registrations.Residentshouseholdmember Select(EL.Registrations.Residentshouseholdmember residenthouseholdmemberEL)
        {
            return residenthouseholdmemberDL.Select(residenthouseholdmemberEL);
        }

        public long Insert(EL.Registrations.Residentshouseholdmember residenthouseholdmemberEL)
        {
            return residenthouseholdmemberDL.Insert(residenthouseholdmemberEL);
        }

        public Boolean Update(EL.Registrations.Residentshouseholdmember residenthouseholdmemberEL)
        {
            return residenthouseholdmemberDL.Update(residenthouseholdmemberEL);
        }

        public Boolean Delete(EL.Registrations.Residentshouseholdmember residenthouseholdmemberEL)
        {
            return residenthouseholdmemberDL.Delete(residenthouseholdmemberEL);
        }
    }
}
