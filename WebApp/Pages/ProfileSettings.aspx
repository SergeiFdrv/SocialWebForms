<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfileSettings.aspx.cs" Inherits="WebApp.Pages.ProfileSettings" MasterPageFile="~/Pages/ProfileMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <title><%= CurrentUser.UserName %>'s profile settings</title>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ProfileContent">
    <table>
        <tr>
            <td colspan="2">
                <h4>Change nickname</h4>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server">Name</asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="Nickname" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <h4>Change password</h4>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server">Old password</asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="PasswordOld" Rows="1" />
            </td>
            <td>
                <asp:CustomValidator runat="server" ControlToValidate="PasswordOld"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server">New password</asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="PasswordNew" Rows="1" />
            </td>
            <td>
                <asp:CustomValidator runat="server" ControlToValidate="PasswordNew"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server">New password again</asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="PasswordNewAgain" Rows="1" />
            </td>
            <td>
                <asp:CustomValidator runat="server" ControlToValidate="PasswordNewAgain"></asp:CustomValidator>
            </td>
        </tr>
    </table>
</asp:Content>