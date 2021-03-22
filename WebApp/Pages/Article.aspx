<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Article.aspx.cs" Inherits="WebApp.Pages.Article" MasterPageFile="~/MainMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <title><%= Post.PostTitle %></title>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div>
        <div class="bs-container">
            <h6><%= Category.CategoryName %></h6>
        </div>
        <div class="bs-container">
            <h3><%= Post.PostTitle %></h3>
        </div>
        <div id="postContent" class="bs-container">
            <%= Server.HtmlDecode(Post.PostContent) %>
        </div>
    </div>
</asp:Content>
