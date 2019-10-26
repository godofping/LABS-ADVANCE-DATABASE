using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace pos.DL.Transactions
{
    public class PurchaseOrders
    {
        public DataTable List(string keywords)
        {
            return Helper.executeQuery("select * from purchaseorders_view where `Purchase Order ID` like '%" + keywords + "%' or `Purchase Order Name` like '%" + keywords  + "%' or `Purchase Order Request Date` like '%" + keywords + "%' or `Purchase Order Delivery Date` like '%" + keywords + "%' or `Purchase Order Status` like '%" + keywords + "%' or `Purchase Order Total Amount` like '%" + keywords + "%' or `Supplier Name` like '%" + keywords + "%' or `Supplier Contact Number` like '%" + keywords + "%' or `Supplier Address` like '%" + keywords + "%' or `Purchase Order By` like '%" + keywords + "%'");
        }

        public long Insert(EL.Transactions.PurhcaseOrders purchaseOrder)
        {
            return Helper.executeNonQueryLong("insert into purhcaseorders (supplierid, accountid, purchaseordername, purhcaseorderrequestdate, purhcaseorderdeliverydate, purchaseorderstatus, purhcaseordertotalamount) values ('" + purchaseOrder.Supplierid + "', '" + purchaseOrder.Accountid + "', '" + purchaseOrder.Purchaseordername + "', '" + purchaseOrder.Purchaseorderrequestdate + "', '" + purchaseOrder.Purchaseorderdeliverydate + "', '" + purchaseOrder.Purchaseorderstatus + "', '" + purchaseOrder.Purchaseordertotalamount + "')");
        }

        public bool Edit(EL.Transactions.PurhcaseOrders purchaseOrder)
        {
            return Helper.executeNonQueryBool("update purhcaseorders set supplierid = '" + purchaseOrder.Purchaseorderid + "', purchaseordername = '" + purchaseOrder.Purchaseordername + "', purchaseorderdeliverydate = '" + purchaseOrder.Purchaseorderdeliverydate +"', purchaseorderstatus = '" + purchaseOrder.Purchaseorderstatus + "', purhcaseordertotalamount = '" + purchaseOrder.Purchaseordertotalamount + "' where purchaseorderid = " + purchaseOrder.Purchaseorderid  + "");
        }

        public bool Delete(EL.Transactions.PurhcaseOrders purchaseOrder)
        {
            return Helper.executeNonQueryBool("delete from purhcaseorders where purchaseorderid = " + purchaseOrder.Purchaseorderid + "");
        }
    }
}
