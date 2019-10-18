﻿using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Transactions
{
    public class Purchaseorders
    {
        int purchaseorderid;
        int staffid;
        int supplierid;
        string purchaseorderstatus;
        float purchaseorderamountpaid;
        float purchasetotalorderamount;
        string purchaseorderdatedelivered;
        string purchaseorderdaterequested;
        string purchaseordercomment;
        int isdeleted;

        public int Purchaseorderid { get => purchaseorderid; set => purchaseorderid = value; }
        public int Staffid { get => staffid; set => staffid = value; }
        public int Supplierid { get => supplierid; set => supplierid = value; }
        public string Purchaseorderstatus { get => purchaseorderstatus; set => purchaseorderstatus = value; }
        public float Purchaseorderamountpaid { get => purchaseorderamountpaid; set => purchaseorderamountpaid = value; }
        public float Purchasetotalorderamount { get => purchasetotalorderamount; set => purchasetotalorderamount = value; }
        public string Purchaseorderdatedelivered { get => purchaseorderdatedelivered; set => purchaseorderdatedelivered = value; }
        public string Purchaseorderdaterequested { get => purchaseorderdaterequested; set => purchaseorderdaterequested = value; }
        public string Purchaseordercomment { get => purchaseordercomment; set => purchaseordercomment = value; }
        public int Isdeleted { get => isdeleted; set => isdeleted = value; }
    }
}
