namespace pos.BL.Transactions
{
    public class Login
    {
        public int StaffLogin(pos.EL.Transactions.Login staff)
        {
            pos.DL.Transactions.Login loginDL = new pos.DL.Transactions.Login();
            return loginDL.StaffLogin(staff);
        }
    }
}
