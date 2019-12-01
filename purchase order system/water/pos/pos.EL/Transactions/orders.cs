using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pos.EL.Transactions
{
    public class orders
    {
        int orderid;
        int customerid;
        float totalamount;
        string dateandtime;

        public int Orderid
        {
            get { return orderid; }
            set { orderid = value; }
        }
        

        public int Customerid
        {
            get { return customerid; }
            set { customerid = value; }
        }
        

        public float Totalamount
        {
            get { return totalamount; }
            set { totalamount = value; }
        }
        

        public string Dateandtime
        {
            get { return dateandtime; }
            set { dateandtime = value; }
        }
    }
}
