﻿using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Registrations
{
    public class Customers
    {
        int customerid;
        int contactdetailid;
        int basicinformationid;

        public int Customerid { get => customerid; set => customerid = value; }
        public int Contactdetailid { get => contactdetailid; set => contactdetailid = value; }
        public int Basicinformationid { get => basicinformationid; set => basicinformationid = value; }
    }
}
