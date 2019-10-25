using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace pos.BL.Registrations
{
    public class Supplies
    {
        DL.Registrations.Supplies supplyDL = new DL.Registrations.Supplies();

        public DataTable List(string keywords)
        {
            return supplyDL.List(keywords);
        }

        public DataTable List(int id)
        {
            return supplyDL.List(id);
        }

        public long Insert(EL.Registrations.Supplies supply)
        {
            return supplyDL.Insert(supply);    
        }

        public bool Edit(EL.Registrations.Supplies supply)
        {
            return supplyDL.Edit(supply);   
        }

        public bool Delete(EL.Registrations.Supplies supply)
        {
            return supplyDL.Delete(supply);
        }

    }
}
