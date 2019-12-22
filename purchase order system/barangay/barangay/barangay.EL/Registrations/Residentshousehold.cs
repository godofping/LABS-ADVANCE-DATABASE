using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.EL.Registrations
{
    public class Residentshousehold
    {
        int residenthouseholdid;
        int residentid;
        int householdid;

        public int Residenthouseholdid { get => residenthouseholdid; set => residenthouseholdid = value; }
        public int Residentid { get => residentid; set => residentid = value; }
        public int Householdid { get => householdid; set => householdid = value; }
    }
}
