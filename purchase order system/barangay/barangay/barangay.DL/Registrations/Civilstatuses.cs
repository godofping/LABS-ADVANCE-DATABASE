using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Civilstatuses
    {
        public DataTable List()
        {
            return Helper.executeQuery("select * from civilstatuses");
        }

        public EL.Registrations.Civilstatuses Select(EL.Registrations.Civilstatuses civilstatusEL)
        {
            DataTable dt = Helper.executeQuery("select * from civilstatuses where civilstatusid = '" + civilstatusEL.Civilstatusid + "'");

            if (dt.Rows.Count > 0)
            {
                civilstatusEL.Civilstatusid = Convert.ToInt32(dt.Rows[0]["civilstatusid"]);
                civilstatusEL.Civilstatus = dt.Rows[0]["civilstatus"].ToString();

                return civilstatusEL;
            }
            else
            {
                return null;
            }
        }
    }
}
