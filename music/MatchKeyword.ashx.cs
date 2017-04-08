using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace music
{
    /// <summary>
    /// MatchKeyword 的摘要说明
    /// </summary>
    public class MatchKeyword : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string key = context.Request.Form["key"].ToString();

            BLL_UserManage AdminMgr = new BLL_UserManage();
            string res = AdminMgr.GetMatches(key);

            context.Response.Write(res);
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