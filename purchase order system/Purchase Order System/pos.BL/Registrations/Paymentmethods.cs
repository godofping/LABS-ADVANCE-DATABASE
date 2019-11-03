using System.Data;

namespace pos.BL.Registrations
{
    public class PaymentMethods
    {
        DL.Registrations.PaymentMethods PaymentMethodDL = new DL.Registrations.PaymentMethods();

        public DataTable List()
        {
            return PaymentMethodDL.List();
        }
    }
}
