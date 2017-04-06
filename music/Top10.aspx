<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Top10.aspx.cs" Inherits="music.Top10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(document).ready(function () {
        // 获取后台top10
        $.ajax({
            type: "Post",
            url: "Top10.aspx/GetMusictop10",
            data: {},
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                //获取json数组
                var jsonobj = eval(data.d);
                for (var i = 0; i < jsonobj.length; i++) {
                    $(".MusicTop10-ol").append(' <li class="list-group-item MusicTop10-ol-li"><span class="song-item">' + jsonobj[i].SongName + '</span><div class="MusicTop10-icon-bar"><span class="play-item"><a href="' + jsonobj[i].WebUrl + '" target="_blank"><i class="glyphicon glyphicon-play"></i></a></span><span class="collect-item"><a href="#"><i class="glyphicon glyphicon-heart"></i></a></span></div><span class="hot-item">' + jsonobj[i].Hits + '</span><span class="singer-item">' + jsonobj[i].SingerName + '</span></li>');
                }
            },
              complete: function(){
                  $.ajax({
                      type: "Post",
                      url: "Top10.aspx/GetSingertop10",
                      data: {},
                      contentType: "application/json; charset=utf-8",
                      dataType: "json",
                      success: function (data) {
                          //获取json数组
                          var jsonobj = eval(data.d);
                          for (var i = 0; i < jsonobj.length; i++) {
                              $(".SingerTop10-ol").append('<li class="list-group-item SingerTop10-ol-li"><span class="singer-item">'+jsonobj[i].Name+'</span><span class="hot-item">'+jsonobj[i].Hits+'</span></li>');
                          }
                      },
                      error: function () {
                          alert("调用失败");
                      }

                  });
            },
            error: function () {
                alert("调用失败");
            }

        });
       

    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="top10-container">
          <div class="MusicTop10 ">
          <h3 class="MusicTop10-header">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 热歌榜</h3>
          <ol class="MusicTop10-ol ">  
          </ol>
          </div>
          <div class="SingerTop10 ">
              <h3 class="SingerTop10-header">歌手榜</h3>
              <ol class="SingerTop10-ol list-group">
              </ol>
          </div>
          <div class="clear"></div>
          <asp:GridView runat="server" ID="gdvw"></asp:GridView>
    </div>
</asp:Content>
