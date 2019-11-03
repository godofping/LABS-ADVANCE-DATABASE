using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Transactions
{
    public class PurchaseOrderDetails
    {
        int purchaseorderdetailid;
        int productid;
        int purchaseorderdetailquantity;
        int purchaseorderid;
        float purchaseorderdetailprice;

        public int Purchaseorderdetailid { get => purchaseorderdetailid; set => purchaseorderdetailid = value; }
        public int Productid { get => productid; set => productid = value; }
        public int Purchaseorderdetailquantity { get => purchaseorderdetailquantity; set => purchaseorderdetailquantity = value; }
        public int Purchaseorderid { get => purchaseorderid; set => purchaseorderid = value; }
        public float Purchaseorderdetailprice { get => purchaseorderdetailprice; set => purchaseorderdetailprice = value; }
    }
}
