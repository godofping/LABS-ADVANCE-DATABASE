namespace pos.DL.Registrations
{
    public class Addresses
    {
        public long Insert(EL.Registrations.Addresses addressEL)
        {
            return Helper.executeNonQueryLong("insert into addresses (address, city, zipcode, province) values ('" + addressEL.Address + "', '" + addressEL.City + "', '" + addressEL.Zipcode + "', '" + addressEL.Province + "')");
        }

        public bool Update(EL.Registrations.Addresses addressEL)
        {
            return Helper.executeNonQueryBool("update addresses set address = '" + addressEL.Address + "', city = '" + addressEL.City + "', zipcode = '" + addressEL.Zipcode + "', province = '" + addressEL.Province + "' where addressid = '" + addressEL.Addressid + "'");
        }
    }
}
