using System.Data;

namespace WATER_REFILLING_STATION.DL.REGISTRATIONS
{
    public class deliverymodetypes
    {
        public DataTable List()
        {
            string sQuery = "SELECT * FROM deliverymodetypes";
            return Helper.executeQuery(sQuery);
        }
    }
}
