using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pos.BL.Transactions
{
    public class orders
    {
        pos.DL.Transactions.orders orderDL = new pos.DL.Transactions.orders();

        public DataTable List(string keywords)
        {
            return orderDL.List(keywords);
        }

        public DataTable Select(int id)
        {
            return orderDL.List(id);
        }


        public long Insert(pos.EL.Transactions.orders orderEL)
        {
            return orderDL.Insert(orderEL);
        }
    }
}
