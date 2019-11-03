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

        public DataTable List(int id)
        {
            return ProductDL.List(id);
        }

        public long Insert(EL.Registrations.Products productEL)
        {
            return ProductDL.Insert(productEL);
        }

        public bool Update(EL.Registrations.Products productEL)
        {
            return ProductDL.Update(productEL);
        }

        public bool Delete(EL.Registrations.Products productEL)
        {
            return ProductDL.Delete(productEL);
        }
    }
}
