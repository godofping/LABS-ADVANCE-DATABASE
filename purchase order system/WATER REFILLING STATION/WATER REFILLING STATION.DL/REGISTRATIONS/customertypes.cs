using System.Data;

namespace WATER_REFILLING_STATION.DL.REGISTRATIONS
{
    public class customertypes
    {
        public DataTable List()
        {
            string sQuery = "SELECT * FROM customertypes";
            return Helper.executeQuery(sQuery);
        }
    }
}
