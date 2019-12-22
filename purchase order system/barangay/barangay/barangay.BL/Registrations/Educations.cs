using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Educations
    {
        DL.Registrations.Educations educationDL = new DL.Registrations.Educations();
        public EL.Registrations.Educations Select(EL.Registrations.Educations educationEL)
        {
            return educationDL.Select(educationEL);
        }

        public long Insert(EL.Registrations.Educations educationEL)
        {
            return educationDL.Insert(educationEL);
        }

        public Boolean Update(EL.Registrations.Educations educationEL)
        {
            return educationDL.Update(educationEL);   
        }

        public Boolean Delete(EL.Registrations.Educations educationEL)
        {
            return educationDL.Delete(educationEL);
        }
    }
}
