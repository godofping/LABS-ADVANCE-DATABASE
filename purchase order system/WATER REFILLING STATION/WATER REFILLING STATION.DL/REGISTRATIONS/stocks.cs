using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WATER_REFILLING_STATION.DL.REGISTRATIONS
{
    public class stocks
    {
        public long Insert(EL.REGISTRATIONS.stocks stockEL)
        {
            string sQuery = "INSERT INTO stocks (productid, stock) VALUES ('" + stockEL.Productid + "', '" + stockEL.Stock + "')";

            return Helper.executeNonQueryLong(sQuery);
        }

        public bool Update(EL.REGISTRATIONS.stocks stockEL)
        {
            string sQuery = "UPDATE stocks SET stock = '" + stockEL.Stock + "' WHERE stockid = '" + stockEL.Stockid + "'";

            return Helper.executeNonQueryBool(sQuery);
        }

        public bool Delete(EL.REGISTRATIONS.stocks stockEL)
        {
            string sQuery = "DELETE FROM stocks where stockid = '" + stockEL.Stockid + "'";

            return Helper.executeNonQueryBool(sQuery);
        }
    }
}
