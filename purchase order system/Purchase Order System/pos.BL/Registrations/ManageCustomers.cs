using System;
using System.Data;
namespace pos.BL.Registrations
{
    public class ManageCustomers
    {
        public DataTable List()
        {
            DL.Registrations.ManageCustomers ManageCustomersDL = new DL.Registrations.ManageCustomers();
            return ManageCustomersDL.List();
        }

        public DataTable GetGenders()
        {
            DL.Registrations.ManageCustomers ManageCustomersDL = new DL.Registrations.ManageCustomers();
            return ManageCustomersDL.GetGenders();
        }


    }
}
