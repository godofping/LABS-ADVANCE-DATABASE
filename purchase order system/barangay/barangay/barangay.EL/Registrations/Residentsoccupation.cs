using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.EL.Registrations
{
    public class Residentsoccupation
    {
        int residentoccupationid;
        int residentid;
        int occupationid;

        public int Residentoccupationid { get => residentoccupationid; set => residentoccupationid = value; }
        public int Residentid { get => residentid; set => residentid = value; }
        public int Occupationid { get => occupationid; set => occupationid = value; }
    }
}
