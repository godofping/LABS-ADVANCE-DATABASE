using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pos.EL.Transactions
{
    public class PurhcaseOrders
    {

        int purchaseorderid;
        int supplierid;
        int accountid;
        string purchaseordername;
        string purchaseorderrequestdate;
        string purchaseorderdeliverydate;
        string purchaseorderstatus;
        float purchaseordertotalamount;

        public int Purchaseorderid
        {
            get { return purchaseorderid; }
            set { purchaseorderid = value; }
        }

        public int Accountid
        {
            get { return accountid; }
            set { accountid = value; }
        }

        public int Supplierid
        {
            get { return supplierid; }
            set { supplierid = value; }
        }

        public string Purchaseordername
        {
            get { return purchaseordername; }
            set { purchaseordername = value; }
        }

        public string Purchaseorderrequestdate
        {
            get { return purchaseorderrequestdate; }
            set { purchaseorderrequestdate = value; }
        }

        public string Purchaseorderdeliverydate
        {
            get { return purchaseorderdeliverydate; }
            set { purchaseorderdeliverydate = value; }
        }

        public string Purchaseorderstatus
        {
            get { return purchaseorderstatus; }
            set { purchaseorderstatus = value; }
        }

        public float Purchaseordertotalamount
        {
            get { return purchaseordertotalamount; }
            set { purchaseordertotalamount = value; }
        }

    }
}
