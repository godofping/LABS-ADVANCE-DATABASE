using System.Data;
namespace pos.BL.Transactions
{
   public class PurchaseOrderDetails
    {
        DL.Transactions.PurchaseOrderDetails purchaseOrderDetailDL = new DL.Transactions.PurchaseOrderDetails();

        public DataTable List(string keywords)
        {
            return purchaseOrderDetailDL.List(keywords);
        }

        public long Insert(EL.Transactions.PurchaseOrderDetails purchaseOrderDetailEL)
        {
            return purchaseOrderDetailDL.Insert(purchaseOrderDetailEL);
        }

        public bool Delete(EL.Transactions.PurchaseOrderDetails purchaseOrderDetailEL)
        {
            return purchaseOrderDetailDL.Delete(purchaseOrderDetailEL);
        }
    }
}
