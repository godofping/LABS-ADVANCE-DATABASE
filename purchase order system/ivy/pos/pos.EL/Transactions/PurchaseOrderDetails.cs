using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pos.EL.Transactions
{
    public class PurchaseOrderDetails
    {
        int purchaseorderdetailid;
        int purchaseorderid;
        int supplyid;
        int purchaseorderdetailquantity;
        float purchaseorderdetailunitprice;


        public int Purchaseorderdetailid
        {
            get { return purchaseorderdetailid; }
            set { purchaseorderdetailid = value; }
        }

        public int Purchaseorderid
        {
            get { return purchaseorderid; }
            set { purchaseorderid = value; }
        }

        public int Supplyid
        {
            get { return supplyid; }
            set { supplyid = value; }
        }

        public int Purchaseorderdetailquantity
        {
            get { return purchaseorderdetailquantity; }
            set { purchaseorderdetailquantity = value; }
        }

        public float Purchaseorderdetailunitprice
        {
            get { return purchaseorderdetailunitprice; }
            set { purchaseorderdetailunitprice = value; }
        }


    }
}
