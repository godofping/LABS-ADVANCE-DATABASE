using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Registrations
{
    public class Vendorproducts
    {
        int vendorproductid;
        int productid;
        int vendorid;

        public int Vendorproductid { get => vendorproductid; set => vendorproductid = value; }
        public int Productid { get => productid; set => productid = value; }
        public int Vendorid { get => vendorid; set => vendorid = value; }
    }
}
