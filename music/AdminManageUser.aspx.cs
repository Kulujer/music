using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace music
{
    public partial class AdminManageUser : System.Web.UI.Page
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        DataTable getData()
        {
            BLL_AdminManage AdminMgr = new BLL_AdminManage();
            return AdminMgr.GetUsers();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="dt"></param>
        void bind(DataTable dt)
        {
            GridView1.DataSource = dt;
            GridView1.DataKeyNames = new string[] { "userID" };
            GridView1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind(getData());
            }
        }

        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                if (chkAll.Checked == true)
                { chk.Checked = true; }
                else
                { chk.Checked = false; }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bind(getData());
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            bool res;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                if (chk.Checked == true)
                {
                    int id = Convert.ToInt32(GridView1.DataKeys[i].Value);
                    BLL_AdminManage AdminMgr = new BLL_AdminManage();
                    res = AdminMgr.DeleteUser(id);
                }
            }
            bind(getData());
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            chkAll.Checked = false;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                chk.Checked = false;
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind(getData());
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string name = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();
            string PWD = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim();

            Model_User user = new Model_User();
            user.UserName = name;
            user.Password = PWD;

            BLL_AdminManage AdminMgr = new BLL_AdminManage();
            bool ret = AdminMgr.UpdateUser(user);
            if (ret == false)
            { 
                //修改成功代码
            }
            GridView1.EditIndex = -1;
            bind(getData());

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind(getData());
        }
    }
}