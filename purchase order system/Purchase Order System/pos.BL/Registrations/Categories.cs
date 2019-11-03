using System.Data;

namespace pos.BL.Registrations
{
    public class Categories
    {
        DL.Registrations.Categories CategoryDL = new DL.Registrations.Categories();
        public DataTable List(string keywords)
        {
            return CategoryDL.List(keywords);
        }

        public long Insert(EL.Registrations.Categories categoryEL)
        {
            return CategoryDL.Insert(categoryEL);
        }

        public bool Update(EL.Registrations.Categories categoryEL)
        {
            return CategoryDL.Update(categoryEL);
        }

        public bool Delete(EL.Registrations.Categories categoryEL)
        {
            return CategoryDL.Delete(categoryEL);
        }
    }
}
