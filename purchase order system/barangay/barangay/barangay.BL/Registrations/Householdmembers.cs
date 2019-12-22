using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Householdmembers
    {
        DL.Registrations.Householdmembers householdmemberDL = new DL.Registrations.Householdmembers();
        public DataTable List()
        {
            return householdmemberDL.List();
        }

        public EL.Registrations.Householdmembers Select(EL.Registrations.Householdmembers householdmemberEL)
        {
            return householdmemberDL.Select(householdmemberEL);
        }
    }
}
