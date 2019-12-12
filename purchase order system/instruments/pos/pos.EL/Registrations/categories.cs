using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.EL.Registrations
{
    public class categories
    {
        int categoryid;
        string category;

        public int Categoryid
        {
            get
            {
                return categoryid;
            }

            set
            {
                categoryid = value;
            }
        }

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }
    }
}
