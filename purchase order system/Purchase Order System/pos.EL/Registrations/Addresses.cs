using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Registrations
{
    public class Addresses
    {
        int addressid;
        string address;
        string city;
        string zipcode;
        string province;

        public int Addressid { get => addressid; set => addressid = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string Zipcode { get => zipcode; set => zipcode = value; }
        public string Province { get => province; set => province = value; }
    }
}
