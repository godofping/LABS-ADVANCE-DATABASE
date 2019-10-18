using System.Data;

namespace pos.BL.Registrations
{
    public class Shippingmethods
    {
        DL.Registrations.Shippingmethods ShippingMethodDL = new DL.Registrations.Shippingmethods();

        public DataTable List()
        {
            return ShippingMethodDL.List();
        }
    }
}
