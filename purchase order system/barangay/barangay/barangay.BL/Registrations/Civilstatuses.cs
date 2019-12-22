using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Civilstatuses
    {
        DL.Registrations.Civilstatuses CivilstatusDL = new DL.Registrations.Civilstatuses();
        public DataTable List()
        {
            return CivilstatusDL.List();
        }

        public EL.Registrations.Civilstatuses Select(EL.Registrations.Civilstatuses civilstatusEL)
        {
            return CivilstatusDL.Select(civilstatusEL);
        }
    }
}
