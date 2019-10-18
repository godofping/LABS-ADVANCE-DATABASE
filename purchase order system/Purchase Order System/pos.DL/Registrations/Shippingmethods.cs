using System.Data;

namespace pos.DL.Registrations
{
    public class Shippingmethods
    {
        public DataTable List()
        {
            string sQuery = "select * from shippingmethods_view";

            return Helper.executeQuery(sQuery);
        }
    }
}
