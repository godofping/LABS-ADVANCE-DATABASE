using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Certifications
    {
        DL.Registrations.Certifications certificationDL = new DL.Registrations.Certifications();
        public DataTable List()
        {
            return certificationDL.List();
        }

        public EL.Registrations.Certifications Select(EL.Registrations.Certifications certificationEL)
        {
            return certificationDL.Select(certificationEL);
        }
    }
}
