using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.EL.Registrations
{
    public class Residentshouseholdmember
    {
        int residenthouseholdmemberid;
        int residentid;
        int householdmemberid;

        public int Residenthouseholdmemberid { get => residenthouseholdmemberid; set => residenthouseholdmemberid = value; }
        public int Residentid { get => residentid; set => residentid = value; }
        public int Householdmemberid { get => householdmemberid; set => householdmemberid = value; }
    }
}
