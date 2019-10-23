using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace pos.DL.Registrations
{
    public class Suppliers
    {

        public DataTable List(string keywords)
        {
            return Helper.executeQuery("select * from suppliers_view where `Supplier Name` like '%" + keywords + "%' or `Supplier Contact Number` like '%" + keywords + "%' or `Supplier Address` like '%" + keywords + "%' ");
        }

        public long Insert(EL.Registrations.Suppliers supplier)
        {
            return Helper.executeNonQueryLong("insert into suppliers (suppliername, suppliercontactnumber, supplieraddress) values ('" + supplier.Suppliername + "', '" + supplier.Suppliercontactnumber + "', '" + supplier.Supplieraddress + "')");
        }

        public bool Edit(EL.Registrations.Suppliers supplier)
        {
            return Helper.executeNonQueryBool("update suppliers set suppliername = '" + supplier.Suppliername + "', suppliercontactnumber = '" + supplier.Suppliercontactnumber + "', supplieraddress = '" + supplier.Supplieraddress + "'  where supplierid = '" + supplier.Supplierid + "' ");
        }

        public bool Delete(EL.Registrations.Suppliers supplier)
        {
            return Helper.executeNonQueryBool("delete from suppliers where supplierid = " + supplier.Supplierid + "");
        }

    }
}
