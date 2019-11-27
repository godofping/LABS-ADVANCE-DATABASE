using System;
using System.Collections.Generic;
using System.Text;

namespace WATER_REFILLING_STATION.EL.TRANSACTIONS
{
    public class customerorders
    {
        int customerorderid;
        int orderid;
        int customerid;

        public int Customerorderid { get => customerorderid; set => customerorderid = value; }
        public int Orderid { get => orderid; set => orderid = value; }
        public int Customerid { get => customerid; set => customerid = value; }
    }
}
