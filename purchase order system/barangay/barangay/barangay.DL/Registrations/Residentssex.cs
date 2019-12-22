using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Residentssex
    {
        public EL.Registrations.Residentssex Select(EL.Registrations.Residentssex residentsexEL)
        {
            DataTable dt = Helper.executeQuery("select * from residentssex where residentid = '" + residentsexEL.Residentid + "'");

            if (dt.Rows.Count > 0)
            {
                residentsexEL.Residentsexid = Convert.ToInt32(dt.Rows[0]["residentsexid"]);
                residentsexEL.Residentid = Convert.ToInt32(dt.Rows[0]["residentid"]);
                residentsexEL.Sexid = Convert.ToInt32(dt.Rows[0]["sexid"]);

                return residentsexEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Residentssex residentsexEL)
        {
            return Helper.executeNonQueryLong("insert into residentssex (residentid, sexid) values ('" + residentsexEL.Residentid + "', '" + residentsexEL.Sexid + "')");
        }

        public Boolean Update(EL.Registrations.Residentssex residentsexEL)
        {
            return Helper.executeNonQueryBool("update residentssex set sexid = '" + residentsexEL.Sexid + "' where residentid = '" + residentsexEL.Residentid + "'");
        }

        public Boolean Delete(EL.Registrations.Residentssex residentsexEL)
        {
            return Helper.executeNonQueryBool("delete from residentssex where residentid = '" + residentsexEL.Residentid + "'");
        }
    }
}
