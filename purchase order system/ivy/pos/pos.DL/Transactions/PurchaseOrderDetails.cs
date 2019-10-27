using System.Data;

namespace pos.DL.Transactions
{
    public class PurchaseOrderDetails
    {
        public DataTable List(int id)
        {
            return Helper.executeQuery("select * from purchaseorderdetails_view where `Purchase Order ID` = " + id + "");
        }

        public long Insert(EL.Transactions.PurchaseOrderDetails purchaseOrderDetail)
        {
            return Helper.executeNonQueryLong("insert into purchaseorderdetails (purchaseorderid, supplyid, purchaseorderdetailquantity, purchaseorderdetailunitprice) values ('" + purchaseOrderDetail.Purchaseorderid + "', '" + purchaseOrderDetail.Supplyid + "', '" + purchaseOrderDetail.Purchaseorderdetailquantity + "', '" + purchaseOrderDetail.Purchaseorderdetailunitprice + "')");
        }


        public bool Delete(int id)
        {
            return Helper.executeNonQueryBool("delete from purchaseorderdetails where purchaseorderid = " + id + "");
        }
    }
}
