<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.ascx.cs" Inherits="WebApp.Controls.CategoryList" %>

<% foreach (var c in Categories)
{ %>
<span>
    <a href="<%= GetRouteUrl("category-posts", new { category = c.CategorySlug }) %>">
        <%= c.CategoryName %>
    </a>
</span>
<% } %>