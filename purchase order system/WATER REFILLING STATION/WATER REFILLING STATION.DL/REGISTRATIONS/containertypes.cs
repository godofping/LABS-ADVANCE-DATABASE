using System.Data;

namespace WATER_REFILLING_STATION.DL.REGISTRATIONS
{
    public class containertypes
    {
        public DataTable List()
        {
            string sQuery = "SELECT * FROM containertypes";

            return Helper.executeQuery(sQuery);
        }
    }
}
