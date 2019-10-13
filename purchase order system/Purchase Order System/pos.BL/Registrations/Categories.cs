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

        public long Insert(EL.Registrations.Categories category)
        {
            return CategoryDL.Insert(category);
        }

        public bool Update(EL.Registrations.Categories category)
        {
            return CategoryDL.Update(category);
        }

        public bool Delete(EL.Registrations.Categories category)
        {
            return CategoryDL.Delete(category);
        }
    }
}
