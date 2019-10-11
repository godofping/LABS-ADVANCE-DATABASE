using System;
using System.Data;
namespace pos.BL.Registrations
{
    public class Customers
    {
        public DataTable List()
        {
            DL.Registrations.Customers CustomersDL = new DL.Registrations.Customers();
            return CustomersDL.List();
        }

        public long Insert(EL.Registrations.Customers customer)
        {
            DL.Registrations.Customers CustomerDL = new DL.Registrations.Customers();
            return CustomerDL.Insert(customer);
        }

    }
}
