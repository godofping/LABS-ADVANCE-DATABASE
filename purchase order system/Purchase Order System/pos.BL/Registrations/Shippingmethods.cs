using System.Data;

namespace pos.BL.Registrations
{
    public class ShippingMethods
    {
        DL.Registrations.ShippingMethods ShippingMethodDL = new DL.Registrations.ShippingMethods();

        public DataTable List()
        {
            return ShippingMethodDL.List();
        }
    }
}
