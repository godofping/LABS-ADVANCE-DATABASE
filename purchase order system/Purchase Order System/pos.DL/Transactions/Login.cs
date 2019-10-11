using System;
using System.Data;

namespace pos.DL.Transactions
{
    public class Login
    {
        public int StaffLogin(pos.EL.Transactions.Login staff)
        {

            String sQuery = "Select * from staffs_view where username = '" + staff.Username + "' and password = '" + staff.Password + "' ";

            DataTable dt = Helper.executeQuery(sQuery);

            if (dt.Rows.Count >= 1)
            {
                staff.Staffid = Convert.ToInt32(dt.Rows[0]["staffid"].ToString());
                staff.Username = dt.Rows[0]["username"].ToString();
                staff.Password = dt.Rows[0]["password"].ToString();
                staff.Contactdetailid = Convert.ToInt32(dt.Rows[0]["contactdetailid"].ToString());
                staff.Basicinformationid = Convert.ToInt32(dt.Rows[0]["basicinformationid"].ToString());
                staff.Staffpositionid = Convert.ToInt32(dt.Rows[0]["staffpositionid"].ToString());
            }
            else
            {
                staff.Staffid = -1;
            }

            return staff.Staffid;

        }
    }
}
