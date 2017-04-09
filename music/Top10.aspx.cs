using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Newtonsoft.Json;
using System.Data;

namespace music
{
    public partial class Top10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 返回音乐top10
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string GetMusictop10()
        {
            //获取音乐top10的表格
            string sql = "select top 10 SongName,SingerName,WebUrl,Hits,ID from t_music ORDER BY Hits;";
            DataTable table = sqlHelper.GetDataSet(sql);
            string jsonString = string.Empty;
            //json序列化
            jsonString = JsonConvert.SerializeObject(table);   
            return jsonString;
        }

        /// <summary>
        /// 获取歌手top10
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string GetSingertop10()
        {
            //获取歌手top10的表格
            string sql = "select top 10 Name,Hits from t_singer ORDER BY Hits;";
            DataTable table = sqlHelper.GetDataSet(sql);
            string jsonString = string.Empty;
            //json序列化
            jsonString = JsonConvert.SerializeObject(table);
            return jsonString;
        }
    }
}