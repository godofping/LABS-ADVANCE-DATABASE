using System.Data;

namespace pos.BL.Registrations
{
    public class Addresses
    {
        DL.Registrations.Addresses addressDL = new DL.Registrations.Addresses();
        public long Insert(EL.Registrations.Addresses address)
        {
            return addressDL.Insert(address);
        }

        public bool Update(EL.Registrations.Addresses address)
        {
            return addressDL.Update(address);
        }


    }
}
