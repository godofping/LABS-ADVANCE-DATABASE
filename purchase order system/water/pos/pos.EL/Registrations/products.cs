using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pos.EL.Registrations
{
    public class products
    {
        int productid;
        string productcode;
        string productname;
        float price;
        int stock;

        public int Productid
        {
            get { return productid; }
            set { productid = value; }
        }
        

        public string Productcode
        {
            get { return productcode; }
            set { productcode = value; }
        }
        

        public string Productname
        {
            get { return productname; }
            set { productname = value; }
        }
        

        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

    }
}
