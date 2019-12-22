using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Residentscitizenship
    {
        DL.Registrations.Residentscitizenship residentcitizenshipDL = new DL.Registrations.Residentscitizenship();
        public EL.Registrations.Residentscitizenship Select(EL.Registrations.Residentscitizenship residentcitizenshipEL)
        {
            return residentcitizenshipDL.Select(residentcitizenshipEL);
        }

        public long Insert(EL.Registrations.Residentscitizenship residentcitizenshipEL)
        {
            return residentcitizenshipDL.Insert(residentcitizenshipEL);
        }

        public Boolean Update(EL.Registrations.Residentscitizenship residentcitizenshipEL)
        {
            return residentcitizenshipDL.Update(residentcitizenshipEL);
        }

        public Boolean Delete(EL.Registrations.Residentscitizenship residentcitizenshipEL)
        {
            return residentcitizenshipDL.Delete(residentcitizenshipEL);   
        }
    }
}
