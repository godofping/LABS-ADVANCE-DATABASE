using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.EL.Registrations
{
    public class Residents
    {
        int residentid;
        string barangayidnumber;
        string lastname;
        string firstname;
        string middlename;
        string height;
        string weight;
        string precintnumber;
        string ctcnumber;
        string dateaccomplished;
        string daterecorded;
        int ispwd;

        public int Residentid { get => residentid; set => residentid = value; }
        public string Barangayidnumber { get => barangayidnumber; set => barangayidnumber = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Middlename { get => middlename; set => middlename = value; }
        public string Height { get => height; set => height = value; }
        public string Weight { get => weight; set => weight = value; }
        public string Precintnumber { get => precintnumber; set => precintnumber = value; }
        public string Ctcnumber { get => ctcnumber; set => ctcnumber = value; }
        public string Dateaccomplished { get => dateaccomplished; set => dateaccomplished = value; }
        public string Daterecorded { get => daterecorded; set => daterecorded = value; }
        public int Ispwd { get => ispwd; set => ispwd = value; }
    }
}
