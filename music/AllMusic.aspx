<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AllMusic.aspx.cs" Inherits="music.AllMusic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(document).ready(function () {
        //获取歌曲类别数
        var jsonType;
        $.ajax({
            type: "Post",
            url: "AllMusic.aspx/TypeCount",
            data: {},
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                jsonType = eval(data.d);
                for (var i = jsonType.length - 1; i >= 0; i--) {
                    var musicDiv = '<h4 style="background-color:#9f0000;color:#fff;border-radius:5px;">' + jsonType[i].Name + '</h4>';
                    musicDiv += '<div class="music-tb">';
                    musicDiv += '<table id="musictable-' + i + '" class="table table-striped">';
                    musicDiv += '<thead>';
                    musicDiv += '<tr>';
                    musicDiv += '<th class="checkbox-th"></th>';
                    musicDiv += '<th class="songName-th">歌名</th>';
                    musicDiv += '<th class="singer-th">歌手</th>';
                    musicDiv += '<th class="hits-th">热度</th>';
                    musicDiv += '<th class="play-th"></th>';
                    musicDiv += '<th class="collect-th"></th>';
                    musicDiv += '</tr>';
                    musicDiv += '</thead>';
                    musicDiv += '<tr id="hidden-tr" style="line-height:0px;"></tr>';
                    musicDiv += ' </table>';
                    musicDiv += ' </div>';
                    $(".AllMusic").append(musicDiv);
                }
            },
            complete: function () {
                $(".accordion").accordion({ heightStyle: "content" });
                var i = jsonType.length - 1;
                FillTable(i);
            }
        });
        function FillTable(i) {
            if (i > 0) {
                $.ajax({
                    type: "Post",
                    url: "AllMusic.aspx/GetTable",
                    data: "{'type':'" + jsonType[i].Name + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        var jsonTable = eval(data.d);
                        for (var j = jsonTable.length - 1; j >= 0; j--) {
                            $("#musictable-" + i).append('<tr><td><input type="checkbox"/></td><td>' + jsonTable[j].SongName + '</td> <td>' + jsonTable[j].SingerName + '</td><td>' + jsonTable[j].Hits + '</td><td><a href="' + jsonTable[j].WebUrl + '" target="_blank"><i class="glyphicon glyphicon-play"></i></a></td><td><a><i class="glyphicon glyphicon-heart"></i></a></td></tr>');
                        }
                    },
                    complete: function () {
                        i--;
                        FillTable(i);
                    }
                });
            }
        }
    });     
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="AllMusic accordion">
      
  </div>
</asp:Content>
