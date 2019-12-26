using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.EL.Registrations
{
    public class Issuances
    {
        int issuanceid;
        int residentid;
        int certificationid;
        string issuancedateandtime;

        public int Issuanceid { get => issuanceid; set => issuanceid = value; }
        public int Residentid { get => residentid; set => residentid = value; }
        public int Certificationid { get => certificationid; set => certificationid = value; }
        public string Issuancedateandtime { get => issuancedateandtime; set => issuancedateandtime = value; }
    }
}
