using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.EL.Registrations
{
    public class Households
    {
        int householdid;
        string household;
        string householdnumber;

        public int Householdid { get => householdid; set => householdid = value; }
        public string Household { get => household; set => household = value; }
        public string Householdnumber { get => householdnumber; set => householdnumber = value; }
    }
}
