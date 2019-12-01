using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pos.BL.Registrations
{
    public class products
    {
        pos.DL.Registrations.products productDL = new pos.DL.Registrations.products();

        public DataTable List(string keywords)
        {
            return productDL.List(keywords);
        }


        public long Insert(pos.EL.Registrations.products productEL)
        {
            return productDL.Insert(productEL);
        }

        public bool Update(pos.EL.Registrations.products productEL)
        {
            return productDL.Update(productEL);
        }


        public bool Delete(pos.EL.Registrations.products productEL)
        {
            return productDL.Delete(productEL);
        }
    }
}
