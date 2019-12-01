using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pos.EL.Registrations
{
    public class customers
    {
        int customerid;
        string firstname;
        string middlename;
        string lastname;
        string contactnumber;
        string address;

        public int Customerid
        {
            get { return customerid; }
            set { customerid = value; }
        }


        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }


        public string Middlename
        {
            get { return middlename; }
            set { middlename = value; }
        }


        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }


        public string Contactnumber
        {
            get { return contactnumber; }
            set { contactnumber = value; }
        }


        public string Address
        {
            get { return address; }
            set { address = value; }
        }
    }
}
