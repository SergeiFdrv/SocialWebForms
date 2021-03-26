<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PostTileList.ascx.cs" Inherits="WebApp.Controls.PostTileList" %>

<% foreach (var p in Posts)
{%>
    <div class="itemTile">
        <a class="entryLink" href="<%= GetRouteUrl("post-id-title", new { id = p.PostID, title = p.Slug }) %>">
            <h3><%= p.PostTitle %></h3>
        </a>
        <div class="stickToBottom">
            <h6>
                <% if (p.PostAuthor != null)
                   { %>
                <%= p.PostAuthor.UserName %>
                    <% if (p.PostAuthor.UserLogin == System.Web.HttpContext.Current.User?.Identity.Name)
                       { %>
                (<a href="<%= GetRouteUrl("user-editpost", new { id = p.PostID }) %>">Edit</a>)
                    <% } %>
                <% } %>
                <%= p.PostDateUTC %>
            </h6>
        </div>
    </div>
<%} %>