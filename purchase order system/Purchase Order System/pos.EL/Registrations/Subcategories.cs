using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Registrations
{
    public class Subcategories
    {
        int subcategoryid;
        string subcategory;
        int categoryid;

        public int Subcategoryid { get => subcategoryid; set => subcategoryid = value; }
        public string Subcategory { get => subcategory; set => subcategory = value; }
        public int Categoryid { get => categoryid; set => categoryid = value; }
    }
}
