using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace music
{
    public class BLL_UserManage
    {
        public bool Login(Model_User user)
        { 
            DAL_UserManage userMgr = new DAL_UserManage();
            return userMgr.login(user);
        }

        public bool Signup(Model_User user)
        {
            DAL_UserManage userMgr = new DAL_UserManage();
            return userMgr.SignUp(user);
        }

        public DataTable GetCollections(Model_User user)
        { 
            return DAL_UserManage.GetCollections(user);
        }

        public bool DeleteCollections(int id)
        {
            return DAL_UserManage.DeleteCollections(id);
        }

        public bool userChangePassword(Model_User user)
        {
            DAL_UserManage userMgr = new DAL_UserManage();
            return userMgr.userChangePassword(user);
        }
    }
}