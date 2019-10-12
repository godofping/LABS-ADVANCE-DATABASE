using System;
using System.Collections.Generic;
using System.Text;

namespace pos.BL.Registrations
{
    public class Basicinformations
    {
        DL.Registrations.Basicinformations BasicinformationDL = new DL.Registrations.Basicinformations();

        public long Insert(EL.Registrations.Basicinformations basicinformation)
        {
            return BasicinformationDL.Insert(basicinformation);
        }

        public bool Update(EL.Registrations.Basicinformations basicinformation)
        {
            return BasicinformationDL.Update(basicinformation);
        }
    }
}
