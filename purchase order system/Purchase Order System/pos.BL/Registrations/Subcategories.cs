using System.Data;
namespace pos.BL.Registrations
{
    public class SubCategories
    {
        DL.Registrations.SubCategories SubCategoryDL = new DL.Registrations.SubCategories();
        public DataTable List(string keywords)
        {
            return SubCategoryDL.List(keywords);
        }

        public DataTable List(int value)
        {
            return SubCategoryDL.List(value);
        }

        public long Insert(EL.Registrations.SubCategories subCategoryEL)
        {
            return SubCategoryDL.Insert(subCategoryEL);
        }

        public bool Update(EL.Registrations.SubCategories subCategoryEL)
        {
            return SubCategoryDL.Update(subCategoryEL);
        }

        public bool Delete(EL.Registrations.SubCategories subCategoryEL)
        {
            return SubCategoryDL.Delete(subCategoryEL);
        }
    }
}
