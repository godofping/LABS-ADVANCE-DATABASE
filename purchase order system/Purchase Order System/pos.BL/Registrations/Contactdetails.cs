using System;
using System.Collections.Generic;
using System.Text;

namespace pos.BL.Registrations
{
    public class Contactdetails
    {
        public long Insert(EL.Registrations.Contactdetails contactdetail)
        {
            DL.Registrations.Contactdetails ContactDetailDL = new DL.Registrations.Contactdetails();
            return ContactDetailDL.Insert(contactdetail);
        }
    }
}
