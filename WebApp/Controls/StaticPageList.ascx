<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StaticPageList.ascx.cs" Inherits="WebApp.Controls.StaticPageList" %>

<span>
    <a href="/"><%= Resources.Language.Main %></a>
</span>
<span>
    <a href="<%= GetRouteUrl("search-page", null) %>"><%= Resources.Language.Search %></a>
</span>