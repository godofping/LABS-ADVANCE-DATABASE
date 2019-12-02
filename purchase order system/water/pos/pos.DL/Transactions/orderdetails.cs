using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pos.DL.Transactions
{
    public class orderdetails
    {
        public long Insert(pos.EL.Transactions.orderdetails orderdetailEL)
        {
            return Helper.executeNonQueryLong("INSET INTO orderdetails (orderid, productid, quantity, price) VALUES ('" + orderdetailEL.Orderid + "', '" + orderdetailEL.Productid + "', '" + orderdetailEL.Quantity + "', '" + orderdetailEL.Price + "')");
        }
    }
}
