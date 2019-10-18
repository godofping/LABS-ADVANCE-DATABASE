using System.Data;

namespace pos.BL.Registrations
{
    public class Paymentmethods
    {
        DL.Registrations.Paymentmethods PaymentMethodDL = new DL.Registrations.Paymentmethods();

        public DataTable List()
        {
            return PaymentMethodDL.List();
        }
    }
}
