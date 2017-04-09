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
                for (var i = jsonobj.length -1; i >=0 ; i--) {
                    $(".MusicTop10-ol").append(' <li class="list-group-item MusicTop10-ol-li"><span class="song-item">' + jsonobj[i].SongName + '</span><div class="MusicTop10-icon-bar"><span class="play-item"><a href="' + jsonobj[i].WebUrl + '" target="_blank"><i class="glyphicon glyphicon-play"></i></a></span><span class="collect-item"><a class="collection"><i class="glyphicon glyphicon-heart"></i><span>' + jsonobj[i].SongName + '</span><span>' + jsonobj[i].WebUrl + '</span><span>' + jsonobj[i].ID + '</span></a></span></div><span class="hot-item">' + jsonobj[i].Hits + '</span><span class="singer-item">' + jsonobj[i].SingerName + '</span></li>');
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
                          for (var i = jsonobj.length - 1; i >= 0; i--) {
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
            //添加收藏
        });
        $(document).on('click', '.collection', function (e) {
            var SongName = $(this).find("span").eq(0).text();
            var WebUrl = $(this).find("span").eq(1).text();
            var ID = $(this).find("span").eq(2).text();
            $.ajax({
                type: "Post",
                url: "AddCollection.ashx",
                data: { "SongName": SongName, "WebUrl": WebUrl, "ID": ID },
//                success: function (data) {
//                    alert("调用成功");
//                },
//                error: function (XMLHttpRequest, textStatus, errorThrown) {
//                    alert(XMLHttpRequest.status);
//                    alert(XMLHttpRequest.readyState);
//                    alert(textStatus);
//                }
            });
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
