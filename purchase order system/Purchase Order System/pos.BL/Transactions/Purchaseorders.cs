using System.Data;

namespace pos.BL.Transactions
{
    public class PurchaseOrders
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

        public long Insert(EL.Transactions.PurchaseOrders purchaseOrderEL)
        {
            return purchaseOrderDL.Insert(purchaseOrderEL);
        }

        public bool Update(EL.Transactions.PurchaseOrders purchaseOrderEL)
        {
            return purchaseOrderDL.Update(purchaseOrderEL);
        }

        public bool Delete(EL.Transactions.PurchaseOrders purchaseOrderEL)
        {
            return purchaseOrderDL.Delete(purchaseOrderEL);
        }
    }
}
