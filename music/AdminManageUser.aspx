﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminManage.Master" AutoEventWireup="true" CodeBehind="AdminManageUser.aspx.cs" Inherits="music.AdminManageUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" Width="100%" CellPadding="4" 
        ForeColor="#333333" GridLines="None" AllowSorting="True" 
        onpageindexchanging="GridView1_PageIndexChanging" 
        onrowcancelingedit="GridView1_RowCancelingEdit" 
        onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
        PageSize="20">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="50px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="序号">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="50px" />
                <ItemStyle HorizontalAlign="Center" Width="52px" />
            </asp:TemplateField>
            <asp:BoundField HeaderText="用户名" DataField="userName" />
            <asp:BoundField HeaderText="密码" DataField="password" />
            <asp:CommandField HeaderText="操作" ShowEditButton="True">
            <ControlStyle Width="100px" />
            <HeaderStyle HorizontalAlign="Center" Width="110px" />
            <ItemStyle HorizontalAlign="Center" Width="110px" />
            </asp:CommandField>
            <asp:BoundField DataField="userID" HeaderText="userID" Visible="False" />
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
    <div>
        <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="True" 
            oncheckedchanged="chkAll_CheckedChanged" />全选&nbsp;
        <asp:Button ID="btnDel" runat="server" Text="删除" onclick="btnDel_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="取消" onclick="btnCancel_Click" />
    </div>
</asp:Content>
