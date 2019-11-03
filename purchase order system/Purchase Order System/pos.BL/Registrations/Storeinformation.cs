using System.Data;

namespace pos.BL.Registrations
{
    public class StoreInformation
    {
        DL.Registrations.StoreInformation StoreInformationDL = new DL.Registrations.StoreInformation();
        public DataTable List()
        {
            return StoreInformationDL.List();
        }

        public bool Update(EL.Registrations.StoreInformation storeInformationEL)
        {
            return StoreInformationDL.Update(storeInformationEL);
        }

    }
}
