using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace music
{
    public class Model_User
    {
        private int id;
        private string username;
        private string password;
        public int ID
        {
            set { id = value; }
            get { return id; }
        }
        public string UserName
        {
            set { username = value; }
            get { return username; }
        }
        public string Password
        {
            set { password = value; }
            get { return password; }
        }
    }
}