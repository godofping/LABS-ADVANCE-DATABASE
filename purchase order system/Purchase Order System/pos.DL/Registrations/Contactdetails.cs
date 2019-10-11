namespace pos.DL.Registrations
{
    public class Contactdetails
    {
        public long Insert(EL.Registrations.Contactdetails contactdetail)
        {
            return Helper.executeNonQuery("insert into contactdetails (addressid, contactnumber, emailaddress) values ('" + contactdetail.Addressid + "', '" + contactdetail.Contactnumber + "', '" + contactdetail.Emailaddress + "')");
        }
    }
}
