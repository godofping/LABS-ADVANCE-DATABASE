namespace pos.DL.Registrations
{
    public class Addresses
    {
        public long Insert(EL.Registrations.Addresses address)
        {
            return Helper.executeNonQuery("insert into addresses (address, city, zipcode, province) values ('" + address.Address + "', '" + address.City + "', '" + address.Zipcode + "', '" + address.Province + "')");
        }
    }
}
