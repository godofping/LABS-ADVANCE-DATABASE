using System.Data;

namespace pos.BL.Registrations
{
    public class Storeinformation
    {
        DL.Registrations.Storeinformation StoreInformationDL = new DL.Registrations.Storeinformation();
        public DataTable List()
        {
            return StoreInformationDL.List();
        }

        public bool Update(EL.Registrations.Storeinformation storeinformation)
        {
            return StoreInformationDL.Update(storeinformation);
        }

    }
}
