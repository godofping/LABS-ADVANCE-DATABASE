using System.Data;

namespace pos.BL.Transactions
{
    public class PurchaseOrderDetails
    {

        DL.Transactions.PurchaseOrderDetails purchaseOrderDetailDL = new DL.Transactions.PurchaseOrderDetails();

        public DataTable List(int id)
        {
            return purchaseOrderDetailDL.List(id);
        }

        public long Insert(EL.Transactions.PurchaseOrderDetails purchaseOrderDetail)
        {
            return purchaseOrderDetailDL.Insert(purchaseOrderDetail);
        }

        public bool Delete(EL.Transactions.PurchaseOrderDetails purchaseOrderDetail)
        {
            return purchaseOrderDetailDL.Delete(purchaseOrderDetail);
        }
    }
}
