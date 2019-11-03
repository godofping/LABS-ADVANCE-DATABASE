using System.Data;

namespace pos.DL.Registrations
{
    public class Categories
    {
        public DataTable List(string keywords)
        {
            string sQuery = "select * from categories_view where `Category Name` like '%" + keywords + "%' ";
            return Helper.executeQuery(sQuery);
        }

        public long Insert(EL.Registrations.Categories categoryEL)
        {
            return Helper.executeNonQueryLong("insert into categories (categoryname) values ('" + categoryEL.Categoryname + "')");
        }

        public bool Update(EL.Registrations.Categories categoryEL)
        {
            return Helper.executeNonQueryBool("update categories set categoryname = '" + categoryEL.Categoryname + "' where categoryid = '" + categoryEL.Categoryid + "' ");
        }

        public bool Delete(EL.Registrations.Categories categoryEL)
        {
            return Helper.executeNonQueryBool("update categories set isdeleted = 1 where categoryid = '" + categoryEL.Categoryid + "' ");
        }
    }
}
