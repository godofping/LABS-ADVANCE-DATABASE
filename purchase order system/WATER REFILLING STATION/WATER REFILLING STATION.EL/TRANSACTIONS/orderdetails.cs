using System;
using System.Collections.Generic;
using System.Text;

namespace WATER_REFILLING_STATION.EL.TRANSACTIONS
{
    public class orderdetails
    {
        int orderdetailid;
        int orderid;
        int productid;
        float amount;
        int quantity;

        public int Orderdetailid { get => orderdetailid; set => orderdetailid = value; }
        public int Orderid { get => orderid; set => orderid = value; }
        public int Productid { get => productid; set => productid = value; }
        public float Amount { get => amount; set => amount = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
