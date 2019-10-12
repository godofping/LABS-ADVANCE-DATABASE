namespace pos.DL.Registrations
{
    public class Contactdetails
    {
        public long Insert(EL.Registrations.Contactdetails contactdetail)
        {
            return Helper.executeNonQueryLong("insert into contactdetails (addressid, contactnumber, emailaddress) values ('" + contactdetail.Addressid + "', '" + contactdetail.Contactnumber + "', '" + contactdetail.Emailaddress + "')");
        }

        public bool Update(EL.Registrations.Contactdetails contactdetail)
        {
            return Helper.executeNonQueryBool("update contactdetails set contactnumber = '" + contactdetail.Contactnumber + "', emailaddress = '" + contactdetail.Emailaddress + "' where contactdetailid = '" + contactdetail.Contactdetailid + "'");
        }
    }
}
