using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Filelocations
    {
        public EL.Registrations.Filelocations Select(EL.Registrations.Filelocations filelocationEL)
        {
            DataTable dt = Helper.executeQuery("select * from filelocations where accomplishmentid = '" + filelocationEL.Accomplishmentid + "'");

            if (dt.Rows.Count > 0)
            {
                filelocationEL.Filelocationid = Convert.ToInt32(dt.Rows[0]["filelocationid"]);
                filelocationEL.Accomplishmentid = Convert.ToInt32(dt.Rows[0]["accomplishmentid"]);
                filelocationEL.Filelocation = dt.Rows[0]["filelocation"].ToString();

                return filelocationEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Filelocations filelocationEL)
        {
            return Helper.executeNonQueryLong("insert into filelocations (accomplishmentid, filelocation) values ('" + filelocationEL.Accomplishmentid + "', '" + filelocationEL.Filelocation + "')");
        }

        public Boolean Update(EL.Registrations.Filelocations filelocationEL)
        {
            return Helper.executeNonQueryBool("update filelocations set filelocation = '" + filelocationEL.Filelocation + "' where  accomplishmentid = '" + filelocationEL.Accomplishmentid + "'");
        }

        public Boolean Delete(EL.Registrations.Filelocations filelocationEL)
        {
            return Helper.executeNonQueryBool("delete from filelocations where accomplishmentid = '" + filelocationEL.Accomplishmentid + "'");
        }
    }
}
