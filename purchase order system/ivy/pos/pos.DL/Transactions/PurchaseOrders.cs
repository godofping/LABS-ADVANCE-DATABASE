using System.Data;

namespace pos.DL.Transactions
{
    public class PurchaseOrders
    {
        public DataTable List(string keywords)
        {
            return Helper.executeQuery("select * from purchaseorders_view where `Purchase Order ID` like '%" + keywords + "%' or `Purchase Order Name` like '%" + keywords + "%' or `Purchase Order Request Date` like '%" + keywords + "%' or `Purchase Order Delivery Date` like '%" + keywords + "%' or `Purchase Order Status` like '%" + keywords + "%' or `Purchase Order Total Amount` like '%" + keywords + "%' or `Supplier Name` like '%" + keywords + "%' or `Supplier Contact Number` like '%" + keywords + "%' or `Supplier Address` like '%" + keywords + "%' or `Prepared By` like '%" + keywords + "%'");
        }

        public DataTable List(int id)
        {
            return Helper.executeQuery("select * from purchaseorders_view where `Purchase Order ID` = " + id + "");
        }

        public long Insert(EL.Transactions.PurchaseOrders purchaseOrder)
        {
            return Helper.executeNonQueryLong("insert into purchaseorders (supplierid, accountid, purchaseordername, purchaseorderrequestdate, purchaseorderdeliverydate, purchaseorderstatus, purchaseordertotalamount) values ('" + purchaseOrder.Supplierid + "', '" + purchaseOrder.Accountid + "', '" + purchaseOrder.Purchaseordername + "', '" + purchaseOrder.Purchaseorderrequestdate + "', '" + purchaseOrder.Purchaseorderdeliverydate + "', '" + purchaseOrder.Purchaseorderstatus + "', '" + purchaseOrder.Purchaseordertotalamount + "')");
        }

        public bool Edit(EL.Transactions.PurchaseOrders purchaseOrder)
        {
            return Helper.executeNonQueryBool("update purchaseorders set supplierid = '" + purchaseOrder.Purchaseorderid + "', purchaseordername = '" + purchaseOrder.Purchaseordername + "', purchaseorderdeliverydate = '" + purchaseOrder.Purchaseorderdeliverydate + "', purchaseorderstatus = '" + purchaseOrder.Purchaseorderstatus + "', purchaseordertotalamount = '" + purchaseOrder.Purchaseordertotalamount + "' where purchaseorderid = " + purchaseOrder.Purchaseorderid + "");
        }

        public bool Delete(EL.Transactions.PurchaseOrders purchaseOrder)
        {
            return Helper.executeNonQueryBool("delete from purchaseorders where purchaseorderid = " + purchaseOrder.Purchaseorderid + "");
        }
    }
}
