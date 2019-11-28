using System.Data;

namespace WATER_REFILLING_STATION.BL.REGISTRATIONS
{
    public class particulars
    {
        DL.REGISTRATIONS.particulars particularDL = new DL.REGISTRATIONS.particulars();

        public DataTable List(string keywords)
        {
            return particularDL.List(keywords);
        }

        public DataTable List()
        {
            return particularDL.List();
        }

        public long Insert(EL.REGISTRATIONS.particulars particularEL)
        {
            return particularDL.Insert(particularEL);
        }

        public bool Update(EL.REGISTRATIONS.particulars particularEL)
        {
            return particularDL.Update(particularEL);
        }


        public bool Delete(EL.REGISTRATIONS.particulars particularEL)
        {
            return particularDL.Delete(particularEL);
        }
    }
}
