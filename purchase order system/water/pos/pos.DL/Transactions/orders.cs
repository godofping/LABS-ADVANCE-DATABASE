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

        public DataTable List(int id)
        {
            string sQuery = "SELECT * FROM view_orders WHERE `ORDER ID` = '" + id + "' ";

            return Helper.executeQuery(sQuery);
        }

        public DataTable List(string keyword, string keyword1)
        {
            string sQuery = "SELECT * FROM view_orders WHERE `DATE AND TIME` like '%" + keyword + "%' ";

            return Helper.executeQuery(sQuery);
        }

        public long Insert(pos.EL.Transactions.orders orderEL)
        {
            return Helper.executeNonQueryLong("INSERT INTO orders (customerid, totalamount, dateandtime) VALUES ('" + orderEL.Customerid + "', '" + orderEL.Totalamount + "', '" + orderEL.Dateandtime + "')");
        }

    }
}
