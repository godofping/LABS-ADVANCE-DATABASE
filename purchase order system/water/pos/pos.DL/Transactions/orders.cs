using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pos.DL.Transactions
{
    public class orders
    {
        public DataTable List(string keywords)
        {
            string sQuery = "SELECT * FROM view_orders WHERE `C` LIKE '%" + keywords + "%' ";

            return Helper.executeQuery(sQuery);
        }


        public long Insert(pos.EL.Transactions.orders orderEL)
        {
            return Helper.executeNonQueryLong("INSET INTO orders (customerid, totalamount, dateandtime) VALUES ('" + orderEL.Orderid + "', '" + orderEL.Customerid + "', '" + DateTime.Now + "')");
        }

    }
}
