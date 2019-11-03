namespace pos.DL.Registrations
{
    public class ContactDetails
    {
        public long Insert(EL.Registrations.ContactDetails contactDetailEL)
        {
            return Helper.executeNonQueryLong("insert into contactdetails (addressid, contactnumber, emailaddress) values ('" + contactDetailEL.Addressid + "', '" + contactDetailEL.Contactnumber + "', '" + contactDetailEL.Emailaddress + "')");
        }

        public bool Update(EL.Registrations.ContactDetails contactDetailEL)
        {
            return Helper.executeNonQueryBool("update contactdetails set contactnumber = '" + contactDetailEL.Contactnumber + "', emailaddress = '" + contactDetailEL.Emailaddress + "' where contactdetailid = '" + contactDetailEL.Contactdetailid + "'");
        }
    }
}
