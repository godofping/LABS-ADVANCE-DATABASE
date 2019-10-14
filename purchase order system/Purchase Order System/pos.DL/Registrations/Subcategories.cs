using System.Data;
namespace pos.DL.Registrations
{
    public class Subcategories
    {
        public DataTable List(string keywords)
        {
            string sQuery = "select * from subcategories_view where `Sub Category Id` like '%" + keywords + "%' or `Sub Category Name` like '%" + keywords + "%' or `Category Name` like '%" + keywords + "%' ";
            return Helper.executeQuery(sQuery);
        }

        public long Insert(EL.Registrations.Subcategories subcategory)
        {
            return Helper.executeNonQueryLong("insert into subcategories (subcategoryname, categoryid) values ('" + subcategory.Subcategoryname + "', '" + subcategory.Categoryid + "')");
        }

        public bool Update(EL.Registrations.Subcategories subcategory)
        {
            return Helper.executeNonQueryBool("update subcategories set subcategoryname = '" + subcategory.Subcategoryname + "', categoryid = '" + subcategory.Categoryid + "' where subcategoryid = '" + subcategory.Subcategoryid + "' ");
        }

        public bool Delete(EL.Registrations.Subcategories subcategory)
        {
            return Helper.executeNonQueryBool("update subcategories set isdeleted = 1 where subcategoryid = '" + subcategory.Subcategoryid + "' ");
        }
    }
}
