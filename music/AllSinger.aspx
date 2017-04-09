<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AllSinger.aspx.cs" Inherits="music.AllSinger" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(document).ready(function () {
        //添加字母线
        for (var i = 0; i < 26; i++) {
            $(".AllSinger").append("<h3>" + String.fromCharCode(i + 65) + "</h3>")
            $(".AllSinger").append('<div id="primary-' + i + '"></div>')
        }
        //添加歌手名btn
        GetSinger(0);

        //为歌手名btn添加跳转事件
        $(document).on('click', '.btn', function (e) {
            $("#txtSearch").val($(this).val());
            $("#btnSearch").click();
        });
        //添加歌手名函数
        function GetSinger(i) {
            if (i < 26) {
                $.ajax({
                    type: "Post",
                    url: "AllSinger.aspx/GetSinger",
                    dataType: "json",
                    data: "{ 'key': '" + String.fromCharCode(i + 65) + "' }",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        var json = eval(data.d);

                        for (var j = 0; j < json.length; j++) {
                            if ((j + 1) % 5 != 0) {
                                $("#primary-" + i).append('<input type="button" class="btn btn-default" value="' + json[j].Name + '" style="width:150px;margin-left:10px;margin-top:10px;"/>');
                            }
                            else {
                                $("#primary-" + i).append('<br/>');
                            }
                        }
                    },
                    complete: function () {

                        i++;
                        GetSinger(i);
                    }
                });
            }

        }
    });

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="AllSinger">

</div>
</asp:Content>
