
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace pos.BL.Registrations
{
    public class Suppliers
    {
        DL.Registrations.Suppliers supplierDL = new DL.Registrations.Suppliers();

        public DataTable List(string keywords)
        {
            return supplierDL.List(keywords);
         }

        public long Insert(EL.Registrations.Suppliers supplier)
        {
            return supplierDL.Insert(supplier);
        }

        public bool Edit(EL.Registrations.Suppliers supplier)
        {
            return supplierDL.Edit(supplier);
        }

        public bool Delete(EL.Registrations.Suppliers supplier)
        {
            return supplierDL.Delete(supplier);    
        }
    }
}
