using System.Data;

namespace pos.BL.Registrations
{
    public class OrderTypes
    {
        DL.Registrations.OrderTypes OrderTypeDL = new DL.Registrations.OrderTypes();

        public DataTable List()
        {
            return OrderTypeDL.List();
        }
    }
}
