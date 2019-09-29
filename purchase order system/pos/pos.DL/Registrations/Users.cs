using System;
using System.Collections.Generic;
using System.Text;

namespace pos.DL.Registrations
{
    public class Users
    {
        public int Login(pos.EL.Registrations.Users user)
        {

            String sQuery = "Select * from users where username = '" + user.Username +"' and password = '" + user.Password + "' ";

            System.Data.DataTable dt = Helper.executeQuery(sQuery);

            if (dt.Rows.Count >= 1)
            {
                user.Userid = Convert.ToInt32(dt.Rows[0]["userid"].ToString());
                user.Username = dt.Rows[0]["username"].ToString();
                user.Password = dt.Rows[0]["password"].ToString();
               
            }

            return dt.Rows.Count;
            
        }
    }
}
