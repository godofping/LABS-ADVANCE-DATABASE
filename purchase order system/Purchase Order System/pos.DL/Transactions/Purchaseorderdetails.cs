﻿using System.Data;
namespace pos.DL.Transactions
{
   public class PurchaseOrderDetails
    {
        public DataTable List(string keywords)
        {
            string sQuery = "select * from purchaseorderdetails_view";
            return Helper.executeQuery(sQuery);
        }

        public DataTable List(int id)
        {
            string sQuery = "select * from purchaseorderdetails_view where `Purchase Order ID` = " + id + "";
            return Helper.executeQuery(sQuery);
        }

        public long Insert(EL.Transactions.PurchaseOrderDetails purchaseOrderDetailEL)
        {
            return Helper.executeNonQueryLong("insert into purchaseorderdetails (productid, purchaseorderdetailquantity, purchaseorderid, purchaseorderdetailprice) values ('" + purchaseOrderDetailEL.Productid + "', '" + purchaseOrderDetailEL.Purchaseorderdetailquantity + "', '" + purchaseOrderDetailEL.Purchaseorderid + "', '" + purchaseOrderDetailEL.Purchaseorderdetailprice + "')");
        }

        public bool Delete(EL.Transactions.PurchaseOrderDetails purchaseOrderDetailEL)
        {
            return Helper.executeNonQueryBool("delete from purchaseorderdetails where purchaseorderid = " + purchaseOrderDetailEL.Purchaseorderid + "");
        }
    }
}
