<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="SearchResult.aspx.cs" Inherits="music.SearchResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var jsonobj;
            $.ajax({
                type: "Post",
                url: "SearchResult.aspx/Pagecount",
                data: {},
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //添加分页数
                    var jsonfengye = eval(data.d);
                    $(".fengye-ul").html("");
                    for (var i = 1; i <= jsonfengye; i++) {
                        $(".fengye-ul").append('<li id="fengye-li-' + i + '"><a href="javascript:void(0)">' + i + '</a><li>');
                        $("#fengye-li-" + i).find("a").click(function () {
                            $(this).parent().addClass("active").siblings().removeClass("active");
                            $.ajax({
                                type: "Post",
                                url: "SearchResult.aspx/GetOutcome",
                                data: "{ 'page': '" + $(this).text() + "' }",
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (data) {
                                    jsonobj = eval(data.d);
                                    //移除同级所有元素
                                    $("#hidden-tr").nextAll().remove();
                                    //添加搜索信息
                                    for (var j = 0; j < jsonobj.length; j++) {
                                        $(".SearchOutcome-tb").append('<tr><td><input type="checkbox"/></td><td>' + jsonobj[j].SongName + '</td> <td>' + jsonobj[j].SingerName + '</td><td>' + jsonobj[j].Hits + '</td><td><a href="' + jsonobj[j].WebUrl + '" target="_blank"><i class="glyphicon glyphicon-play"></i></a></td><td><a class="collection"><i class="glyphicon glyphicon-heart"></i></a></td></tr>');
                                    }
                                },
                                error: function () {
                                    alert("加载搜索结果失败");
                                }
                            });
//                            $(document).on('click', '.collection', function (e) {
//                                var td = $(this).parent().siblings();
//                                var SongName = td.index(1).text();
//                                $.ajax({
//                                    type: "Post",
//                                    url: "SearchResult.aspx/AddCollection",
//                                    data: "{ 'page': '""' }",
//                                    contentType: "application/json; charset=utf-8",
//                                    dataType: "json",
//                                    success: function (data) {
//                                        alert("调用成功")
//                                    },
//                                    error: function () {
//                                        alert("调用失败");
//                                    }
//                                });
//                            });
                        });
                    }

                },
                error: function () {
                    alert("加载分页失败")
                },
                complete: function () { $("#fengye-li-1").find("a").click(); }
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="SearchOutcome">
          <div style="background-color:#9f0000;height:20px;"></div>
           <table class="SearchOutcome-tb table table-striped">
               <thead>
                   <tr>
                       <th class="checkbox-th"></th>
                       <th class="songName-th">歌名</th>
                       <th class="singer-th">歌手</th>
                       <th class="hits-th">热度</th>
                       <th class="play-th"></th>
                       <th class="collect-th"></th>
                   </tr>
               </thead>
               <tr id="hidden-tr" style="line-height:0px;"></tr>
           </table>
       </div>
        <div class="fengye">
            <ul class="fengye-ul pagination pagination-lg">
                
            </ul><br/>
        </div>
</asp:Content>
