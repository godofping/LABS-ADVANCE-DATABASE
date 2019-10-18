using System.Data;

namespace pos.BL.Registrations
{
    public class Ordertypes
    {
        DL.Registrations.Ordertypes OrderTypeDL = new DL.Registrations.Ordertypes();

        public DataTable List()
        {
            return OrderTypeDL.List();
        }
    }
}
