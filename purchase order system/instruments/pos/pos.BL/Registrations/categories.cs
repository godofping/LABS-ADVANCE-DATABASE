using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.BL.Registrations
{
    public class categories
    {
        DL.Registrations.categories categoryDL = new DL.Registrations.categories();

        public DataTable List(string keywords)
        {
            return categoryDL.List(keywords);
        }

        public EL.Registrations.categories Select(EL.Registrations.categories categoryEL)
        {
            return categoryDL.Select(categoryEL);
        }

        public long Insert(EL.Registrations.categories categoryEL)
        {
            return categoryDL.Insert(categoryEL);
        }

        public bool Update(EL.Registrations.categories categoryEL)
        {
            return categoryDL.Update(categoryEL);
        }

        public bool Delete(EL.Registrations.categories categoryEL)
        {
            return categoryDL.Delete(categoryEL);
        }
    }
}
