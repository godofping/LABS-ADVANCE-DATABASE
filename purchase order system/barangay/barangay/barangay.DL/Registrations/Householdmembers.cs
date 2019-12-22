using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Householdmembers
    {
        public DataTable List()
        {
            return Helper.executeQuery("select * from householdmembers");
        }

        public EL.Registrations.Householdmembers Select(EL.Registrations.Householdmembers householdmemberEL)
        {
            DataTable dt = Helper.executeQuery("select * from householdmembers where householdmemberid = '" + householdmemberEL.householdmemberid + "'");

            if (dt.Rows.Count > 0)
            {
                householdmemberEL.Householdmemberid = Convert.ToInt32(dt.Rows[0]["householdmemberid"]);
                householdmemberEL.Householdmember = dt.Rows[0]["householdmember"].ToString();

                return householdmemberEL;
            }
            else
            {
                return null;
            }
        }
    }
}
