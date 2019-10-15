using System.Data;

namespace pos.BL.Registrations
{
    public class Products
    {
        DL.Registrations.Products ProductDL = new DL.Registrations.Products();
        public DataTable List(string keywords)
        {
            return ProductDL.List(keywords);
        }

        public long Insert(EL.Registrations.Products product)
        {
            return ProductDL.Insert(product);
        }

        public bool Update(EL.Registrations.Products product)
        {
            return ProductDL.Update(product);
        }

        public bool Delete(EL.Registrations.Products product)
        {
            return ProductDL.Delete(product);
        }
    }
}
