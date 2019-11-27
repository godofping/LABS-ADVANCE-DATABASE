using System;
using System.Collections.Generic;
using System.Text;

namespace WATER_REFILLING_STATION.EL.REGISTRATIONS
{
    public class basicinformations
    {
        int basicinformationid;
        string lastname;
        string firstname;
        string middleinitial;
        string birthdate;
        string address;
        string contactnumber;
        string emailaddress;

        public int Basicinformationid { get => basicinformationid; set => basicinformationid = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Middleinitial { get => middleinitial; set => middleinitial = value; }
        public string Birthdate { get => birthdate; set => birthdate = value; }
        public string Address { get => address; set => address = value; }
        public string Contactnumber { get => contactnumber; set => contactnumber = value; }
        public string Emailaddress { get => emailaddress; set => emailaddress = value; }
    }
}
