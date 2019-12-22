using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Residentshouseholdmember
    {
        public EL.Registrations.Residentshouseholdmember Select(EL.Registrations.Residentshouseholdmember residenthouseholdmemberEL)
        {
            DataTable dt = Helper.executeQuery("select * from residentshouseholdmember where residentid = '" + residenthouseholdmemberEL.Residentid + "'");

            if (dt.Rows.Count > 0)
            {
                residenthouseholdmemberEL.Residenthouseholdmemberid = Convert.ToInt32(dt.Rows[0]["residenthouseholdmemberid"]);
                residenthouseholdmemberEL.Residentid = Convert.ToInt32(dt.Rows[0]["residentid"]);
                residenthouseholdmemberEL.Householdmemberid = Convert.ToInt32(dt.Rows[0]["householdmemberid"]);

                return residenthouseholdmemberEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Residentshouseholdmember residenthouseholdmemberEL)
        {
            return Helper.executeNonQueryLong("insert into residentshouseholdmember (residentid, householdmemberid) values ('" + residenthouseholdmemberEL.Residentid + "', '" + residenthouseholdmemberEL.Householdmemberid + "')");
        }

        public Boolean Update(EL.Registrations.Residentshouseholdmember residenthouseholdmemberEL)
        {
            return Helper.executeNonQueryBool("update residentshouseholdmember set householdmemberid = '" + residenthouseholdmemberEL.Householdmemberid + "' where residentid = '" + residenthouseholdmemberEL.Residentid + "'");
        }

        public Boolean Delete(EL.Registrations.Residentshouseholdmember residenthouseholdmemberEL)
        {
            return Helper.executeNonQueryBool("delete from residentshouseholdmember where residentid = '" + residenthouseholdmemberEL.Residentid + "'");
        }
    }
}
