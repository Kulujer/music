<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="SearchResult.aspx.cs" Inherits="music.SearchResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="SearchOutcome">
           <ul class="SearchOutcome-ul list-group">
               <li class="SearchOutcome-ul-li list-group-item">
                    <span class="SearchOutcome-ul-li-checkbox"><input type="checkbox"/></span>
                    <span class="song-item">歌名</span>
                    <span class="singer-item">歌手</span>
                    <span class="hot-item">热度</span>
                    <div class="SearchOutcome-icon-bar">
                        <span class="play-item"><a href="#"><i class="glyphicon glyphicon-play"></i></a></span>
                        <span class="collect-item"><a href="#"><i class="glyphicon glyphicon-heart"></i></a></span>
                    </div>
               </li>
           </ul>
       </div>
</asp:Content>
