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
    public partial class SearchResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<string> GetArray()
        {
            List<string> li = new List<string>();

            for (int i = 0; i < 10; i++)
                li.Add(i + "");

            return li;

        }

        /// <summary>
        /// 获取100条总记录
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static DataTable GetTable(string key)
        {
            string sql = string.Format("select top 100 SongName,SingerName,WebUrl,Hits from t_music ORDER BY Hits WHERE SongName='{0}' or SingerName='{0}' ",key);
            DataTable table = sqlHelper.GetDataSet(sql);
            return table;
        }

        /// <summary>
        /// 分页数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [WebMethod]
        private static int Pagecount(string key)
        {
            DataTable table = GetTable(key);
            int pagecount = table.Rows.Count/10;
            return pagecount;
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <param name="key"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [WebMethod]
        public static string GetOutcome(string key,int page)
        {
            DataTable TotalTable = GetTable(key);
            DataTable SelectTable = new DataTable();
            for (int i = page*10; i < (page+1)*10; i++)
            {
                DataRow row = TotalTable.Rows[i];
                SelectTable.Rows.Add(row);
            }
            string JsonString = string.Empty;
            JsonString = JsonConvert.SerializeObject(SelectTable);
            return JsonString;
        }

    }
}