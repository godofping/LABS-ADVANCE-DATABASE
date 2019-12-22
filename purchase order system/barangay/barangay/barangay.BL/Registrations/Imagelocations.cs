using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Imagelocations
    {
        DL.Registrations.Imagelocations imagelocationDL = new DL.Registrations.Imagelocations();
        public EL.Registrations.Imagelocations Select(EL.Registrations.Imagelocations imagelocationEL)
        {
            return imagelocationDL.Select(imagelocationEL);
        }

        public long Insert(EL.Registrations.Imagelocations imagelocationEL)
        {
            return imagelocationDL.Insert(imagelocationEL);
        }

        public Boolean Update(EL.Registrations.Imagelocations imagelocationEL)
        {
            return imagelocationDL.Update(imagelocationEL);
        }

        public Boolean Delete(EL.Registrations.Imagelocations imagelocationEL)
        {
            return imagelocationDL.Delete(imagelocationEL);
        }
    }
}
