using System.Data;

namespace pos.BL.Registrations
{
    public class Vendorcategories
    {
        DL.Registrations.Vendorcategories VendorCategoryDL = new DL.Registrations.Vendorcategories();

        public DataTable List(string keywords)
        {
            return VendorCategoryDL.List(keywords);
        }

        public long Insert(EL.Registrations.Vendorcategories vendorcategory)
        {
            return VendorCategoryDL.Insert(vendorcategory);
        }

        public bool Update(EL.Registrations.Vendorcategories vendorcategory)
        {
            return VendorCategoryDL.Update(vendorcategory);
        }

        public bool Delete(EL.Registrations.Vendorcategories vendorcategory)
        {
            return VendorCategoryDL.Update(vendorcategory);
        }
    }
}
