using System.Data;

namespace pos.DL.Registrations
{
    public class StoreInformation
    {
        public DataTable List()
        {
            string sQuery = "select * from storeinformation_view";
            return Helper.executeQuery(sQuery);
        }


        public bool Update(EL.Registrations.StoreInformation storeInformationEL)
        {
            return Helper.executeNonQueryBool("update storeinformation set storename = '" + storeInformationEL.Storename + "' ");
        }


    }
}
