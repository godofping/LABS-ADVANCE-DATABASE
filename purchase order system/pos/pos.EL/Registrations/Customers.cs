using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Registrations
{
    public class Customers
    {
        //Instance Variable
        int customerid;
        string lastname;
        string firstname;
        string middleinitial;
        int age;
        string address;
        string tribe;

        public int Customerid { get => customerid; set => customerid = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Middleinitial { get => middleinitial; set => middleinitial = value; }
        public int Age { get => age; set => age = value; }
        public string Address { get => address; set => address = value; }
        public string Tribe { get => tribe; set => tribe = value; }
        public string Firstname { get => firstname; set => firstname = value; }
    }
}
