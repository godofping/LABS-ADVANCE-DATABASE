using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WATER_REFILLING_STATION.BL.REGISTRATIONS
{
    public class customertypes
    {
        DL.REGISTRATIONS.customertypes customertypeDL = new DL.REGISTRATIONS.customertypes();

        public DataTable List()
        {
            return customertypeDL.List();
        }
    }
}
