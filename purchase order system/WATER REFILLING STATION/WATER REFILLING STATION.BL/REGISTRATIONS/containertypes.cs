using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WATER_REFILLING_STATION.BL.REGISTRATIONS
{
    public class containertypes
    {
        DL.REGISTRATIONS.containertypes containertypeDL = new DL.REGISTRATIONS.containertypes();

        public DataTable List()
        {
            return containertypeDL.List();
        }
    }
}
