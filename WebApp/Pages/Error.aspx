<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebApp.Pages.Error" MasterPageFile="~/MainMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <title>Error <%= RouteData.Values["id"]?.ToString() %></title>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="bs-container">
        <h3>Error <%= RouteData.Values["id"]?.ToString() %></h3>
    </div>
</asp:Content>