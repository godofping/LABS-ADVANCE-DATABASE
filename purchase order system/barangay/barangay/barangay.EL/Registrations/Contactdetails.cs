using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.EL.Registrations
{
    public class Contactdetails
    {
        int contactdetailid;
        int residentid;
        string emailaddress;
        string phonenumber;
        string cellphonenumber;

        public int Contactdetailid { get => contactdetailid; set => contactdetailid = value; }
        public int Residentid { get => residentid; set => residentid = value; }
        public string Emailaddress { get => emailaddress; set => emailaddress = value; }
        public string Phonenumber { get => phonenumber; set => phonenumber = value; }
        public string Cellphonenumber { get => cellphonenumber; set => cellphonenumber = value; }
    }
}
