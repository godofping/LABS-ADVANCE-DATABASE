using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Registrations
{
   public class Inventories
    {
        int inventoryid;
        int productid;
        int quantityinstocks;
        int reorderlevel;

        public int Inventoryid { get => inventoryid; set => inventoryid = value; }
        public int Productid { get => productid; set => productid = value; }
        public int Quantityinstocks { get => quantityinstocks; set => quantityinstocks = value; }
        public int Reorderlevel { get => reorderlevel; set => reorderlevel = value; }
    }
}
