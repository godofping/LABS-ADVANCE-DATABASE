using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.EL.Transactions
{
    public class productsintransactions
    {
        int productintransactionid;
        int transactionid;
        int productid;
        float soldprice;
        int quantity;
        float amount;

        public int Productintransactionid
        {
            get
            {
                return productintransactionid;
            }

            set
            {
                productintransactionid = value;
            }
        }

        public int Transactionid
        {
            get
            {
                return transactionid;
            }

            set
            {
                transactionid = value;
            }
        }

        public int Productid
        {
            get
            {
                return productid;
            }

            set
            {
                productid = value;
            }
        }

        public float Soldprice
        {
            get
            {
                return soldprice;
            }

            set
            {
                soldprice = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public float Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }
    }
}
