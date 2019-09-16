using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pos.EL.Registrations
{
    public class Customers
    {
        //Instance Variables
        int customerid;
        String lastname;
        String firstname	;
        String middleinitial	;
        int age	;
        String address	;
        String tribe;

        public int Customerid
        {
            get { return customerid; }
            set { customerid = value; }
        }


        public String Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public String Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public String Middleinitial
        {
            get { return middleinitial; }
            set { middleinitial = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public String Address
        {
            get { return address; }
            set { address = value; }
        }

        public String Tribe
        {
            get { return tribe; }
            set { tribe = value; }
        }

    }
}
