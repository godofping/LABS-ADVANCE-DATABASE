using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Sex
    {
        DL.Registrations.Sex sexDL = new DL.Registrations.Sex();
        public DataTable List()
        {
            return sexDL.List();
        }

        public EL.Registrations.Sex Select(EL.Registrations.Sex sexEL)
        {
            return sexDL.Select(sexEL);
        }
    }
}
