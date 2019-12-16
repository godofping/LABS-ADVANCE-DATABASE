using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.BL.Transactions
{
    public class productsintransactions
    {
        DL.Transactions.productsintransactions productsintransactionDL = new DL.Transactions.productsintransactions();

        public DataTable List(string keywords)
        {
            return productsintransactionDL.List(keywords);
        }

        public EL.Transactions.productsintransactions Select(EL.Transactions.productsintransactions productsintransactionEL)
        {
            return productsintransactionDL.Select(productsintransactionEL);
        }

        public long Insert(EL.Transactions.productsintransactions productsintransactionEL)
        {
            return productsintransactionDL.Insert(productsintransactionEL);
        }

        public bool Update(EL.Transactions.productsintransactions productsintransactionEL)
        {
            return productsintransactionDL.Update(productsintransactionEL);
        }

        public bool Delete(EL.Transactions.productsintransactions productsintransactionEL)
        {
            return productsintransactionDL.Delete(productsintransactionEL);
        }
    }
}
