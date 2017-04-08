<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AllSinger.aspx.cs" Inherits="music.AllSinger" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(document).ready(function () {
        $.ajax({
            type: "Post",
            url: "AllSinger.aspx/GetSinger",
            data: {},
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var json = eval(data.d);
                for (var i = 0; i < json.length; i++) {
                    $(".SingerTop10-ol").append('<li class="list-group-item SingerTop10-ol-li"><span class="singer-item"><a>' + json[i].Name + '</a></span><span class="hot-item">' + json[i].Hits + '</span></li>');
                }
            }
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="AllSinger">
    <div class="SingerTop10 ">
          <h3 class="SingerTop10-header">热门歌手</h3>
          <ol class="SingerTop10-ol list-group">
          </ol>
    </div>
    <div class="other-singer">
        
    </div>
    <div class="clear"></div>
</div>
</asp:Content>
