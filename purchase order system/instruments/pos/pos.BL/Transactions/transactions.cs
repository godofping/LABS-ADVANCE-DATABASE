using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.BL.Transactions
{
    public class transactions
    {

        DL.Transactions.transactions transactionDL = new DL.Transactions.transactions();

        public DataTable List(string keywords)
        {
            return transactionDL.List(keywords);
        }

        public EL.Transactions.transactions Select(EL.Transactions.transactions transactionEL)
        {
            return transactionDL.Select(transactionEL);
        }

        public long Insert(EL.Transactions.transactions transactionEL)
        {
            return transactionDL.Insert(transactionEL);
        }

        public bool Update(EL.Transactions.transactions transactionEL)
        {
            return transactionDL.Update(transactionEL);
        }

        public bool Delete(EL.Transactions.transactions transactionEL)
        {
            return transactionDL.Delete(transactionEL);
        }

        public DataTable TodaySales(string keywords)
        {
            return transactionDL.TodaySales(keywords);
        }
    }
}
