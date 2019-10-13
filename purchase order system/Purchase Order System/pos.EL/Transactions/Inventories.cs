using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Transactions
{
   public class Inventories
    {
        int inventoryid;
        int productid;
        int quantityinstocks;
        int reorderlevel;
        string inventorylastupdated;

        public int Inventoryid { get => inventoryid; set => inventoryid = value; }
        public int Productid { get => productid; set => productid = value; }
        public int Quantityinstocks { get => quantityinstocks; set => quantityinstocks = value; }
        public int Reorderlevel { get => reorderlevel; set => reorderlevel = value; }
        public string Inventorylastupdated { get => inventorylastupdated; set => inventorylastupdated = value; }
    }
}
