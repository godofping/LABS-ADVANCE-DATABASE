using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Residentssex
    {
        DL.Registrations.Residentssex residentsexDL = new DL.Registrations.Residentssex();
        public EL.Registrations.Residentssex Select(EL.Registrations.Residentssex residentsexEL)
        {
            return residentsexDL.Select(residentsexEL);
        }

        public long Insert(EL.Registrations.Residentssex residentsexEL)
        {
            return residentsexDL.Insert(residentsexEL);
        }

        public Boolean Update(EL.Registrations.Residentssex residentsexEL)
        {
            return residentsexDL.Update(residentsexEL);
        }

        public Boolean Delete(EL.Registrations.Residentssex residentsexEL)
        {
            return residentsexDL.Delete(residentsexEL);
        }
    }
}
