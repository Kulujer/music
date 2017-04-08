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

        public string GetMatches(string keyword)
        {
            DAL_UserManage AdminMgr = new DAL_UserManage();
            DataTable dt_temp = AdminMgr.GetMatch(keyword);

            string JSONString = string.Empty;
            JSONString += "{\"res\":[";
            for (int i = 0; i < dt_temp.Rows.Count; i++)
            {
                JSONString += "\"";
                JSONString += dt_temp.Rows[i][0];
                JSONString += "————";
                JSONString += dt_temp.Rows[i][1];
                JSONString += "\",";
            }
            JSONString = JSONString.TrimEnd(',');
            JSONString += "]}";

            return JSONString;
        }
    }
}