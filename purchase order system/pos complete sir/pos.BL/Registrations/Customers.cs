using System;

namespace pos.BL.Registrations
{
    public class Customers
    {
        public bool Insert(pos.EL.Registrations.Customers cus)
        {
            pos.DL.Registrations.Customers customerDL = new pos.DL.Registrations.Customers();
            if (customerDL.Insert(cus))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean Update(pos.EL.Registrations.Customers cus)
        {

            pos.DL.Registrations.Customers customerDL = new pos.DL.Registrations.Customers();
            if (customerDL.Update(cus))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public Boolean Delete(pos.EL.Registrations.Customers cus)
        {
            pos.DL.Registrations.Customers customerDL = new pos.DL.Registrations.Customers();
            if (customerDL.Delete(cus))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public System.Data.DataTable List(pos.EL.Registrations.Customers cus)
        {
            pos.DL.Registrations.Customers customerDL = new pos.DL.Registrations.Customers();
            return customerDL.List(cus);
        }
        public pos.EL.Registrations.Customers Select(pos.EL.Registrations.Customers cus)
        {
            pos.DL.Registrations.Customers customerDL = new pos.DL.Registrations.Customers();
            return customerDL.Select(cus);
        }
    }
}
