using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Educationalattainments
    {
        DL.Registrations.Educationalattainments educationalattainmentDL = new DL.Registrations.Educationalattainments();
        public DataTable List()
        {
            return educationalattainmentDL.List();
        }

        public EL.Registrations.Educationalattainments Select(EL.Registrations.Educationalattainments educationalattainmentEL)
        {
            return educationalattainmentDL.Select(educationalattainmentEL);
        }
    }
}
