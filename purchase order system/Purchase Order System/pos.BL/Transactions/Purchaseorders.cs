using System.Data;

namespace pos.BL.Transactions
{
    public class Purchaseorders
    {
        DL.Transactions.PurchaseOrders purchaseOrderDL = new DL.Transactions.PurchaseOrders();

        public DataTable List(string keywords)
        {
            return purchaseOrderDL.List(keywords);
        }

        public DataTable List(int id)
        {
            return purchaseOrderDL.List(id);
        }

        public long Insert(EL.Transactions.Purchaseorders purchaseOrders)
        {
            return purchaseOrderDL.Insert(purchaseOrders);
        }

        public bool Update(EL.Transactions.Purchaseorders purchaseOrders)
        {
            return purchaseOrderDL.Update(purchaseOrders);
        }

        public bool Delete(EL.Transactions.Purchaseorders purchaseOrders)
        {
            return purchaseOrderDL.Delete(purchaseOrders);
        }
    }
}
