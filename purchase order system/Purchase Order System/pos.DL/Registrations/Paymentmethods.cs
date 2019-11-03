using System.Data;

namespace pos.DL.Registrations
{
    public class PaymentMethods
    {
        public DataTable List()
        {
            string sQuery = "select * from paymentmethods_view";

            return Helper.executeQuery(sQuery);
        }
    }
}
