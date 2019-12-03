using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pos.DL.Transactions
{
    public class orderdetails
    {
        public DataTable Select(int id)
        {
            string sQuery = "SELECT * FROM view_orderdetails WHERE `ORDER ID` = '" + id + "' ";

            return Helper.executeQuery(sQuery);
        }


        public long Insert(pos.EL.Transactions.orderdetails orderdetailEL)
        {
            return Helper.executeNonQueryLong("INSERT INTO orderdetails (orderid, productid, quantity, price) VALUES ('" + orderdetailEL.Orderid + "', '" + orderdetailEL.Productid + "', '" + orderdetailEL.Quantity + "', '" + orderdetailEL.Price + "')");
        }
    }
}
