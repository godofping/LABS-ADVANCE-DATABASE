namespace pos.BL.Registrations
{
    public class BasicInformations
    {
        DL.Registrations.BasicInformations basicInformationDL = new DL.Registrations.BasicInformations();

        public long Insert(EL.Registrations.BasicInformations basicInformationEL)
        {
            return basicInformationDL.Insert(basicInformationEL);
        }

        public bool Update(EL.Registrations.BasicInformations basicInformationEL)
        {
            return basicInformationDL.Update(basicInformationEL);
        }
    }
}
