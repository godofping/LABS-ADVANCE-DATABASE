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

        public long Insert(EL.Transactions.PurhcaseOrders purchaseOrder)
        {
            return purchaseOrderDL.Insert(purchaseOrder);   
        }

        public bool Edit(EL.Transactions.PurhcaseOrders purchaseOrder)
        {
            return purchaseOrderDL.Edit(purchaseOrder);    
        }

        public bool Delete(EL.Transactions.PurhcaseOrders purchaseOrder)
        {
            return purchaseOrderDL.Delete(purchaseOrder);    
        }
    }
}
