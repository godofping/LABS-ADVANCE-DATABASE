using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Registrations
{
    public class Supplierproducts
    {
        int supplierproductid;
        int productid;
        int supplierid;

        public int Supplierproductid { get => supplierproductid; set => supplierproductid = value; }
        public int Productid { get => productid; set => productid = value; }
        public int Supplierid { get => supplierid; set => supplierid = value; }
    }
}
