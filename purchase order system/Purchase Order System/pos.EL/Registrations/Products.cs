using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Registrations
{
    public class Products
    {
        int productid;
        string productname;
        string productdescription;
        int subcategoryid;
        string productsku;
        float productprice;
        int isdeleted;

        public int Productid { get => productid; set => productid = value; }
        public string Productname { get => productname; set => productname = value; }
        public string Productdescription { get => productdescription; set => productdescription = value; }
        public int Subcategoryid { get => subcategoryid; set => subcategoryid = value; }
        public string Productsku { get => productsku; set => productsku = value; }
        public float Productprice { get => productprice; set => productprice = value; }
        public int Isdeleted { get => isdeleted; set => isdeleted = value; }
    }
}
