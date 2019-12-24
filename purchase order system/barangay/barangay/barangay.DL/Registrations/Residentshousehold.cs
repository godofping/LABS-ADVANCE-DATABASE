using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Residentshousehold
    {
        public EL.Registrations.Residentshousehold Select(EL.Registrations.Residentshousehold residenthouseholdEL)
        {
            DataTable dt = Helper.executeQuery("select * from residentshousehold where residentid = '" + residenthouseholdEL.Residentid + "'");

            if (dt.Rows.Count > 0)
            {
                residenthouseholdEL.Residenthouseholdid = Convert.ToInt32(dt.Rows[0]["residenthouseholdid"]);
                residenthouseholdEL.Residentid = Convert.ToInt32(dt.Rows[0]["residentid"]);
                residenthouseholdEL.Householdid = Convert.ToInt32(dt.Rows[0]["householdid"]);
                residenthouseholdEL.Householdmemberid = Convert.ToInt32(dt.Rows[0]["householdmemberid"]);

                return residenthouseholdEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Residentshousehold residenthouseholdEL)
        {
            Console.WriteLine("insert into residentshousehold (residentid, householdid, householdmemberid) values ('" + residenthouseholdEL.Residentid + "', '" + residenthouseholdEL.Householdid + "', '" + residenthouseholdEL.Householdmemberid + "')");
            return Helper.executeNonQueryLong("insert into residentshousehold (residentid, householdid, householdmemberid) values ('" + residenthouseholdEL.Residentid + "', '" + residenthouseholdEL.Householdid + "', '" + residenthouseholdEL.Householdmemberid + "')");
        }

        public Boolean Update(EL.Registrations.Residentshousehold residenthouseholdEL)
        {
            return Helper.executeNonQueryBool("update residentshousehold set householdid = '" + residenthouseholdEL.Householdid + "', householdmemberid = '" + residenthouseholdEL.Householdmemberid + "' where residentid = '" + residenthouseholdEL.Residentid + "'");
        }

        public Boolean Delete(EL.Registrations.Residentshousehold residenthouseholdEL)
        {
            return Helper.executeNonQueryBool("delete from residentshousehold where residentid = '" + residenthouseholdEL.Residentid + "'");
        }
    }
}
