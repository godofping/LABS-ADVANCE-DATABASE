using System.Data;

namespace pos.DL.Registrations
{
    public class OrderTypes
    {
        public DataTable List()
        {
            string sQuery = "select * from staffpositions_view";

            return Helper.executeQuery(sQuery);
        }
    }
}
