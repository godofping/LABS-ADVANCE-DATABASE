using System;
using System.Data;

namespace pos.DL.Registrations
{
    public class Staffpositions
    {
        public DataTable List()
        {
            String sQuery = "select * from staffpositions_view";

            return Helper.executeQuery(sQuery);
        }
    }
}
