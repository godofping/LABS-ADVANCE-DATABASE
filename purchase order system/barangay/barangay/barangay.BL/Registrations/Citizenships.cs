using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Citizenships
    {
        DL.Registrations.Citizenships citizenshipDL = new DL.Registrations.Citizenships();
        public DataTable List()
        {
            return citizenshipDL.List();
        }

        public EL.Registrations.Citizenships Select(EL.Registrations.Citizenships citizenshipEL)
        {
            return citizenshipDL.Select(citizenshipEL);
        }
    }
}
