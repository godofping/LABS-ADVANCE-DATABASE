using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Puroks
    {
        DL.Registrations.Puroks purokDL = new DL.Registrations.Puroks();
        public DataTable List()
        {
            return purokDL.List();
        }

        public EL.Registrations.Puroks Select(EL.Registrations.Puroks purokEL)
        {
            return purokDL.Select(purokEL);
        }
    }
}
