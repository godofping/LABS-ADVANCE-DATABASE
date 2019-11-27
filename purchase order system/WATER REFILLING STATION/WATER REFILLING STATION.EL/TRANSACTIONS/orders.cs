using System;
using System.Collections.Generic;
using System.Text;

namespace WATER_REFILLING_STATION.EL.TRANSACTIONS
{
    public class orders
    {
        int orderid;
        int staffaccountid;
        int customertypeid;
        int deliverymodetypeid;
        string orderdatetime;
        float totalamount;
        float cashtendered;
        float change;
        int isvoid;

        public int Orderid { get => orderid; set => orderid = value; }
        public int Staffaccountid { get => staffaccountid; set => staffaccountid = value; }
        public int Customertypeid { get => customertypeid; set => customertypeid = value; }
        public int Deliverymodetypeid { get => deliverymodetypeid; set => deliverymodetypeid = value; }
        public string Orderdatetime { get => orderdatetime; set => orderdatetime = value; }
        public float Totalamount { get => totalamount; set => totalamount = value; }
        public float Cashtendered { get => cashtendered; set => cashtendered = value; }
        public float Change { get => change; set => change = value; }
        public int Isvoid { get => isvoid; set => isvoid = value; }
    }
}
