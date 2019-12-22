using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Residentscivilstatus
    {
        DL.Registrations.Residentscivilstatus residentcivilstatusDL = new DL.Registrations.Residentscivilstatus();
        public EL.Registrations.Residentscivilstatus Select(EL.Registrations.Residentscivilstatus residentcivilstatusEL)
        {
            return residentcivilstatusDL.Select(residentcivilstatusEL);
        }

        public long Insert(EL.Registrations.Residentscivilstatus residentcivilstatusEL)
        {
            return residentcivilstatusDL.Insert(residentcivilstatusEL);
        }

        public Boolean Update(EL.Registrations.Residentscivilstatus residentcivilstatusEL)
        {
            return residentcivilstatusDL.Update(residentcivilstatusEL);
        }

        public Boolean Delete(EL.Registrations.Residentscivilstatus residentcivilstatusEL)
        {
            return residentcivilstatusDL.Delete(residentcivilstatusEL);
        }
    }
}
