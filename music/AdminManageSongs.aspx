<%@ Page Title="" Language="C#" MasterPageFile="~/AdminManage.Master" AutoEventWireup="true" CodeBehind="AdminManageSongs.aspx.cs" Inherits="music.AdminManageSongs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="搜索" />
    </div>
    <div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" 
            AllowPaging="True">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50px" />
            </asp:TemplateField>
            <asp:BoundField HeaderText="歌曲" />
            <asp:BoundField HeaderText="歌手" />
            <asp:CommandField HeaderText="操作" ShowEditButton="True">
            <ControlStyle Width="100px" />
            <HeaderStyle HorizontalAlign="Center" Width="110px" />
            <ItemStyle Width="110px" HorizontalAlign="Center" />
            </asp:CommandField>
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
    </div>

</asp:Content>
