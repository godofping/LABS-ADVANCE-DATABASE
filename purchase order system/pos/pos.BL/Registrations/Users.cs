namespace pos.BL.Registrations
{
    public class Users
    {
        public int Login(pos.EL.Registrations.Users user)
        {
            pos.DL.Registrations.Users userDL = new pos.DL.Registrations.Users();
            return userDL.Login(user);
        }
    }
}
