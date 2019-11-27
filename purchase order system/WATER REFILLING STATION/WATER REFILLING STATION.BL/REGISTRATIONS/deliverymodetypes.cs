using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WATER_REFILLING_STATION.BL.REGISTRATIONS
{
    public class deliverymodetypes
    {
        DL.REGISTRATIONS.deliverymodetypes deliverymodetypeDL = new DL.REGISTRATIONS.deliverymodetypes();
        public DataTable List()
        {
            return deliverymodetypeDL.List();
        }
    }
}
