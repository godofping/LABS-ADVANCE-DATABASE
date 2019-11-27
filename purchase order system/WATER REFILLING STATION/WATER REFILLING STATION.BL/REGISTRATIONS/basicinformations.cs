using System;
using System.Collections.Generic;
using System.Text;

namespace WATER_REFILLING_STATION.BL.REGISTRATIONS
{
    public class basicinformations
    {
        DL.REGISTRATIONS.basicinformations basicinformationDL = new DL.REGISTRATIONS.basicinformations();

        public long Insert(EL.REGISTRATIONS.basicinformations basicinformationEL)
        {
            return basicinformationDL.Insert(basicinformationEL);
        }

        public bool Update(EL.REGISTRATIONS.basicinformations basicinformationEL)
        {
            return basicinformationDL.Update(basicinformationEL);
        }
    }
}
