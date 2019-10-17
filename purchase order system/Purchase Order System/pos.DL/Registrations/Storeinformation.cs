using System.Data;

namespace pos.DL.Registrations
{
    public class Storeinformation
    {
        public DataTable List()
        {
            string sQuery = "select * from storeinformation_view";
            return Helper.executeQuery(sQuery);
        }


        public bool Update(EL.Registrations.Storeinformation storeinformation)
        {
            return Helper.executeNonQueryBool("update storeinformation set storename = '" + storeinformation.Storename + "' ");
        }


    }
}
