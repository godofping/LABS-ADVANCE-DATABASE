using System;
using System.Collections.Generic;
using System.Text;

namespace pos.BL.Registrations
{
    public class Contactdetails
    {
        DL.Registrations.Contactdetails ContactDetailDL = new DL.Registrations.Contactdetails();

        public long Insert(EL.Registrations.Contactdetails contactdetail)
        {
            return ContactDetailDL.Insert(contactdetail);
        }

        public bool Update(EL.Registrations.Contactdetails contactdetail)
        {
            return ContactDetailDL.Update(contactdetail);
        }
    }
}
