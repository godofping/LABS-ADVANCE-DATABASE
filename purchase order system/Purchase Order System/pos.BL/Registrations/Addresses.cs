using System.Data;

namespace pos.BL.Registrations
{
    public class Addresses
    {
        DL.Registrations.Addresses addressDL = new DL.Registrations.Addresses();

        public long Insert(EL.Registrations.Addresses addressEL)
        {
            return addressDL.Insert(addressEL);
        }

        public bool Update(EL.Registrations.Addresses addressEL)
        {
            return addressDL.Update(addressEL);
        }


    }
}
