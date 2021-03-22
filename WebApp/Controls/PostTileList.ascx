<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PostTileList.ascx.cs" Inherits="WebApp.Controls.PostTileList" %>

<% foreach (var p in Posts)
{%>
    <div class="itemTile">
        <a class="entryLink" href="<%= GetRouteUrl("post-id-title", new { id = p.PostID, title = p.Slug }) %>">
            <h3><%= p.PostTitle %></h3>
            <h6><%= (p.PostAuthor != null) ? $"{p.PostAuthor.UserName}, {p.PostDateUTC}" : $"{p.PostDateUTC}" %></h6>
            <% if (p.PostAuthor?.UserLogin == System.Web.HttpContext.Current.User?.Identity.Name)
               { %>
            <a class="stickToBottom" href="<%= GetRouteUrl("user-editpost", new { id = p.PostID }) %>">Edit</a>
            <% } %>
        </a>
    </div>
<%} %>