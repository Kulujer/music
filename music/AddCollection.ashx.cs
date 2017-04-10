using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace music
{
    /// <summary>
    /// AddCollection 的摘要说明
    /// </summary>
    public class AddCollection : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            BLL_UserManage userManage = new BLL_UserManage();
            Model_Song song = new Model_Song();
            string SongName = context.Request.Form["SongName"].ToString();
            string WebUrl = context.Request.Form["WebUrl"].ToString();
            Guid ID = new Guid(context.Request.Form["ID"]);
            int userid = int.Parse(context.Request.Form["user"]);
            song.SongName = SongName;
            song.WebUrl = WebUrl;
            song.ID = ID;
            Model_User user = new Model_User();
            user.ID = userid;
            bool hasAdd = userManage.isSongCollect(song.ID, user.ID);
            //判断是否已经添加过此歌曲
            if (hasAdd)
            {
                context.Response.Write("已经添加过此歌曲");
            }
            else
            {
                //判断是否成功添加此歌曲
                bool IsAdd = userManage.userAddCollection(user, song);
                if (IsAdd)
                {
                    context.Response.Write("添加成功");
                }
                else
                {
                    context.Response.Write("添加失败");
                }
            }
            
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}