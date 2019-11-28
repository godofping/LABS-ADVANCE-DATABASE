using System.Data;

namespace WATER_REFILLING_STATION.BL.REGISTRATIONS
{
    public class products
    {
        DL.REGISTRATIONS.products productDL = new DL.REGISTRATIONS.products();

        public DataTable List(string keywords)
        {
            return productDL.List(keywords);
        }

        public DataTable IsExisting(EL.REGISTRATIONS.products productEL)
        {
            return productDL.IsExisting(productEL);
        }

        public long Insert(EL.REGISTRATIONS.products productEL)
        {
            return productDL.Insert(productEL);    
        }

        public bool Update(EL.REGISTRATIONS.products productEL)
        {
            return productDL.Update(productEL);    
        }


        public bool Delete(EL.REGISTRATIONS.products productEL)
        {
            return productDL.Delete(productEL);   
        }
    }
}
