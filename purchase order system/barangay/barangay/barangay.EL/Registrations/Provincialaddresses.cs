using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.EL.Registrations
{
    public class Provincialaddresses
    {
        int provincialaddressid;
        int residentid;
        string municipality;
        string province;

        public int Provincialaddressid { get => provincialaddressid; set => provincialaddressid = value; }
        public int Residentid { get => residentid; set => residentid = value; }
        public string Municipality { get => municipality; set => municipality = value; }
        public string Province { get => province; set => province = value; }
    }
}
