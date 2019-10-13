using System.Data;

namespace pos.DL.Registrations
{
    public class Categories
    {
        public DataTable List(string keywords)
        {
            string sQuery = "select * from categories_view where `Category Id` like '%" + keywords + "%' or `Category Name` like '%" + keywords + "%' ";
            return Helper.executeQuery(sQuery);
        }

        public long Insert(EL.Registrations.Categories category)
        {
            return Helper.executeNonQueryLong("insert into categories (categoryname) values ('" + category.Categoryname + "')");
        }

        public bool Update(EL.Registrations.Categories category)
        {
            return Helper.executeNonQueryBool("update categories set categoryname = '" + category.Categoryname + "' where categoryid = '" + category.Categoryid + "' ");
        }

        public bool Delete(EL.Registrations.Categories category)
        {
            return Helper.executeNonQueryBool("update categories set isdeleted = 1 where categoryid = '" + category.Categoryid + "' ");
        }
    }
}
