using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace pos.DL.Transactions
{
    public class PurchaseOrderDetails
    {
        public DataTable List(int id)
        {
            return Helper.executeQuery("select * from purhcaseorderdetails_view where `Purchase Order ID` = " + id + "");
        }

        public long Insert(EL.Transactions.PurchaseOrderDetails purchaseOrderDetail)
        {
            return Helper.executeNonQueryLong("insert into purhcaseorderdetails (purchaseorderid, supplyid, purhcaseorderdetailquantity, purhcaseorderdetailunitprice) values ('" + purchaseOrderDetail.Purchaseorderid + "', '" + purchaseOrderDetail.Supplyid + "', '" + purchaseOrderDetail.Purchaseorderdetailquantity + "', '" + purchaseOrderDetail.Purchaseorderdetailunitprice + "')");
        }


        public bool Delete(EL.Transactions.PurchaseOrderDetails purchaseOrderDetail)
        {
            return Helper.executeNonQueryBool("delete from purhcaseorderdetails where purchaseorderid = " + purchaseOrderDetail.Purchaseorderid + "");
        }
    }
}
