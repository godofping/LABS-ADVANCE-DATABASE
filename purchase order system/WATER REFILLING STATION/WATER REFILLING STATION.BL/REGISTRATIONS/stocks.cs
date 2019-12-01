using System;
using System.Collections.Generic;
using System.Text;

namespace WATER_REFILLING_STATION.BL.REGISTRATIONS
{
    public class stocks
    {
        DL.REGISTRATIONS.stocks stockDL = new DL.REGISTRATIONS.stocks();

        public long Insert(EL.REGISTRATIONS.stocks stockEL)
        {
            return stockDL.Insert(stockEL);
        }

        public bool Update(EL.REGISTRATIONS.stocks stockEL)
        {
            return stockDL.Update(stockEL);
        }

        public bool Delete(EL.REGISTRATIONS.stocks stockEL)
        {
            return stockDL.Delete(stockEL);
        }
    }
}
