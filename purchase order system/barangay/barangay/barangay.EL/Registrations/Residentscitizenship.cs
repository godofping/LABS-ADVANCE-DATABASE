using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.EL.Registrations
{
    public class Residentscitizenship
    {
        int residentcitizenshipid;
        int residentid;
        int citizenshipid;

        public int Residentcitizenshipid { get => residentcitizenshipid; set => residentcitizenshipid = value; }
        public int Residentid { get => residentid; set => residentid = value; }
        public int Citizenshipid { get => citizenshipid; set => citizenshipid = value; }
    }
}
