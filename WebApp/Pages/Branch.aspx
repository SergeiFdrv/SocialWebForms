<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Branch.aspx.cs" Inherits="WebApp.Pages.Branch" MasterPageFile="~/MainMaster.Master" %>
<%@ Register TagPrefix="custom" TagName="PostTiles" Src="~/Controls/PostTileList.ascx" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Branch page</title>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <h3><%= MainCategory.CategoryName %></h3>
            <p><%= MainCategory.CategoryDescription %></p>
        </div>
        <div>
            <div class="bs-container">
                <div class="bs-row bs-row-4">
                    <custom:PostTiles runat="server" ID="RecentPostTiles" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>