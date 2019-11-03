    using System.Data;

namespace pos.DL.Transactions
{
   public  class PurchaseOrders
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

        public long Insert(EL.Transactions.Purchaseorders purchaseOrderInfo)
        {
            return Helper.executeNonQueryLong("");
        }

        public bool Update(EL.Transactions.Purchaseorders purchaseOrderInfo)
        {
            return Helper.executeNonQueryBool("");
        }

        public bool Delete(EL.Transactions.Purchaseorders purchaseOrderInfo)
        {
            return Helper.executeNonQueryBool("");
        }
    }
}
