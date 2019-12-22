using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Households
    {
        public DataTable List(String keyword)
        {
            return Helper.executeQuery("select * from households where household like '" + keyword + "%' or householdnumber like '" + keyword + "%'");
        }

        public EL.Registrations.Households Select(EL.Registrations.Households householdEL)
        {
            DataTable dt = Helper.executeQuery("select * from households where householdid = '" + householdEL.Householdid + "'");

            if (dt.Rows.Count > 0)
            {
                householdEL.Householdid = Convert.ToInt32(dt.Rows[0]["householdEL"]);
                householdEL.Household = dt.Rows[0]["household"].ToString();
                householdEL.Householdnumber = dt.Rows[0]["householdnumber"].ToString();

                return householdEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Households householdEL)
        {
            return Helper.executeNonQueryLong("insert into households (household, householdnumber) values ('" + householdEL.Household + "', '" + householdEL.Householdnumber + "')");
        }

        public Boolean Update(EL.Registrations.Households householdEL)
        {
            return Helper.executeNonQueryBool("update households set household = '" + householdEL.Household + "', householdnumber = '" + householdEL.Householdnumber + "' where householdid = '" + householdEL.Householdid + "'");
        }

        public Boolean Delete(EL.Registrations.Households householdEL)
        {
            return Helper.executeNonQueryBool("delete from households where householdid = '" + householdEL.Householdid + "'");
        }
    }
}
