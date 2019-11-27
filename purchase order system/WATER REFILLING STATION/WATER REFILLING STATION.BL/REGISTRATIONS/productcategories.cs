using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WATER_REFILLING_STATION.BL.REGISTRATIONS
{
    public class productcategories
    {
        DL.REGISTRATIONS.productcategories productcategoryDL = new DL.REGISTRATIONS.productcategories();
        public DataTable List()
        {
            return productcategoryDL.List();
        }
    }
}
