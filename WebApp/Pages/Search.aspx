<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="WebApp.Pages.Search" MasterPageFile="~/MainMaster.Master" %>
<%@ Register TagPrefix="custom" TagName="PostTiles" Src="~/Controls/PostTileList.ascx" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <title><%= Resources.Language.Search %></title>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div>
        <div>
            <h3><%= Resources.Language.Search %></h3>
        </div>
        <div style="display: flex;">
            <asp:TextBox runat="server" ID="SearchBoxInput" />
            <asp:Button runat="server" ID="SearchSubmit" OnClick="SearchSubmit_Click" Text="Submit" />
        </div>
        <div class="bs-container">
            <% if (RelevantPosts.Posts != null)
                {%>
            <custom:PostTiles runat="server" ID="RelevantPosts" />
            <% }
               else if (IsPostBack)
               { %>
            <h3 class="marginAuto">No result</h3>
            <% } %>
        </div>
    </div>
</asp:Content>