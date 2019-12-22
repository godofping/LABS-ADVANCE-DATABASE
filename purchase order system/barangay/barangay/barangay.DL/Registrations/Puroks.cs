using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Puroks
    {
        public DataTable List()
        {
            return Helper.executeQuery("select * from puroks");
        }

        public EL.Registrations.Puroks Select(EL.Registrations.Puroks purokEL)
        {
            DataTable dt = Helper.executeQuery("select * from puroks where purokid = '" + purokEL.Purokid + "'");

            if (dt.Rows.Count > 0)
            {
                purokEL.Purokid = Convert.ToInt32(dt.Rows[0]["purokid"]);
                purokEL.Purok = dt.Rows[0]["purok"].ToString();

                return purokEL;
            }
            else
            {
                return null;
            }
        }
    }
}
