using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Registrations
{
    public class SubCategories
    {
        int subcategoryid;
        string subcategoryname;
        int categoryid;

        public int Subcategoryid { get => subcategoryid; set => subcategoryid = value; }
        public string Subcategoryname { get => subcategoryname; set => subcategoryname = value; }
        public int Categoryid { get => categoryid; set => categoryid = value; }
    }
}
