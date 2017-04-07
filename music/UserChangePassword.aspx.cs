using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace music
{
    public partial class userChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnChange_Click(object sender, EventArgs e)
        {
            string oldPWD = txtOldPWD.Text.Trim();
            string newPWD = txtNewPWD.Text.Trim();
            string repeatPWD = txtRepeatPWD.Text.Trim();

            if (newPWD == repeatPWD)
            {
                //封装Model_User
                Model_User user = new Model_User();
                user.ID = SessionContorl.GetSessionNumber("userID");
                user.Password = newPWD;

                BLL_UserManage userMgr = new BLL_UserManage();
                bool res = userMgr.userChangePassword(user);

                if (res == true)
                {
                    lblChangeInfo.Text = "修改成功！";
                }
                else
                {
                    lblChangeInfo.Text = "修改失败！";
                }
            }
            else 
            {
                lblChangeInfo.Text = "两次密码不一致！";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtNewPWD.Text = string.Empty;
            txtOldPWD.Text = string.Empty;
            txtRepeatPWD.Text = string.Empty;
        }
    }
}