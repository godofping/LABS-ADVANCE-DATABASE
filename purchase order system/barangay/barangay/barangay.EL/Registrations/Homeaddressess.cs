using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.EL.Registrations
{
    public class Homeaddressess
    {
        int homeaddressid;
        int residentid;
        int purokid;
        string housenumber;
        string street;
        string subdivision;

        public int Homeaddressid { get => homeaddressid; set => homeaddressid = value; }
        public int Residentid { get => residentid; set => residentid = value; }
        public int Purokid { get => purokid; set => purokid = value; }
        public string Housenumber { get => housenumber; set => housenumber = value; }
        public string Street { get => street; set => street = value; }
        public string Subdivision { get => subdivision; set => subdivision = value; }
    }
}
