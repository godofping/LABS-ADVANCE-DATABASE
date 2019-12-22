using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Provincialaddresses
    {
        public EL.Registrations.Provincialaddresses Select(EL.Registrations.Provincialaddresses provincialaddressEL)
        {
            DataTable dt = Helper.executeQuery("select * from provincialaddresses where residentid = '" + provincialaddressEL.Residentid + "'");

            if (dt.Rows.Count > 0)
            {
                provincialaddressEL.Provincialaddressid = Convert.ToInt32(dt.Rows[0]["provincialaddressid"]);
                provincialaddressEL.Residentid = Convert.ToInt32(dt.Rows[0]["residentid"]);
                provincialaddressEL.Municipality = dt.Rows[0]["municipality"].ToString();
                provincialaddressEL.Province = dt.Rows[0]["province"].ToString();

                return provincialaddressEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Provincialaddresses provincialaddressEL)
        {
            return Helper.executeNonQueryLong("insert into provincialaddresses (residentid, municipality, province) values ('" + provincialaddressEL.Residentid + "', '" + provincialaddressEL.Municipality + "', '" + provincialaddressEL.Province + "')");
        }

        public Boolean Update(EL.Registrations.Provincialaddresses provincialaddressEL)
        {
            return Helper.executeNonQueryBool("update provincialaddresses set municipality = '" + provincialaddressEL.Municipality + "', province = '" + provincialaddressEL.Province + "' where residentid = '" + provincialaddressEL.Residentid + "'");
        }

        public Boolean Delete(EL.Registrations.Provincialaddresses provincialaddressEL)
        {
            return Helper.executeNonQueryBool("delete from provincialaddresses where residentid = '" + provincialaddressEL.Residentid + "'");
        }
    }
}
