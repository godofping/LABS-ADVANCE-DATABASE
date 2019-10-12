namespace pos.DL.Registrations
{
    public class Addresses
    {
        public long Insert(EL.Registrations.Addresses address)
        {
            return Helper.executeNonQueryLong("insert into addresses (address, city, zipcode, province) values ('" + address.Address + "', '" + address.City + "', '" + address.Zipcode + "', '" + address.Province + "')");
        }

        public bool Update(EL.Registrations.Addresses address)
        {
            return Helper.executeNonQueryBool("update addresses set address = '" + address.Address + "', city = '" + address.City + "', zipcode = '" + address.Zipcode + "', province = '" + address.Province + "' where addressid = '" + address.Addressid + "'");
        }
    }
}
