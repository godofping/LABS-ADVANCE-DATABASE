using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pos.EL.Transactions
{
    public class orderdetails
    {
        int orderdetailid;
        int orderid;
        int productid;
        int quantity;
        float price;

        public int Orderdetailid
        {
            get { return orderdetailid; }
            set { orderdetailid = value; }
        }
        

        public int Orderid
        {
            get { return orderid; }
            set { orderid = value; }
        }
        

        public int Productid
        {
            get { return productid; }
            set { productid = value; }
        }
        

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        

        public float Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
