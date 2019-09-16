using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Transactions
{
    public class OrderDetails
    {
        int orderdetailid;
        int orderid;
        int itemno;
        int description;
        int unitprice;
        int qty;
        int amount;
        int status;

        public int Orderdetailid { get => orderdetailid; set => orderdetailid = value; }
        public int Orderid { get => orderid; set => orderid = value; }
        public int Itemno { get => itemno; set => itemno = value; }
        public int Description { get => description; set => description = value; }
        public int Unitprice { get => unitprice; set => unitprice = value; }
        public int Amount { get => amount; set => amount = value; }
        public int Qty { get => qty; set => qty = value; }
        public int Status { get => status; set => status = value; }
    }
}
