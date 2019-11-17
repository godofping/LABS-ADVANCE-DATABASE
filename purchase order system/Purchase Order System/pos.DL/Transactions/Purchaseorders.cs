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
            return Helper.executeNonQueryLong("insert into purchaseorders (staffid, purchaseordername, supplierid, paymentmethodid, shippingmethodid, purchaseorderstatus, purchaseorderamountpaid, purchasetotalorderamount, purchaseorderdatereceived, purchaseorderdaterequested, purchaseordercomment) values ('" + purchaseOrderEL.Staffid + "', '" + purchaseOrderEL.Purchaseordername + "', '" + purchaseOrderEL.Supplierid + "', '" + purchaseOrderEL.Paymentmethodid + "', '" + purchaseOrderEL.Shippingmethodid + "', '" + purchaseOrderEL.Purchaseorderstatus + "', '" + purchaseOrderEL.Purchaseorderamountpaid + "', '" + purchaseOrderEL.Purchasetotalorderamount + "', '" + purchaseOrderEL.Purchaseorderdatereceived + "', '" + purchaseOrderEL.Purchaseorderdaterequested + "', '" + purchaseOrderEL.Purchaseordercomment + "')");
        }

        public bool Update(EL.Transactions.PurchaseOrders purchaseOrderEL)
        {
            return Helper.executeNonQueryBool("update purchaseorders set purchaseorderamountpaid = '" + purchaseOrderEL.Purchaseorderamountpaid + "' where purchaseorderid = " + purchaseOrderEL.Purchaseorderid + "");
        }

        public bool Received(EL.Transactions.PurchaseOrders purchaseOrderEL)
        {
            return Helper.executeNonQueryBool("update purchaseorders set purchaseorderdatereceived = '" + purchaseOrderEL.Purchaseorderdatereceived + "', purchaseorderstatus = '" + purchaseOrderEL.Purchaseorderstatus + "'  where purchaseorderid = " + purchaseOrderEL.Purchaseorderid + "");
        }

        public bool Canceled(EL.Transactions.PurchaseOrders purchaseOrderEL)
        {
            return Helper.executeNonQueryBool("update purchaseorders set purchaseorderstatus = '" + purchaseOrderEL.Purchaseorderstatus + "' where purchaseorderid = " + purchaseOrderEL.Purchaseorderid + "");
        }

        public bool Delete(EL.Transactions.PurchaseOrders purchaseOrderEL)
        {
            return Helper.executeNonQueryBool("delete from purchaseorders where purchaseorderid = " + purchaseOrderEL.Purchaseorderid + "");
        }
    }
}
