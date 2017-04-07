<%@ Page Title="" Language="C#" MasterPageFile="~/UserManage.Master" AutoEventWireup="true" CodeBehind="UserManageCollections.aspx.cs" Inherits="music.UserManageCollections" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" Width="100%" CellPadding="4" 
        ForeColor="#333333" GridLines="None" AllowSorting="True" 
        onrowdeleting="GridView1_RowDeleting" 
        onpageindexchanging="GridView1_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    选择
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </ItemTemplate>
                <ControlStyle Width="50px" />
                <ItemStyle Width="52px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="序号">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" 
                        Text="<%# this.GridView1.PageIndex * this.GridView1.PageSize + this.GridView1.Rows.Count + 1%>"></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="50px" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="52px" />
            </asp:TemplateField>
            <asp:BoundField HeaderText="歌曲名" DataField="songName">
            <ControlStyle Width="150px" />
            <ItemStyle Width="152px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="歌手" DataField="singerName">
            <ControlStyle Width="150px" />
            <HeaderStyle HorizontalAlign="Center" Width="152px" />
            <ItemStyle HorizontalAlign="Center" Width="152px" />
            </asp:BoundField>
            <asp:HyperLinkField HeaderText="播放" Text="播放" DataNavigateUrlFields="weburl">
            <ControlStyle Width="50px" />
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" Width="52px" />
            </asp:HyperLinkField>
            <asp:CommandField DeleteText="取消收藏" HeaderText="操作" ShowDeleteButton="True" >
            <ControlStyle Width="70px" />
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" Width="72px" />
            </asp:CommandField>
            <asp:BoundField HeaderText="collectID" Visible="False" DataField="collectID" />
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
        <asp:CheckBox ID="CheckAll" runat="server" 
            oncheckedchanged="CheckAll_CheckedChanged" AutoPostBack="True" />全选
    </div>
    <div>
        <asp:Button ID="btnDel" runat="server" Text="取消收藏" onclick="btnDel_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="取消" onclick="btnCancel_Click" />
    </div>
</div>
</asp:Content>
