using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.EL.Registrations
{
    public class Birthinformations
    {
        int birthinformationid;
        int residentid;
        string birthplace;
        string birthdate;

        public int Birthinformationid { get => birthinformationid; set => birthinformationid = value; }
        public int Residentid { get => residentid; set => residentid = value; }
        public string Birthplace { get => birthplace; set => birthplace = value; }
        public string Birthdate { get => birthdate; set => birthdate = value; }
    }
}
