using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Transactions
{
   public class OrderDetails
    {
        int orderdetailid;
        int orderid;
        int productid;
        int orderdetaildquantity;
        string orderdetailstatus;
        float orderdetailproductprice;

        public int Orderdetailid { get => orderdetailid; set => orderdetailid = value; }
        public int Orderid { get => orderid; set => orderid = value; }
        public int Productid { get => productid; set => productid = value; }
        public int Orderdetaildquantity { get => orderdetaildquantity; set => orderdetaildquantity = value; }
        public string Orderdetailstatus { get => orderdetailstatus; set => orderdetailstatus = value; }
        public float Orderdetailproductprice { get => orderdetailproductprice; set => orderdetailproductprice = value; }
    }
}
