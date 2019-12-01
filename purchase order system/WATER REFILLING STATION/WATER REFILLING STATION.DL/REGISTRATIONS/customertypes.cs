using System.Data;

namespace WATER_REFILLING_STATION.DL.REGISTRATIONS
{
    public class customertypes
    {
        public DataTable List()
        {
            string sQuery = "SELECT * FROM view_customertypes";
            return Helper.executeQuery(sQuery);
        }
    }
}
