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
        float purchaseorderdetailamount;
        int purchaseorderid;
        string purchaseorderdetailstatus;
        float purchaseorderdetailprice;

        public int Purchaseorderdetailsid { get => purchaseorderdetailsid; set => purchaseorderdetailsid = value; }
        public int Productid { get => productid; set => productid = value; }
        public int Purchaseorderdetailquantity { get => purchaseorderdetailquantity; set => purchaseorderdetailquantity = value; }
        public float Purchaseorderdetailamount { get => purchaseorderdetailamount; set => purchaseorderdetailamount = value; }
        public int Purchaseorderid { get => purchaseorderid; set => purchaseorderid = value; }
        public string Purchaseorderdetailstatus { get => purchaseorderdetailstatus; set => purchaseorderdetailstatus = value; }
        public float Purchaseorderdetailprice { get => purchaseorderdetailprice; set => purchaseorderdetailprice = value; }
    }
}
