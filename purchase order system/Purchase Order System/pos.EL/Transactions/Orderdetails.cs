using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Transactions
{
   public class Orderdetails
    {
        int orderdetailid;
        int orderid;
        int productid;
        int orderdetaildquantity;
        int orderdetaildamount;
        int orderdetailstatus;
        int orderdetailproductprice;

        public int Orderdetailid { get => orderdetailid; set => orderdetailid = value; }
        public int Orderid { get => orderid; set => orderid = value; }
        public int Productid { get => productid; set => productid = value; }
        public int Orderdetaildquantity { get => orderdetaildquantity; set => orderdetaildquantity = value; }
        public int Orderdetaildamount { get => orderdetaildamount; set => orderdetaildamount = value; }
        public int Orderdetailstatus { get => orderdetailstatus; set => orderdetailstatus = value; }
        public int Orderdetailproductprice { get => orderdetailproductprice; set => orderdetailproductprice = value; }
    }
}
