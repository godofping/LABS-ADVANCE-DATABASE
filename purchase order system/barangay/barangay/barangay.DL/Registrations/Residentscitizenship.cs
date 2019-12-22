using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barangay.DL.Registrations
{
    public class Residentscitizenship
    {
        public EL.Registrations.Residentscitizenship Select(EL.Registrations.Residentscitizenship residentcitizenshipEL)
        {
            DataTable dt = Helper.executeQuery("select * from residentscitizenship where residentid = '" + residentcitizenshipEL.Residentid + "'");

            if (dt.Rows.Count > 0)
            {
                residentcitizenshipEL.Residentcitizenshipid = Convert.ToInt32(dt.Rows[0]["residentcitizenshipid"]);
                residentcitizenshipEL.Residentid = Convert.ToInt32(dt.Rows[0]["residentid"]);
                residentcitizenshipEL.Citizenshipid = Convert.ToInt32(dt.Rows[0]["citizenshipid"]);

                return residentcitizenshipEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.Residentscitizenship residentcitizenshipEL)
        {
            return Helper.executeNonQueryLong("insert into residentscitizenship (residentid, citizenshipid) values ('" + residentcitizenshipEL.Residentid + "', '" + residentcitizenshipEL.Citizenshipid + "')");
        }

        public Boolean Update(EL.Registrations.Residentscitizenship residentcitizenshipEL)
        {
            return Helper.executeNonQueryBool("update residentscitizenship set citizenshipid = '" + residentcitizenshipEL.Citizenshipid + "' where residentid = '" + residentcitizenshipEL.Residentid + "'");
        }

        public Boolean Delete(EL.Registrations.Residentscitizenship residentcitizenshipEL)
        {
            return Helper.executeNonQueryBool("delete from residentscitizenship where residentid = '" + residentcitizenshipEL.Residentid + "'");
        }
    }
}
