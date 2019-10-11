using System;
using System.Collections.Generic;
using System.Text;

namespace pos.BL.Registrations
{
    public class Basicinformations
    {
        public long Insert(EL.Registrations.Basicinformations basicinformation)
        {
            DL.Registrations.Basicinformations BasicinformationDL = new DL.Registrations.Basicinformations();
            return BasicinformationDL.Insert(basicinformation);
        }
    }
}
