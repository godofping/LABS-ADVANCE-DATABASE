using System;
using System.Data;

namespace pos.DL.Registrations
{
    public class Vendorcategories
    {

        public DataTable List(string keywords)
        {
            String sQuery = "select * from vendorcategories_view where `Vendor Category` like '%" + keywords + "%' or  `Vendor Category ID` like '%" + keywords + "%'";

            return Helper.executeQuery(sQuery);
        }

        public long Insert(EL.Registrations.Vendorcategories vendorcategory)
        {
            return Helper.executeNonQueryLong("insert into vendorcategories (vendorcategory) values ('" + vendorcategory.Vendorcategory + "')");
        }

        public bool Update(EL.Registrations.Vendorcategories vendorcategory)
        {
            return Helper.executeNonQueryBool("update vendorcategories set vendorcategory = '" + vendorcategory.Vendorcategory + "' where vendorcategoryid = '" + vendorcategory.Vendorcategoryid + "'");
        }

        public bool Delete(EL.Registrations.Vendorcategories vendorcategory)
        {
            return Helper.executeNonQueryBool("update vendorcategories set isdeleted = '1' where vendorcategoryid = '" + vendorcategory.Vendorcategoryid + "'");
        }
    }
}
