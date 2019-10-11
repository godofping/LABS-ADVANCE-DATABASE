using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Transactions
{
    public class Orders
    {
        int orderid;
        int customerid;
        int orderstatus;
        int orderamountpaid;
        int ordertotalamount;
        int orderdate;

        public int Orderid { get => orderid; set => orderid = value; }
        public int Customerid { get => customerid; set => customerid = value; }
        public int Orderstatus { get => orderstatus; set => orderstatus = value; }
        public int Orderamountpaid { get => orderamountpaid; set => orderamountpaid = value; }
        public int Ordertotalamount { get => ordertotalamount; set => ordertotalamount = value; }
        public int Orderdate { get => orderdate; set => orderdate = value; }
    }
}
