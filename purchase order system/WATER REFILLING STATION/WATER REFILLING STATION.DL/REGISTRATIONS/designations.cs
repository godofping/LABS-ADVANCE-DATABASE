using System.Data;

namespace WATER_REFILLING_STATION.DL.REGISTRATIONS
{
    public class designations
    {
        public DataTable List()
        {
            string sQuery = "SELECT * FROM designations";
            return Helper.executeQuery(sQuery);
        }
    }
}
