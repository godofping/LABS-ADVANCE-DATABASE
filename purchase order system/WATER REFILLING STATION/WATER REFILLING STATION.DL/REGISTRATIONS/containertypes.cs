using System.Data;

namespace WATER_REFILLING_STATION.DL.REGISTRATIONS
{
    public class containertypes
    {
        public DataTable List(string keywords)
        {
            string sQuery = "SELECT * FROM view_containertypes WHERE `CONTAINER TYPE` LIKE '%" + keywords + "%'";
            return Helper.executeQuery(sQuery);
        }

        public DataTable List()
        {
            string sQuery = "SELECT * FROM view_containertypes";
            return Helper.executeQuery(sQuery);
        }

        public long Insert(EL.REGISTRATIONS.containertypes containertypeEL)
        {
            return Helper.executeNonQueryLong("INSERT INTO containertypes (containertype) VALUES ('" + containertypeEL.Containertype + "')");
        }

        public bool Update(EL.REGISTRATIONS.containertypes containertypeEL)
        {
            return Helper.executeNonQueryBool("UPDATE containertypes SET containertype = '" + containertypeEL.Containertype + "' WHERE containertypeid = '" + containertypeEL.Containertypeid + "'");
        }


        public bool Delete(EL.REGISTRATIONS.containertypes containertypeEL)
        {
            return Helper.executeNonQueryBool("DELETE FROM containertypes WHERE containertypeid = '" + containertypeEL.Containertypeid + "' ");
        }
    }
}
