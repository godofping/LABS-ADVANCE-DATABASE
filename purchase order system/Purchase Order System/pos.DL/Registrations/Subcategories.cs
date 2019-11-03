using System.Data;
namespace pos.DL.Registrations
{
    public class SubCategories
    {
        public DataTable List(string keywords)
        {
            string sQuery = "select * from subcategories_view where `Sub Category Name` like '%" + keywords + "%' or `Category Name` like '%" + keywords + "%' ";
            return Helper.executeQuery(sQuery);
        }

        public DataTable List(int value)
        {
            string sQuery = "select * from subcategories_view where categoryid = '" + value + "' ";
            return Helper.executeQuery(sQuery);
        }

        public long Insert(EL.Registrations.SubCategories subCategoryEL)
        {
            return Helper.executeNonQueryLong("insert into subcategories (subcategoryname, categoryid) values ('" + subCategoryEL.Subcategoryname + "', '" + subCategoryEL.Categoryid + "')");
        }

        public bool Update(EL.Registrations.SubCategories subCategoryEL)
        {
            return Helper.executeNonQueryBool("update subcategories set subcategoryname = '" + subCategoryEL.Subcategoryname + "', categoryid = '" + subCategoryEL.Categoryid + "' where subcategoryid = '" + subCategoryEL.Subcategoryid + "' ");
        }

        public bool Delete(EL.Registrations.SubCategories subCategoryEL)
        {
            return Helper.executeNonQueryBool("update subcategories set isdeleted = 1 where subcategoryid = '" + subCategoryEL.Subcategoryid + "' ");
        }
    }
}
