﻿using System.Data;

namespace WATER_REFILLING_STATION.DL.REGISTRATIONS
{
    public class particulars
    {
        public DataTable List(string keywords)
        {
            string sQuery = "SELECT * FROM view_particulars WHERE `PARTICULAR` LIKE '%" + keywords + "%' AND `PARTICULAR ID` <> 11";
            return Helper.executeQuery(sQuery);
        }

        public DataTable List()
        {
            string sQuery = "SELECT * FROM view_particulars";
            return Helper.executeQuery(sQuery);
        }

        public long Insert(EL.REGISTRATIONS.particulars particularEL)
        {
            return Helper.executeNonQueryLong("INSERT INTO particulars (particular) VALUES ('" + particularEL.Particular + "')");
        }

        public bool Update(EL.REGISTRATIONS.particulars particularEL)
        {
            return Helper.executeNonQueryBool("UPDATE particulars SET particular = '" + particularEL.Particular + "' where particularid = '" + particularEL.Particularid + "'");
        }


        public bool Delete(EL.REGISTRATIONS.particulars particularEL)
        {
            return Helper.executeNonQueryBool("DELETE FROM particulars WHERE particularid = '" + particularEL.Particularid + "' ");
        }

    }
}
