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
        private static DataTable table = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (table != null || table.Rows.Count != 0)
            {
                table.Clear();
            }
            table = GetTable(Session["key"].ToString());
        }
       
        /// <summary>
        /// 获取100条总记录
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static DataTable GetTable(string key)
        {
            string sql = string.Empty;
            if (key != null && key.Equals(""))
            {
                 sql = string.Format("select top 100 SongName,SingerName,WebUrl,Hits from t_music ORDER BY Hits");
            }
            else
            {
                 sql = string.Format("select top 100 SongName,SingerName,WebUrl,Hits from t_music ORDER BY Hits ");
            }
            DataTable table = sqlHelper.GetDataSet(sql);
            return table;
        }

        /// <summary>
        /// 分页数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [WebMethod]
        private static int Pagecount()
        {
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
        public static string GetOutcome(int page)
        {
            DataTable SelectTable = new DataTable();
            for (int i = page*10; i < (page+1)*10; i++)
            {
                DataRow row = table.Rows[i];
                SelectTable.Rows.Add(row);
            }
            string JsonString = string.Empty;
            JsonString = JsonConvert.SerializeObject(SelectTable);
            return JsonString;
        }

    }
}