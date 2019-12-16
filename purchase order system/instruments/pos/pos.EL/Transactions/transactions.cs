using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.EL.Transactions
{
    public class transactions
    {
        int transactionid;
        int customerid;
        string transactiondatetime;
        float totalamount;
        float amounttendered;
        float changeamount;
        int isvoid;


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

        public int Customerid
        {
            get
            {
                return customerid;
            }

            set
            {
                customerid = value;
            }
        }

        public string Transactiondatetime
        {
            get
            {
                return transactiondatetime;
            }

            set
            {
                transactiondatetime = value;
            }
        }

        public float Totalamount
        {
            get
            {
                return totalamount;
            }

            set
            {
                totalamount = value;
            }
        }

        public float Amounttendered
        {
            get
            {
                return amounttendered;
            }

            set
            {
                amounttendered = value;
            }
        }

        public float ChangeAmount
        {
            get
            {
                return changeamount;
            }

            set
            {
                changeamount = value;
            }
        }

        public int Isvoid
        {
            get
            {
                return isvoid;
            }

            set
            {
                isvoid = value;
            }
        }
    }
}
