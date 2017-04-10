using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace music
{
    public partial class loginANDsignup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txtLoginName.Text.Trim();
            string PWD = txtLoginPWD.Text.Trim();

            Model_User user = new Model_User();
            user.UserName = name;
            user.Password = PWD;

            BLL_UserManage userMgr = new BLL_UserManage();
            bool ret = userMgr.Login(user);
            if (ret == true)
            {
                Session["userName"] = user.UserName.ToString();//设置Session为userName
                Response.Redirect("Top10.aspx");
            }
            else
            {
                lblLoginInfo.Text = "登陆失败！";
            }

        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            string name = txtSignupName.Text.Trim();
            string PWD = txtSignupPWD.Text.Trim();
            string PWDreapt = txtSignupPWDReapt.Text.Trim();
            if (PWD == PWDreapt)
            {
                Model_User user = new Model_User();
                user.UserName = name;
                user.Password = PWD;

                BLL_UserManage userMgr = new BLL_UserManage();
                bool ret = userMgr.Signup(user);
                if (ret == true)
                {
                    Response.Redirect("Top10.aspx");
                }
                else 
                {
                    lblSignupInfo.Text = "注册失败！";
                }
            }
            else
            { lblSignupInfo.Text = "两次密码不一致！"; }
        }
    }
}