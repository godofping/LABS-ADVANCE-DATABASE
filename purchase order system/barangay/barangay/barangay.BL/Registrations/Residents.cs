using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Residents
    {
        DL.Registrations.Residents residentDL = new DL.Registrations.Residents();
        public DataTable List(String keyword)
        {
            return residentDL.List(keyword);
        }

        public EL.Registrations.Residents Select(EL.Registrations.Residents residentEL)
        {
            return residentDL.Select(residentEL);
        }

        public long Insert(EL.Registrations.Residents residentEL)
        {
            return residentDL.Insert(residentEL);
        }

        public Boolean Update(EL.Registrations.Residents residentEL)
        {
            return residentDL.Update(residentEL);
        }

        public Boolean Delete(EL.Registrations.Residents residentEL)
        {
            return residentDL.Delete(residentEL);
        }
    }
}
