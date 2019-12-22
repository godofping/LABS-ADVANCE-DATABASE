using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Accomplishments
    {
        public DataTable List(String keyword)
        {
            return Helper.executeQuery("select * from accomplishments where title like '" + keyword + "%' or dateaccomplished like '" + keyword + "%'");
        }

        public EL.Registrations.Accomplishments Select(EL.Registrations.Accomplishments accomplishmentEL)
        {
            DataTable dt = Helper.executeQuery("select * from accomplishments where accomplishmentid = '" + accomplishmentEL.Accomplishmentid + "'");

            if (dt.Rows.Count > 0)
            {
                accomplishmentEL.Accomplishmentid = Convert.ToInt32(dt.Rows[0]["accomplishmentid"]);
                accomplishmentEL.Title = dt.Rows[0]["title"].ToString();
                accomplishmentEL.Dateaccomplished = dt.Rows[0]["dateaccomplished"].ToString();

                return accomplishmentEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Accomplishments accomplishmentEL)
        {
            return Helper.executeNonQueryLong("insert into accomplishments (title, dateaccomplished) values ('" + accomplishmentEL.Title + "', '" + accomplishmentEL.Dateaccomplished + "')");
        }

        public Boolean Update(EL.Registrations.Accomplishments accomplishmentEL)
        {
            return Helper.executeNonQueryBool("update accomplishments set title = '" + accomplishmentEL.Title + "', dateaccomplished = '" + accomplishmentEL.Dateaccomplished + "' where accomplishmentid = '" + accomplishmentEL.Accomplishmentid + "'");
        }

        public Boolean Delete(EL.Registrations.Accomplishments accomplishmentEL)
        {
            return Helper.executeNonQueryBool("delete from accomplishments where accomplishmentid = '" + accomplishmentEL.Accomplishmentid + "'");
        }
    }
}
