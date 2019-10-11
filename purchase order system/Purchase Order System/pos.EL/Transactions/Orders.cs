using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Transactions
{
    public class Orders
    {
        int orderid;
        int customerid;
        string orderstatus;
        float orderamountpaid;
        float ordertotalamount;
        string orderdate;

        public int Orderid { get => orderid; set => orderid = value; }
        public int Customerid { get => customerid; set => customerid = value; }
        public string Orderstatus { get => orderstatus; set => orderstatus = value; }
        public float Orderamountpaid { get => orderamountpaid; set => orderamountpaid = value; }
        public float Ordertotalamount { get => ordertotalamount; set => ordertotalamount = value; }
        public string Orderdate { get => orderdate; set => orderdate = value; }
    }
}
