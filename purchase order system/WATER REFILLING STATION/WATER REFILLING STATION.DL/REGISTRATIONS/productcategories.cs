using System.Data;

namespace WATER_REFILLING_STATION.DL.REGISTRATIONS
{
    public class productcategories
    {
        public DataTable List()
        {
            string sQuery = "SELECT * FROM view_productcategories";
            return Helper.executeQuery(sQuery);
        }
    }
}
