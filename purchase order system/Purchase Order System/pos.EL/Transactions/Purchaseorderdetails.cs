using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Transactions
{
    public class PurchaseOrderDetails
    {
        int purchaseorderdetailsid;
        int productid;
        int purchaseorderdetailquantity;
        int purchaseorderid;
        float purchaseorderdetailprice;

        public int Purchaseorderdetailsid { get => purchaseorderdetailsid; set => purchaseorderdetailsid = value; }
        public int Productid { get => productid; set => productid = value; }
        public int Purchaseorderdetailquantity { get => purchaseorderdetailquantity; set => purchaseorderdetailquantity = value; }
        public int Purchaseorderid { get => purchaseorderid; set => purchaseorderid = value; }
        public float Purchaseorderdetailprice { get => purchaseorderdetailprice; set => purchaseorderdetailprice = value; }
    }
}
