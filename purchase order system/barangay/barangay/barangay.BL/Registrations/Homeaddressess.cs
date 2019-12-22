using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Homeaddressess
    {
        DL.Registrations.Homeaddressess HomeaddressDL = new DL.Registrations.Homeaddressess();
        public EL.Registrations.Homeaddressess Select(EL.Registrations.Homeaddressess homeaddressEL)
        {
            return HomeaddressDL.Select(homeaddressEL);
        }

        public long Insert(EL.Registrations.Homeaddressess homeaddressEL)
        {
            return HomeaddressDL.Insert(homeaddressEL);
        }

        public Boolean Update(EL.Registrations.Homeaddressess homeaddressEL)
        {
            return HomeaddressDL.Update(homeaddressEL);
        }

        public Boolean Delete(EL.Registrations.Homeaddressess homeaddressEL)
        {
            return HomeaddressDL.Delete(homeaddressEL);
        }
    }
}
