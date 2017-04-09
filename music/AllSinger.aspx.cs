using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using Newtonsoft.Json;

namespace music
{
    public partial class AllSinger : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 获取前10歌手
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string GetSinger(string key)
        {
            string sql = "select [Name] from [dbo].[t_singer] where [Name] like '%" + key + "%' ORDER BY Hits";
            DataTable table = sqlHelper.GetDataSet(sql);
            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(table);
            return jsonString;
        }
    }

   



}