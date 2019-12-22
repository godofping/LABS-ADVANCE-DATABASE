using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Filelocations
    {
        DL.Registrations.Filelocations filelocationDL = new DL.Registrations.Filelocations();
        public EL.Registrations.Filelocations Select(EL.Registrations.Filelocations filelocationEL)
        {
            return filelocationDL.Select(filelocationEL);
        }

        public long Insert(EL.Registrations.Filelocations filelocationEL)
        {
            return filelocationDL.Insert(filelocationEL);
        }

        public Boolean Update(EL.Registrations.Filelocations filelocationEL)
        {
            return filelocationDL.Update(filelocationEL);
        }

        public Boolean Delete(EL.Registrations.Filelocations filelocationEL)
        {
            return filelocationDL.Delete(filelocationEL);
        }
    }
}
