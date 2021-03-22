<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WebApp.Pages.Profile" MasterPageFile="~/Pages/ProfileMaster.Master" %>
<%@ Register TagPrefix="custom" TagName="PostTiles" Src="~/Controls/PostTileList.ascx" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <title><%= CurrentUser.UserName %>'s profile page</title>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ProfileContent">
    <div>
        <div class="bs-row">
            <h3><%= CurrentUser.UserName %></h3>
            <p><%= CurrentUser.UserLogin %></p>
        </div>
        <div class="bs-row">
            <h6>Registered: <%= CurrentUser.UserRegisteredUTC %> UTC</h6>
            <h6>Last login: <%= CurrentUser.UserLastLoginUTC %> UTC</h6>
        </div>
        <a href="<%= CurrentUser.UserWebsite %>"><%= CurrentUser.UserWebsite %></a>
        <div class="bs-container">
            <h3>Posts</h3>
            <div class="bs-row bs-row-3">
                <custom:PostTiles runat="server" ID="PostTiles" />
            </div>
        </div>
    </div>
</asp:Content>