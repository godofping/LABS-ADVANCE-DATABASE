using System;
using System.Data;

namespace pos.DL.Registrations
{
    public class Vendors
    {
        public DataTable List(string keywords)
        {
            String sQuery = "select * from vendors_view where `Vendor ID` like '%" + keywords + "%' or `Vendor` like '%" + keywords + "%' or `Vendor Category` like '%" + keywords + "%' or `Contact Number` like '%" + keywords + "%' or `Email Address` like '%" + keywords + "%' or `Address` like '%" + keywords + "%' or `City` like '%" + keywords + "%' or `Province` like '%" + keywords + "%' or `Zip Code` like '%" + keywords + "%' ";

            return Helper.executeQuery(sQuery);
        }

        public long Insert(EL.Registrations.Suppliers vendor)
        {
            return Helper.executeNonQueryLong("insert into vendors (vendor, contactdetailid, vendorcategoryid) values ('" + vendor.Supplier + "', '" + vendor.Contactdetailid + "', '" + vendor.Vendorcategoryid + "')");
        }

        public bool Update(EL.Registrations.Suppliers vendor)
        {
            return Helper.executeNonQueryBool("update vendors set vendor = '" + vendor.Supplier + "' vendorid = '" + vendor.Vendorcategoryid + "' ");
        }

        public bool Delete(EL.Registrations.Suppliers vendor)
        {
            return Helper.executeNonQueryBool("update vendors set isdeleted = 1 where vendorid = '" + vendor.Vendorcategoryid + "' ");
        }
    }
}
