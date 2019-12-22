using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Provincialaddresses
    {
        DL.Registrations.Provincialaddresses provincialaddressDL = new DL.Registrations.Provincialaddresses();
        public EL.Registrations.Provincialaddresses Select(EL.Registrations.Provincialaddresses provincialaddressEL)
        {
            return provincialaddressDL.Select(provincialaddressEL);
        }

        public long Insert(EL.Registrations.Provincialaddresses provincialaddressEL)
        {
            return provincialaddressDL.Insert(provincialaddressEL);
        }

        public Boolean Update(EL.Registrations.Provincialaddresses provincialaddressEL)
        {
            return provincialaddressDL.Update(provincialaddressEL);
        }

        public Boolean Delete(EL.Registrations.Provincialaddresses provincialaddressEL)
        {
            return provincialaddressDL.Delete(provincialaddressEL);
        }
    }
}
