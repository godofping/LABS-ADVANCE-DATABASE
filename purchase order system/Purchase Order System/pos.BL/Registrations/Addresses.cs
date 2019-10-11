using System.Data;

namespace pos.BL.Registrations
{
    public class Addresses
    {
        public long Insert(EL.Registrations.Addresses address)
        {
            DL.Registrations.Addresses AddressDL = new DL.Registrations.Addresses();
            return AddressDL.Insert(address);
        }
    }
}
