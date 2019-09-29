using System;
using System.Collections.Generic;
using System.Text;

namespace pos.EL.Registrations
{
    public class Users
    {
        int userid;
        string username;
        string password;
     

        public int Userid { get => userid; set => userid = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}
