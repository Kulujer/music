using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace music
{
    public partial class GrapManage : System.Web.UI.Page
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        DataTable getData()
        {
            BLL_AdminManage AdminMgr = new BLL_AdminManage();
            return AdminMgr.GetGrap();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="dt"></param>
        void bind(DataTable dt)
        {
            GridView1.DataSource = dt;
            GridView1.DataKeyNames = new string[] { "ID" };
            GridView1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                bind(getData());
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bind(getData());
        }
    }
}