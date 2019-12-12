using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.BL.Registrations
{
    public class products
    {
        DL.Registrations.products productDL = new DL.Registrations.products();
        public DataTable List(string keywords)
        {
            return productDL.List(keywords);
        }

        public EL.Registrations.products Select(EL.Registrations.products productEL)
        {
            return productDL.Select(productEL);
        }

        public long Insert(EL.Registrations.products productEL)
        {
            return productDL.Insert(productEL);
        }

        public bool Update(EL.Registrations.products productEL)
        {
            return productDL.Update(productEL);
        }

        public bool Delete(EL.Registrations.products productEL)
        {
            return productDL.Delete(productEL);
        }
    }
}
