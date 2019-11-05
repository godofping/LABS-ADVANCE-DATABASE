using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

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

        public long Insert(EL.Transactions.PurchaseOrders purchaseOrder)
        {
            return purchaseOrderDL.Insert(purchaseOrder);   
        }

        public bool Edit(EL.Transactions.PurchaseOrders purchaseOrder)
        {
            return purchaseOrderDL.Edit(purchaseOrder);    
        }

        public bool SetRecieved(int id)
        {
            return purchaseOrderDL.SetRecieved(id);
        }

        public bool SetCancelled(int id)
        {
            return purchaseOrderDL.SetCancelled(id);
        }

        public bool Delete(EL.Transactions.PurchaseOrders purchaseOrder)
        {
            return purchaseOrderDL.Delete(purchaseOrder);    
        }
    }
}
