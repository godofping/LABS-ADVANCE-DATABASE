using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.BL.Registrations
{
    public class Contactdetails
    {
        DL.Registrations.Contactdetails contactdetailDL = new DL.Registrations.Contactdetails();
        public EL.Registrations.Contactdetails Select(EL.Registrations.Contactdetails contactdetailEL)
        {
            return contactdetailDL.Select(contactdetailEL);
        }

        public long Insert(EL.Registrations.Contactdetails contactdetailEL)
        {
            return contactdetailDL.Insert(contactdetailEL);
        }

        public Boolean Update(EL.Registrations.Contactdetails contactdetailEL)
        {
            return contactdetailDL.Update(contactdetailEL);
        }

        public Boolean Delete(EL.Registrations.Contactdetails contactdetailEL)
        {
            return contactdetailDL.Delete(contactdetailEL);
        }
    }
}
