<%@ Page Title="" Language="C#" MasterPageFile="~/UserManage.Master" AutoEventWireup="true" CodeBehind="userChangePassword.aspx.cs" Inherits="music.userChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
    <form>
    <table style="width: 100%;">
        <tr>
            <td>
                旧密码：
            </td>
            <td>
                <input id="Password1" type="password" />
            </td>
        </tr>
        <tr>
            <td>
                新密码：
            </td>
            <td>
                <input id="Password2" type="password" />
            </td>
        </tr>
        <tr>
            <td>
                确认新密码：
            </td>
            <td>
                <input id="Password3" type="password" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <input id="Button1" type="button" value="确认修改" />
                <input id="Button2" type="button" value="取消" />
            </td>
        </tr>
    </table>
    </form>
</div>

</asp:Content>
