using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Birthinformations
    {
        DL.Registrations.Birthinformations birthinformationDL = new DL.Registrations.Birthinformations();
        public EL.Registrations.Birthinformations Select(EL.Registrations.Birthinformations birthinformationEL)
        {
            return birthinformationDL.Select(birthinformationEL);
        }

        public long Insert(EL.Registrations.Birthinformations birthinformationEL)
        {
            return birthinformationDL.Insert(birthinformationEL);
        }

        public Boolean Update(EL.Registrations.Birthinformations birthinformationEL)
        {
            return birthinformationDL.Update(birthinformationEL);
        }

        public Boolean Delete(EL.Registrations.Birthinformations birthinformationEL)
        {
            return birthinformationDL.Delete(birthinformationEL);
        }
    }
}
