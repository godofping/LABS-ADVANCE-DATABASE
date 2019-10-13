using System.Data;

namespace pos.DL.Registrations
{
    public class Staffpositions
    {
        public DataTable List()
        {
            string sQuery = "select * from staffpositions_view";

            return Helper.executeQuery(sQuery);
        }
    }
}
