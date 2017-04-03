﻿<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Top10.aspx.cs" Inherits="music.Top10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(document).ready(function () {
        //获取后台top10
//        var json;
//        $.ajax({
//            type: "Post",
//            url: "ResponsePage.aspx",
//            data: "sql=......",
//            success: function (data) {
//                //获取json数组
//                json = eval(data);
//            }
//        });

        for (var i = 0; i < 10; i++) {
//            var songName = json[i].songName;
//            var singer = json[i].singer;
//            var hot = json[i].hot;
//            var url = json[i].url;
            $(".MusicTop10-ol").append(' <li class="list-group-item MusicTop10-ol-li"><span class="song-item">歌手</span><span class="singer-item">歌曲</span><span class="hot-item">热度</span><div class="MusicTop10-icon-bar"><span class="play-item"><a href="#"><i class="glyphicon glyphicon-play"></i></a></span><span class="collect-item"><a href="#"><i class="glyphicon glyphicon-heart"></i></a></span></div></li>');
            $(".SingerTop10-ol").append('<li class="list-group-item SingerTop10-ol-li"><span class="singer-item"><a hred="#">歌手</a></span><span class="hot-item">热度</span></li>')
        }
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
    </div>
</asp:Content>
