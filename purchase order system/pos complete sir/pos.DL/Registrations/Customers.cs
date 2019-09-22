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

        public Boolean Update(pos.EL.Registrations.Customers cus)
        {
            
            return Helper.executeNonQuery("Update customers set lastname='" + cus.Lastname + "',firstname='" + cus.Firstname + "',middleinitial='" + cus.Middleinitial
             + "',age = " + cus.Age + ", address ='" + cus.Address + "', tribe ='" + cus.Tribe + "' where customerid=" + cus.Customerid);

        }

        public Boolean Delete(pos.EL.Registrations.Customers cus)
        {

            return Helper.executeNonQuery("Delete from customers where customerid=" + cus.Customerid);
        }

        public System.Data.DataTable  List(pos.EL.Registrations.Customers cus)
        {
            String sQuery = "Select * from customers where 1=1 ";
            if (cus.Lastname != null)
            {
                sQuery = sQuery + " and lastname like '" + cus.Lastname.Trim() + "%'";
            }
            if (cus.Firstname != null)
            {
                sQuery = sQuery +  " and lastname like '" + cus.Firstname.Trim() + "%'";
            }
            return Helper.executeQuery(sQuery); 
        }
        public  pos.EL.Registrations.Customers  Select(pos.EL.Registrations.Customers cus)
        {
            
            String sQuery = "Select * from customers where 1=1 ";
            if (cus.Customerid > 0)
            {
                sQuery = sQuery +  "and customerid=" + cus.Customerid;
            }
            
            System.Data.DataTable dt = Helper.executeQuery(sQuery);
            if (dt.Rows.Count >= 1)
            {
                cus.Customerid = Convert.ToInt32( dt.Rows[0]["customerid"].ToString());
                cus.Lastname = dt.Rows[0]["lastname"].ToString();
                cus.Firstname = dt.Rows[0]["firstname"].ToString();
                cus.Middleinitial = dt.Rows[0]["middleinitial"].ToString();
                cus.Age = Convert.ToInt32( Convert.ToInt32(dt.Rows[0]["age"].ToString()));
                cus.Tribe = dt.Rows[0]["tribe"].ToString();
                cus.Address = dt.Rows[0]["address"].ToString();
            }
            return null;
        }

    }
}
