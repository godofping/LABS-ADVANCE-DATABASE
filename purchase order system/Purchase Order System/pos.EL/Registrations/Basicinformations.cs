using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Registrations
{
    class Basicinformations
    {
        int basicinformationid;
        string firstname;
        string middlename;
        string lastname;
        int genderid;
        string birthdate;

        public int Basicinformationid { get => basicinformationid; set => basicinformationid = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Middlename { get => middlename; set => middlename = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public int Genderid { get => genderid; set => genderid = value; }
        public string Birthdate { get => birthdate; set => birthdate = value; }
    }
}
