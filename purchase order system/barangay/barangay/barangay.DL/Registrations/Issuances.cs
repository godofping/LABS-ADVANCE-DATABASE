using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Issuances
    {
        public DataTable List(String keyword)
        {
            return Helper.executeQuery("select * from issuances_view where lastname like '" + keyword + "%' or firstname like '" + keyword + "%' or middlename like '" + keyword + "%' or certification like '" + keyword + "%' or issuancedateandtime like '" + keyword + "%'");
        }

        public EL.Registrations.Issuances Select(EL.Registrations.Issuances issuanceEL)
        {
            DataTable dt = Helper.executeQuery("select * from issuances where issuanceid = '" + issuanceEL.Issuanceid + "'");

            if (dt.Rows.Count > 0)
            {
                issuanceEL.Issuanceid = Convert.ToInt32(dt.Rows[0]["issuanceid"]);
                issuanceEL.Residentid = Convert.ToInt32(dt.Rows[0]["residentid"]);
                issuanceEL.Certificationid = Convert.ToInt32(dt.Rows[0]["certificationid"]);
                issuanceEL.Issuancedateandtime = dt.Rows[0]["issuancedateandtime"].ToString();

                return issuanceEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Issuances issuanceEL)
        {
            return Helper.executeNonQueryLong("insert into issuances (residentid, certificationid, issuancedateandtime) values ('" + issuanceEL.Residentid + "', '" + issuanceEL.Certificationid + "', '" + issuanceEL.Issuancedateandtime + "')");
        }

        public Boolean Update(EL.Registrations.Issuances issuanceEL)
        {
            return Helper.executeNonQueryBool("update issuances set residentid = '" + issuanceEL.Residentid + "', certificationid = '" + issuanceEL.Certificationid + "', issuancedateandtime = '" + issuanceEL.Issuancedateandtime + "' where issuanceid = '" + issuanceEL.Issuanceid + "'");
        }

        public Boolean Delete(EL.Registrations.Issuances issuanceEL)
        {
            return Helper.executeNonQueryBool("delete from issuances where issuanceid = '" + issuanceEL.Issuanceid + "'");
        }
    }
}
