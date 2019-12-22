using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.EL.Registrations
{
    public class Residentscivilstatus
    {
        int residentcivilstatusid;
        int residentid;
        int civilstatusid;

        public int Residentcivilstatusid { get => residentcivilstatusid; set => residentcivilstatusid = value; }
        public int Residentid { get => residentid; set => residentid = value; }
        public int Civilstatusid { get => civilstatusid; set => civilstatusid = value; }
    }
}
