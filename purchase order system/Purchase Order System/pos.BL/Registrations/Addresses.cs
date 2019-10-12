using System.Data;

namespace pos.BL.Registrations
{
    public class Addresses
    {
        DL.Registrations.Addresses AddressDL = new DL.Registrations.Addresses();
        public long Insert(EL.Registrations.Addresses address)
        {
            return AddressDL.Insert(address);
        }

        public bool Update(EL.Registrations.Addresses address)
        {
            return AddressDL.Update(address);
        }


    }
}
