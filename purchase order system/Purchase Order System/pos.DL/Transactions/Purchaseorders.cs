using System.Data;

namespace pos.DL.Transactions
{
    public class PurchaseOrders
    {
        public DataTable List(string keywords)
        {
            string sQuery = "select * from purchaseorders_view";
            return Helper.executeQuery(sQuery);
        }

        public DataTable List(int id)
        {
            string sQuery = "select * from purchaseorders_view where `Purchase Order ID` = " + id + "";
            return Helper.executeQuery(sQuery);
        }

        public long Insert(EL.Transactions.PurchaseOrders purchaseOrderEL)
        {
            return Helper.executeNonQueryLong("insert into purchaseorders (staffid, purchaseordername, supplierid, paymentmethodid, shippingmethodid, purchaseorderstatus, purchaseorderamountpaid, purchasetotalorderamount, purchaseorderdatedelivered, purchaseorderdaterequested, purchaseordercomment) values ('" + purchaseOrderEL.Staffid + "', '" + purchaseOrderEL.Purchaseordername + "', '" + purchaseOrderEL.Supplierid + "', '" + purchaseOrderEL.Paymentmethodid + "', '" + purchaseOrderEL.Shippingmethodid + "', '" + purchaseOrderEL.Purchaseorderstatus + "', '" + purchaseOrderEL.Purchaseorderamountpaid + "', '" + purchaseOrderEL.Purchasetotalorderamount + "', '" + purchaseOrderEL.Purchaseorderdatedelivered + "', '" + purchaseOrderEL.Purchaseorderdaterequested + "', '" + purchaseOrderEL.Purchaseordercomment + "')");
        }


        public bool Delete(EL.Transactions.PurchaseOrders purchaseOrderEL)
        {
            return Helper.executeNonQueryBool("update purchaseorders set isdeleted = 1 where purchaseorderid = " + purchaseOrderEL.Purchaseorderid + "");
        }
    }
}
