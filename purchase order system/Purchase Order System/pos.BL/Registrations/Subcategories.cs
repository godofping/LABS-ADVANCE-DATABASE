using System.Data;
namespace pos.BL.Registrations
{
    public class Subcategories
    {
        DL.Registrations.Subcategories SubCategoryDL = new DL.Registrations.Subcategories();
        public DataTable List(string keywords)
        {
            return SubCategoryDL.List(keywords);
        }

        public DataTable List(int value)
        {
            return SubCategoryDL.List(value);
        }

        public long Insert(EL.Registrations.Subcategories subcategory)
        {
            return SubCategoryDL.Insert(subcategory);
        }

        public bool Update(EL.Registrations.Subcategories subcategory)
        {
            return SubCategoryDL.Update(subcategory);
        }

        public bool Delete(EL.Registrations.Subcategories subcategory)
        {
            return SubCategoryDL.Delete(subcategory);
        }
    }
}
