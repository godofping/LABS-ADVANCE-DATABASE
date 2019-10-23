using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pos.EL.Registrations
{
    public class Supplies
    {
        int supplyid;
        string supplyname;
        string supplyunit;
        float supplyunitprice;
        int supplystocks;


        public int Supplyid
        {
            get { return supplyid; }
            set { supplyid = value; }
        }

        public string Supplyname
        {
            get { return supplyname; }
            set { supplyname = value; }
        }

        public string Supplyunit
        {
            get { return supplyunit; }
            set { supplyunit = value; }
        }

        public float Supplyunitprice
        {
            get { return supplyunitprice; }
            set { supplyunitprice = value; }
        }

        public int Supplystocks
        {
            get { return supplystocks; }
            set { supplystocks = value; }
        }

    }
}
