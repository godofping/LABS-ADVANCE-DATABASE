using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Transactions
{
    public class Orders
    {
        int orderid;
        int customerid;
        string date;
        float amountpaid;
        float chargeamount;
        string status;


        public int Orderid { get => orderid; set => orderid = value; }
        public int Customerid { get => customerid; set => customerid = value; }
        public string Date { get => date; set => date = value; }
        public float Amountpaid { get => amountpaid; set => amountpaid = value; }
        public float Chargeamount { get => chargeamount; set => chargeamount = value; }
        public string Status { get => status; set => status = value; }
   
    }
}
