using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.EL.Registrations
{
    public class customers
    {
        int customerid;
        string fullname;
        string contactnumber;

        public int Customerid
        {
            get
            {
                return customerid;
            }

            set
            {
                customerid = value;
            }
        }

        public string Fullname
        {
            get
            {
                return fullname;
            }

            set
            {
                fullname = value;
            }
        }

        public string Contactnumber
        {
            get
            {
                return contactnumber;
            }

            set
            {
                contactnumber = value;
            }
        }
    }
}
