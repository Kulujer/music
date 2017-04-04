<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="SearchResult.aspx.cs" Inherits="music.SearchResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            for (var i = 10; i > 0; i--) {
                $(".previous-li").after('<li id="fengye-li-' + i + '"><a href="javascript:void(0)">' + i + '</a><li>');
                $("#fengye-li-" + i).find("a").click(function () {
                    $(this).parent().addClass("active").siblings().removeClass("active");
                    $.ajax({
                        type: "Post",
                        url: "SearchResult.aspx/GetArray",
                        data: i,         //传参
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            $(".SearchOutcome-ul").html("");
                            for (var j = 0; j < data.d.length; j++) {
                                $(".SearchOutcome-ul").append('<li class="SearchOutcome-ul-li list-group-item"><span>' + (j + 1) + '</span><span class="SearchOutcome-ul-li-checkbox"><input type="checkbox"/></span><span class="song-item">歌名</span><span class="singer-item">歌手</span><span class="hot-item">热度</span> <div class="SearchOutcome-icon-bar"><span class="play-item"><a href="#"><i class="glyphicon glyphicon-play"></i></a></span><span class="collect-item"><a href="#"><i class="glyphicon glyphicon-heart"></i></a></span></div></li>');
                            }
                        },
                        error: function (err) {
                            alert("加载失败");
                        }
                    });
                });
            }
            $.ajax({
                type: "Post",
                url: "SearchResult.aspx/GetArray",
                data: {},         //传参
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $("#fengye-li-1").addClass("active");
                    for (var i = 0; i < data.d.length; i++) {
                        $(".SearchOutcome-tb").append('<tr><td><input type="checkbox"/></td><td>songName</td> <td>singer</td><td>hot</td><td><a><i class="glyphicon glyphicon-play"></i></a></td><td><a><i class="glyphicon glyphicon-heart"></i></a></td></tr>');
                }
                },
                error: function (err) {
                    alert("加载失败");
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="SearchOutcome">
          <div style="background-color:#9f0000;height:20px;"></div>
           <table class="SearchOutcome-tb table table-striped">
               <tr style="background-color:#9f0000"></tr>
               <thead>
                   <tr>
                       <th></th>
                       <th>歌名</th>
                       <th>歌手</th>
                       <th>热度</th>
                       <th></th>
                       <th></th>
                   </tr>
               </thead>
               <tr style="line-height:0px;"></tr>
           </table>
       </div>
        <div class="fengye">
            <ul class="fengye-ul pagination pagination-lg">
                <li class="previous-li"><a href="javascript:void(0)">&laquo;</a></li>
                <li><a href="javascript:void(0)">&raquo;</a></li>
            </ul><br>
        </div>
</asp:Content>
