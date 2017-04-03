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

        [WebMethod]
        ///返回音乐top10
        public static string Gettop10(string sql)
        {
            //获取音乐top10的表格
            DataTable table = DAO_databaseControl.GetDataSet(sql);
            string jsonString = string.Empty;
            //json序列化
            jsonString = JsonConvert.SerializeObject(table);
            return jsonString;
        }

    }
}