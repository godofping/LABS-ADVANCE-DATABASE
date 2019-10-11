namespace pos.EL.Registrations
{
    public class Basicinformations
    {
        int basicinformationid;
        string firstname;
        string middlename;
        string lastname;
        string gender;
        string birthdate;

        public int Basicinformationid { get => basicinformationid; set => basicinformationid = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Middlename { get => middlename; set => middlename = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Birthdate { get => birthdate; set => birthdate = value; }
    }
}
