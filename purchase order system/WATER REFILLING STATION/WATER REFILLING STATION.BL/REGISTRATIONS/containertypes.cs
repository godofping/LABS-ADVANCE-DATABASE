using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WATER_REFILLING_STATION.BL.REGISTRATIONS
{
    public class containertypes
    {
        DL.REGISTRATIONS.containertypes containertypeDL = new DL.REGISTRATIONS.containertypes();
        public DataTable List(string keywords)
        {
            return containertypeDL.List(keywords);
        }

        public DataTable List()
        {
            return containertypeDL.List();
        }

        public long Insert(EL.REGISTRATIONS.containertypes containertypeEL)
        {
            return containertypeDL.Insert(containertypeEL);    
        }

        public bool Update(EL.REGISTRATIONS.containertypes containertypeEL)
        {
            return containertypeDL.Update(containertypeEL);
        }


        public bool Delete(EL.REGISTRATIONS.containertypes containertypeEL)
        {
            return containertypeDL.Delete(containertypeEL);
        }
    }
}
