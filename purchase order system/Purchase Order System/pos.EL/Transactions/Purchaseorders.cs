using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Transactions
{
    public class Purchaseorders
    {
        int purchaseorderid;
        int staffid;
        int vendorid;
        int purchaseorderstatus;
        int purchaseorderamountpaid;
        int purchasetotalorderamount;
        int purchaseorderdatedelivered;
        int purchaseorderdaterequested;

        public int Purchaseorderid { get => purchaseorderid; set => purchaseorderid = value; }
        public int Staffid { get => staffid; set => staffid = value; }
        public int Vendorid { get => vendorid; set => vendorid = value; }
        public int Purchaseorderstatus { get => purchaseorderstatus; set => purchaseorderstatus = value; }
        public int Purchaseorderamountpaid { get => purchaseorderamountpaid; set => purchaseorderamountpaid = value; }
        public int Purchasetotalorderamount { get => purchasetotalorderamount; set => purchasetotalorderamount = value; }
        public int Purchaseorderdatedelivered { get => purchaseorderdatedelivered; set => purchaseorderdatedelivered = value; }
        public int Purchaseorderdaterequested { get => purchaseorderdaterequested; set => purchaseorderdaterequested = value; }
    }
}
