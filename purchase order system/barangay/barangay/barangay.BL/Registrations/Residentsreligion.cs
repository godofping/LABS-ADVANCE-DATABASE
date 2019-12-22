using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Residentsreligion
    {
        DL.Registrations.Residentsreligion residentreligionDL = new DL.Registrations.Residentsreligion();
        public EL.Registrations.Residentsreligion Select(EL.Registrations.Residentsreligion residentreligionEL)
        {
            return residentreligionDL.Select(residentreligionEL);
        }

        public long Insert(EL.Registrations.Residentsreligion residentreligionEL)
        {
            return residentreligionDL.Insert(residentreligionEL);
        }

        public Boolean Update(EL.Registrations.Residentsreligion residentreligionEL)
        {
            return residentreligionDL.Update(residentreligionEL);
        }

        public Boolean Delete(EL.Registrations.Residentsreligion residentreligionEL)
        {
            return residentreligionDL.Delete(residentreligionEL);
        }
    }
}
