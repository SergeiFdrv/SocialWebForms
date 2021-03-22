<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="WebApp.Pages.Main" MasterPageFile="~/MainMaster.Master" %>
<%@ Register TagPrefix="custom" TagName="PostTiles" Src="~/Controls/PostTileList.ascx" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Main page</title>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="mainContent">
        <div class="bs-container">
            <h3>Добро пожаловать</h3>
            <p><%= Resources.Language.Description %></p>
        </div>
        <div class="bs-container">
            <div class="bs-row bs-row-4">
                <custom:PostTiles ID="RecentPostTiles" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
