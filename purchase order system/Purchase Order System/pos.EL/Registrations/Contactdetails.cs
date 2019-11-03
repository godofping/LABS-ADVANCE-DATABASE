using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Registrations
{
    public class ContactDetails
    {
        int contactdetailid;
        int addressid;
        string contactnumber;
        string emailaddress;

        public int Contactdetailid { get => contactdetailid; set => contactdetailid = value; }
        public int Addressid { get => addressid; set => addressid = value; }
        public string Contactnumber { get => contactnumber; set => contactnumber = value; }
        public string Emailaddress { get => emailaddress; set => emailaddress = value; }
    }
}
