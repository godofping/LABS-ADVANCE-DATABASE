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
        int isdeleted;

        public int Subcategoryid { get => subcategoryid; set => subcategoryid = value; }
        public string Subcategoryname { get => subcategoryname; set => subcategoryname = value; }
        public int Categoryid { get => categoryid; set => categoryid = value; }
        public int Isdeleted { get => isdeleted; set => isdeleted = value; }
    }
}
