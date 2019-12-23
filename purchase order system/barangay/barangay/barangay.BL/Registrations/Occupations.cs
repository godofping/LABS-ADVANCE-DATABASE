using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Occupations
    {
        DL.Registrations.Occupations occupationDL = new DL.Registrations.Occupations();
        public DataTable List()
        {
            return occupationDL.List();
        }

        public EL.Registrations.Occupations Select(EL.Registrations.Occupations occupationEL)
        {
            return occupationDL.Select(occupationEL);
        }
    }
}
