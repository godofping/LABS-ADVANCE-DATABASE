using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pos.EL.Transactions
{
    public class Orders
    {
        //instance Variables
        int orderid	;
        int customerid;

    
        String date	;
        decimal amountpaid	;
        decimal amountrecieved	;
        decimal changeamount	;
        String status	;
       

        //Properties
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
         public String Date
        {
            get { return date; }
            set { date = value; }
        }
         public decimal Amountpaid
         {
             get { return amountpaid; }
             set { amountpaid = value; }
         }
         public decimal Amountrecieved
         {
             get { return amountrecieved; }
             set { amountrecieved = value; }
         }
         public decimal Changeamount
         {
             get { return changeamount; }
             set { changeamount = value; }
         }
         public String Status
         {
             get { return status; }
             set { status = value; }
         }

    }
}
