using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Educations
    {
        public EL.Registrations.Educations Select(EL.Registrations.Educations educationEL)
        {
            DataTable dt = Helper.executeQuery("select * from educations where residentid = '" + educationEL.Residentid + "'");

            if (dt.Rows.Count > 0)
            {
                educationEL.Educationid = Convert.ToInt32(dt.Rows[0]["educationid"]);
                educationEL.Residentid = Convert.ToInt32(dt.Rows[0]["residentid"]);
                educationEL.Educationalattainmentid = Convert.ToInt32(dt.Rows[0]["educationalattainmentid"]);
                educationEL.Course = dt.Rows[0]["course"].ToString();
                educationEL.Yeargraduated = dt.Rows[0]["yeargraduated"].ToString();

                return educationEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Educations educationEL)
        {
            return Helper.executeNonQueryLong("insert into educations (residentid, educationalattainmentid, course, yeargraduated) values ('" + educationEL.Residentid + "', '" + educationEL.Educationalattainmentid + "', '" + educationEL.Course + "', '" + educationEL.Yeargraduated + "')");
        }

        public Boolean Update(EL.Registrations.Educations educationEL)
        {
            return Helper.executeNonQueryBool("update educations set educationalattainmentid = '" + educationEL.Educationalattainmentid + "', course = '" + educationEL.Course + "', yeargraduated = '" + educationEL.Yeargraduated + "' where residentid = '" + educationEL.Residentid + "'");
        }

        public Boolean Delete(EL.Registrations.Educations educationEL)
        {
            return Helper.executeNonQueryBool("delete from educations where residentid = '" + educationEL.Residentid + "'");
        }
    }
}
