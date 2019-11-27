using System;
using System.Collections.Generic;
using System.Text;

namespace WATER_REFILLING_STATION.EL.REGISTRATIONS
{
    public class customers
    {
        int customerid;
        int basicinformationid;
        string dateregistered;

        public int Customerid { get => customerid; set => customerid = value; }
        public int Basicinformationid { get => basicinformationid; set => basicinformationid = value; }
        public string Dateregistered { get => dateregistered; set => dateregistered = value; }
    }
}
