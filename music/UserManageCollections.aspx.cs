using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace music
{
    public partial class UserManageCollections : System.Web.UI.Page
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        DataTable getData()
        { 
            Model_User user = new Model_User();
            //取用户ID
            user.UserName = Session["userName"].ToString();

            BLL_UserManage userMgr = new BLL_UserManage();
            return userMgr.GetCollections(user);
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="dt"></param>
        void bind(DataTable dt)
        {
            GridView1.DataSource = dt;
            GridView1.DataKeyNames = new string[] { "collectID" };
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userID"] != null)
                {
                    bind(getData());
                    lblStateInfo.Text = Session["userID"] + "欢迎你";
                }
                else
                {
                    Response.Redirect("loginANDsignup.aspx");
                }
                
            }
        }

        /// <summary>
        /// 全选按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CheckAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                if (CheckAll.Checked == true)
                {
                    chk.Checked = true;
                }
                else
                {
                    chk.Checked = false;
                }
            }
        }

        /// <summary>
        /// 取消选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            CheckAll.Checked = false;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                chk.Checked = false;
            }
        }

        //删除
        protected void btnDel_Click(object sender, EventArgs e)
        {
            bool res;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                if (chk.Checked == true)
                {
                    int id = Convert.ToInt32(GridView1.DataKeys[i].Value);
                    BLL_UserManage userMgr = new BLL_UserManage();
                    res = userMgr.DeleteCollections(id);
                }
            }
            bind(getData());
        }

        //行删除
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            BLL_UserManage userMgr = new BLL_UserManage();
            bool res = userMgr.DeleteCollections(id);
            if (res == false)
            { 
                //删除失败代码
            }
            bind(getData());
        }

        //分页
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bind(getData());
        }

    }
}