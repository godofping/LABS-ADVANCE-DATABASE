using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Citizenships
    {
        public DataTable List()
        {
            return Helper.executeQuery("select * from citizenships");
        }

        public EL.Registrations.Citizenships Select(EL.Registrations.Citizenships citizenshipEL)
        {
            DataTable dt = Helper.executeQuery("select * from citizenships where citizenshipid = '" + citizenshipEL.Citizenshipid + "'");

            if (dt.Rows.Count > 0)
            {
                citizenshipEL.Citizenshipid = Convert.ToInt32(dt.Rows[0]["citizenshipid"]);
                citizenshipEL.Citizenship = dt.Rows[0]["citizenship"].ToString();

                return citizenshipEL;
            }
            else
            {
                return null;
            }
        }
    }
}
