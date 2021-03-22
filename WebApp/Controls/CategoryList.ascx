<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.ascx.cs" Inherits="WebApp.Controls.CategoryList" %>

<% foreach (WebApp.Models.Category c in Categories)
{ %>
<span>
    <a href="<%= GetRouteUrl("category-posts", new { category = c.CategorySlug }) %>">
        <%= c.CategoryName %>
    </a>
</span>
<% } %>