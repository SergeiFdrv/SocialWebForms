<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentSection.ascx.cs" Inherits="WebApp.Controls.CommentSection" %>

<% foreach (var c in Comments)
   {%>
    <div>
        <h3><%= c.CommentAuthor.UserName %></h3>
        <p><%= Server.HtmlDecode(c.CommentContent) %></p>
        <h4><%= c.CommentPostedUTC %></h4>
    </div>
<% } %>