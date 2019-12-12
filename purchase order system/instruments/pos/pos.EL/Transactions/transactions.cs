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
    }
}
