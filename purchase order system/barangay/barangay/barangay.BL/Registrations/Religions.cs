using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Religions
    {
        DL.Registrations.Religions religionDL = new DL.Registrations.Religions();
        public DataTable List()
        {
            return religionDL.List();
        }

        public EL.Registrations.Religions Select(EL.Registrations.Religions religionEL)
        {
            return religionDL.Select(religionEL);
        }
    }
}
