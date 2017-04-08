using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using Newtonsoft.Json;

namespace music
{
    public partial class AllMusic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

                /// <summary>
        /// 获取音乐种类
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string TypeCount()
        {
            string sql = "select Name from t_musictype";
            DataTable table = sqlHelper.GetDataSet(sql);
            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(table);
            return jsonString;
        }

        //获取相应类别表格
        [WebMethod]
        public static string GetTable(string type)
        {
            string sql = "select top 20 SongName,SingerName,WebUrl,Hits from t_music where TypeName='" + type + "'";
            DataTable table = sqlHelper.GetDataSet(sql);
            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(table);
            return jsonString;
        }
    }
  }
