using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pos.DL.Registrations
{
    public class Customers
    {
        public Boolean Insert(pos.EL.Registrations.Customers cus)
        {
          return Helper.executeNonQuery("Insert into customers(lastname, firstname,middleinitial,age,address,tribe) values(" + 
                                   "'" + cus.Lastname + "','" + cus.Firstname + "','" + cus.Middleinitial + "'," + cus.Age + ",'" + 
                                    cus.Address + "','"  + cus.Tribe + "')");  

        }

       
    }
}
