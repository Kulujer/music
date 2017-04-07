using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data; 

namespace music
{
    public partial class AdminManageSingers : System.Web.UI.Page
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        DataTable getData()
        {
            BLL_AdminManage AdminMgr = new BLL_AdminManage();
            return AdminMgr.GetSingers();
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

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind(getData());
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //获取值
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            string singerName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim();
            int Hits = Convert.ToInt32(((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text);
            //封装Model_song
            Model_Singer singer = new Model_Singer();
            singer.ID = id;
            singer.SingerName = singerName;
            singer.Hits = Hits;
            //调用函数
            BLL_AdminManage AdminMgr = new BLL_AdminManage();
            bool ret = AdminMgr.EditSinger(singer);
            bind(getData());
            if (ret == true)
            {
                //成功代码
            }
            else
            {
                //失败代码
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind(getData());
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bind(getData());
        }
    }
}