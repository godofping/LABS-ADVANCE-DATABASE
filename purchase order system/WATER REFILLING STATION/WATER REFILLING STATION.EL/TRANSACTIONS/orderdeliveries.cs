using System;
using System.Collections.Generic;
using System.Text;

namespace WATER_REFILLING_STATION.EL.TRANSACTIONS
{
    public class orderdeliveries
    {
        int orderdeliveryid;
        int orderid;
        string deliveryaddress;
        float deliveryfee;
        string datedelivered;
        string deliverystatus;

        public int Orderdeliveryid { get => orderdeliveryid; set => orderdeliveryid = value; }
        public int Orderid { get => orderid; set => orderid = value; }
        public string Deliveryaddress { get => deliveryaddress; set => deliveryaddress = value; }
        public float Deliveryfee { get => deliveryfee; set => deliveryfee = value; }
        public string Datedelivered { get => datedelivered; set => datedelivered = value; }
        public string Deliverystatus { get => deliverystatus; set => deliverystatus = value; }
    }
}
