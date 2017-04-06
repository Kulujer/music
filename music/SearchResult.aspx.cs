using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using Newtonsoft.Json;
using System.Text;
using System.Data.SqlClient;

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
            if (key != null && !key.Equals(""))
            {
                sql = "select SongName,SingerName,WebUrl,Hits from t_music where SongName='" + key + "' or SingerName='" + key + "' ORDER BY Hits"; 
            }
            else
            {
                sql = "select top 100 SongName,SingerName,WebUrl,Hits from t_music ORDER BY Hits";
            }
            DataTable table = sqlHelper.GetDataSet(sql);
            //超过一百条记录，则选取其中前一百条
            if (table.Rows.Count <= 100)
                return table;
            else
            {
                for (int i = 100; i < table.Rows.Count; i++)
                {
                    table.Rows.RemoveAt(i);
                }
                return table;
            }
        }

        /// <summary>
        /// 分页数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [WebMethod]
        public static int Pagecount()
        {
            int pagecount = 0;
            //整除10
            if (table.Rows.Count % 10 == 0)
            {
                pagecount = table.Rows.Count / 10;
            }
            //有余数
            else 
            {
                pagecount = (table.Rows.Count / 10) + 1;
            }
            
            return pagecount;
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <param name="key"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [WebMethod]
        public static string GetOutcome(string page)
        {
            int Intpage = int.Parse(page);
            //克隆table结构
            DataTable SelectTable = table.Clone();
            //判断table记录数是否能填满page的页数
            if (table.Rows.Count >= Intpage * 10)
            {
                //填满则读取10条记录填充page中
                for (int i = (Intpage * 10) - 1; i >= (Intpage - 1) * 10; i--)
                {
                    if (table.Rows[i] != null)
                    {
                        SelectTable.Rows.Add(table.Rows[i].ItemArray);
                    }
                }
            }
            else 
            {
                //填不满
                for (int i = table.Rows.Count - 1; i >= (Intpage - 1) * 10; i--)
                {
                    if (table.Rows[i] != null)
                    {
                        SelectTable.Rows.Add(table.Rows[i].ItemArray);
                    }
                }
            }     
            string JsonString = string.Empty;
            JsonString = JsonConvert.SerializeObject(SelectTable);
            return JsonString;
        }

    }
}