using System;
using System.Collections.Generic;
using System.Text;

namespace WATER_REFILLING_STATION.EL.REGISTRATIONS
{
    public class products
    {
        int productid;
        int productcategoryid;
        int particularid;
        int containertypeid;
        float price;

        public int Productid { get => productid; set => productid = value; }
        public int Productcategoryid { get => productcategoryid; set => productcategoryid = value; }
        public int Particularid { get => particularid; set => particularid = value; }
        public int Containertypeid { get => containertypeid; set => containertypeid = value; }
        public float Price { get => price; set => price = value; }
    }
}
