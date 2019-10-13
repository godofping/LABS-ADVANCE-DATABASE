using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Registrations
{
    public class Categories
    {
        int categoryid;
        string categoryname;
        int isdeleted;

        public int Categoryid { get => categoryid; set => categoryid = value; }
        public string Categoryname { get => categoryname; set => categoryname = value; }
        public int Isdeleted { get => isdeleted; set => isdeleted = value; }
    }
}
