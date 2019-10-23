using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pos.EL.Registrations
{
    public class Suppliers
    {
        int supplierid;
        string suppliername;
        string suppliercontactnumber;
        string supplieraddress;

        public int Supplierid
        {
            get { return supplierid; }
            set { supplierid = value; }
        }

        public string Suppliername
        {
            get { return suppliername; }
            set { suppliername = value; }
        }

        public string Suppliercontactnumber
        {
            get { return suppliercontactnumber; }
            set { suppliercontactnumber = value; }
        }

        public string Supplieraddress
        {
            get { return supplieraddress; }
            set { supplieraddress = value; }
        }

    }
}
