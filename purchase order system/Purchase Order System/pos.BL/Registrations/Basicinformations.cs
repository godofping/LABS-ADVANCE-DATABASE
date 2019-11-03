namespace pos.BL.Registrations
{
    public class Basicinformations
    {
        DL.Registrations.BasicInformations basicInformationDL = new DL.Registrations.BasicInformations();

        public long Insert(EL.Registrations.Basicinformations basicinformation)
        {
            return basicInformationDL.Insert(basicinformation);
        }

        public bool Update(EL.Registrations.Basicinformations basicinformation)
        {
            return basicInformationDL.Update(basicinformation);
        }
    }
}
