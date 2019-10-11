using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Transactions
{
    public class Purchaseorderdetails
    {
        int purchaseorderdetailsid;
        int productid;
        int purchaseorderdetailquantity;
        int purchaseorderdetailamount;
        int purchaseorderid;
        int purchaseorderdetailstatus;
        int purchaseorderdetailprice;

        public int Purchaseorderdetailsid { get => purchaseorderdetailsid; set => purchaseorderdetailsid = value; }
        public int Productid { get => productid; set => productid = value; }
        public int Purchaseorderdetailquantity { get => purchaseorderdetailquantity; set => purchaseorderdetailquantity = value; }
        public int Purchaseorderdetailamount { get => purchaseorderdetailamount; set => purchaseorderdetailamount = value; }
        public int Purchaseorderid { get => purchaseorderid; set => purchaseorderid = value; }
        public int Purchaseorderdetailstatus { get => purchaseorderdetailstatus; set => purchaseorderdetailstatus = value; }
        public int Purchaseorderdetailprice { get => purchaseorderdetailprice; set => purchaseorderdetailprice = value; }
    }
}
