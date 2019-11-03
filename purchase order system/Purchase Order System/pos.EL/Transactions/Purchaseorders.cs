using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Transactions
{
    public class PurchaseOrders
    {
        int purchaseorderid;
        int staffid;
        string purchaseordername;
        int supplierid;
        int paymentmethodid;
        int shippingmethodid;
        string purchaseorderstatus;
        float purchaseorderamountpaid;
        float purchasetotalorderamount;
        string purchaseorderdatedelivered;
        string purchaseorderdaterequested;
        string purchaseordercomment;
        int isdeleted;

        public int Purchaseorderid { get => purchaseorderid; set => purchaseorderid = value; }
        public int Staffid { get => staffid; set => staffid = value; }
        public string Purchaseordername { get => purchaseordername; set => purchaseordername = value; }
        public int Supplierid { get => supplierid; set => supplierid = value; }
        public int Paymentmethodid { get => paymentmethodid; set => paymentmethodid = value; }
        public int Shippingmethodid { get => shippingmethodid; set => shippingmethodid = value; }
        public string Purchaseorderstatus { get => purchaseorderstatus; set => purchaseorderstatus = value; }
        public float Purchaseorderamountpaid { get => purchaseorderamountpaid; set => purchaseorderamountpaid = value; }
        public float Purchasetotalorderamount { get => purchasetotalorderamount; set => purchasetotalorderamount = value; }
        public string Purchaseorderdatedelivered { get => purchaseorderdatedelivered; set => purchaseorderdatedelivered = value; }
        public string Purchaseorderdaterequested { get => purchaseorderdaterequested; set => purchaseorderdaterequested = value; }
        public string Purchaseordercomment { get => purchaseordercomment; set => purchaseordercomment = value; }
        public int Isdeleted { get => isdeleted; set => isdeleted = value; }
    }
}
