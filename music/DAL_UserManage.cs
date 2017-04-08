using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.SessionState;

namespace music
{
    public class DAL_UserManage
    {

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool SignUp(Model_User user)
        {
            string sql = "insert into [dbo].[user]([userName],[password])values(@username,@password)";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@username",user.UserName),
                new SqlParameter("@password",user.Password),
            };
            int ret = sqlHelper.ExecuteSql(sql, parameters);
            if (ret > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool login(Model_User user)
        {
            string sql = "select [userID] from [dbo].[user] where [username]=@username and [password]=@password";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@username",user.UserName),
                new SqlParameter("@password",user.Password),
            };
            DataTable dt_res = sqlHelper.GetDataSet(sql, parameters);
            if (dt_res.Rows.Count > 0)
            {
                //SessionContorl.SetSession("userID", dt_res.Rows[0][0]);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据用户信息获取该用户收藏内容
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static DataTable GetCollections(Model_User user)
        {
            //根据用户id查询该用户的收藏表
            string QueryString = "select [songName],[singerName],[weburl],[collectID] from [dbo].[collect] where userID=@userID";
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@userID",user.ID),
            };
            DataTable dt_temp = sqlHelper.GetDataSet(QueryString, parameters);

            return dt_temp;
        }

        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteCollections(int id)
        {
            string DelString = "delete from [collect] where [collectID]=@collectID";
            SqlParameter[] parameters=new SqlParameter[]{
                new SqlParameter("@collectID",id),
            };
            int ret = sqlHelper.ExecuteSql(DelString,parameters);
            if(ret==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool userChangePassword(Model_User user)
        {
            string updateString = "update [dbo].[user] set [password]=@password where [userID]=@userID";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@password",user.Password),
                new SqlParameter("@userID",user.ID),
            };
            int ret = sqlHelper.ExecuteSql(updateString,parameters);
            if(ret==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable GetMatch(string keyword)
        {
            string matchString = "select top 10 [SingerName],[SongName] from [dbo].[t_music] where [SingerName] like '%" + keyword + "%' or [SongName] like '%" + keyword + "%'";

            DataTable dt_temp = sqlHelper.GetDataSet(matchString);

            return dt_temp;
        }

    }
}