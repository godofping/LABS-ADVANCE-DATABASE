using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.EL.Registrations
{
    public class Imagelocations
    {
        int imagelocationid;
        int residentid;
        string imagelocation;

        public int Imagelocationid { get => imagelocationid; set => imagelocationid = value; }
        public int Residentid { get => residentid; set => residentid = value; }
        public string Imagelocation { get => imagelocation; set => imagelocation = value; }
    }
}
