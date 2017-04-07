<%@ Page Title="" Language="C#" MasterPageFile="~/UserManage.Master" AutoEventWireup="true" CodeBehind="UserChangePassword.aspx.cs" Inherits="music.userChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
    <form runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
                旧密码：
            </td>
            <td>
                <asp:TextBox ID="txtOldPWD" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                新密码：
            </td>
            <td>
                <asp:TextBox ID="txtNewPWD" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                确认新密码：
            </td>
            <td>
                <asp:TextBox ID="txtRepeatPWD" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="lblChangeInfo" runat="server" Text="&nbsp;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="btnChange" runat="server" Text="确认修改" 
                    onclick="btnChange_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="取消" onclick="btnCancel_Click" />
            </td>
        </tr>
    </table>
    </form>
</div>

</asp:Content>
