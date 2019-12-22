using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Sexes
    {
        DL.Registrations.Sexes sexDL = new DL.Registrations.Sexes();
        public DataTable List()
        {
            return sexDL.List();
        }

        public EL.Registrations.Sexes Select(EL.Registrations.Sexes sexEL)
        {
            return sexDL.Select(sexEL);
        }
    }
}
