using System;
using System.Data;
namespace pos.BL.Registrations
{
    public class Customers
    {

        DL.Registrations.Customers CustomerDL = new DL.Registrations.Customers();
        public DataTable List(string keywords)
        {
            return CustomerDL.List(keywords);
        }

        public long Insert(EL.Registrations.Customers customer)
        {
            return CustomerDL.Insert(customer);
        }

        public bool Delete(EL.Registrations.Customers customer)
        {
            return CustomerDL.Delete(customer);
        }

    }
}
