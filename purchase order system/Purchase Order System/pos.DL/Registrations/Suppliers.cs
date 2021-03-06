﻿using System.Data;

namespace pos.DL.Registrations
{
    public class Suppliers
    {
        public DataTable List(string keywords)
        {
            string sQuery = "select * from suppliers_view where `Supplier` like '%" + keywords + "%' or `Contact Number` like '%" + keywords + "%' or `Email Address` like '%" + keywords + "%' or `Address` like '%" + keywords + "%' or `City` like '%" + keywords + "%' or `Province` like '%" + keywords + "%' or `Zip Code` like '%" + keywords + "%' ";

            return Helper.executeQuery(sQuery);
        }

        public long Insert(EL.Registrations.Suppliers supplierEL)
        {
            return Helper.executeNonQueryLong("insert into suppliers (supplier, contactdetailid) values ('" + supplierEL.Supplier + "', '" + supplierEL.Contactdetailid + "')");
        }

        public bool Update(EL.Registrations.Suppliers supplierEL)
        {
            return Helper.executeNonQueryBool("update suppliers set supplier = '" + supplierEL.Supplier + "' where supplierid = '" + supplierEL.Supplierid + "' ");
        }

        public bool Delete(EL.Registrations.Suppliers supplierEL)
        {
            return Helper.executeNonQueryBool("delete from suppliers where supplierid = '" + supplierEL.Supplierid + "' ");
        }
    }
}
