using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Residentsoccupation
    {
        DL.Registrations.Residentsoccupation residentoccupationDL = new DL.Registrations.Residentsoccupation();
        public EL.Registrations.Residentsoccupation Select(EL.Registrations.Residentsoccupation residentoccupationEL)
        {
            return residentoccupationDL.Select(residentoccupationEL);
        }

        public long Insert(EL.Registrations.Residentsoccupation residentoccupationEL)
        {
            return residentoccupationDL.Insert(residentoccupationEL);
        }

        public Boolean Update(EL.Registrations.Residentsoccupation residentoccupationEL)
        {
            return residentoccupationDL.Update(residentoccupationEL);
        }

        public Boolean Delete(EL.Registrations.Residentsoccupation residentoccupationEL)
        {
            return residentoccupationDL.Delete(residentoccupationEL);
        }
    }
}
