using System;
using System.Collections.Generic;
using System.Text;

namespace pos.BL.Registrations
{
    public class ContactDetails
    {
        DL.Registrations.ContactDetails ContactDetailDL = new DL.Registrations.ContactDetails();

        public long Insert(EL.Registrations.ContactDetails contactDetailEL)
        {
            return ContactDetailDL.Insert(contactDetailEL);
        }

        public bool Update(EL.Registrations.ContactDetails contactDetailEL)
        {
            return ContactDetailDL.Update(contactDetailEL);
        }
    }
}
