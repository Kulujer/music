<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginANDsignup.aspx.cs" Inherits="music.loginANDsignup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="width:1000px;margin:0 auto; padding:0;">
            <a href="Top10.aspx">返回</a>
        </div>
        <div style="width:1000px;margin:0 auto; padding:50px;">
            <div style="width:50%;float:left;">
            <h3>登陆</h3>
            <table>
                <tr>
                    <td>用户名：</td>
                    <td>
                        <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>密码：</td>
                    <td>
                        <asp:TextBox ID="txtLoginPWD" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="登陆" onclick="btnLogin_Click" />
                        <asp:Button ID="btnLoginCancel" runat="server" Text="取消" /></td>
                </tr>
            </table>
                <asp:Label ID="lblLoginInfo" runat="server" Text="&nbsp;" ForeColor="Red"></asp:Label>
            </div>
            <div style="width:50%;float:right;">
            <h3>注册</h3>
            <table>
                <tr>
                    <td>用户名：</td>
                    <td>
                        <asp:TextBox ID="txtSignupName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>密码：</td>
                    <td>
                        <asp:TextBox ID="txtSignupPWD" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>密码：</td>
                    <td>
                        <asp:TextBox ID="txtSignupPWDReapt" runat="server" ForeColor="Red" 
                            TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnSignup" runat="server" Text="注册" onclick="btnSignup_Click" />
                        <asp:Button ID="btnSignupCancel" runat="server" Text="取消" /></td>
                </tr>
            </table>
                <asp:Label ID="lblSignupInfo" runat="server" Text="&nbsp;"></asp:Label>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
