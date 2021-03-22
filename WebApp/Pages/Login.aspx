<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp.Pages.Login" MasterPageFile="~/MainMaster.Master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Login page</title>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="marginAuto">
        <div>
            <h3><%= Resources.Language.Welcome %></h3>
        </div>
        <div>
            <table runat="server">
                <tr>
                    <td>
                        <label runat="server"><%= Resources.Language.AccountLogin %></label>
                    </td>
                    <td>
                        <input runat="server" type="text" id="userlogin"/>
                    </td>
                    <td>
                        <ASP:RequiredFieldValidator ControlToValidate="userlogin" Display="Static" ErrorMessage="*" runat="server" 
                            ID="vuserlogin" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label runat="server"><%= Resources.Language.AccountPassword %></label>
                    </td>
                    <td>
                        <input runat="server" type="password" id="userpassword" />
                    </td>
                    <td>
                        <ASP:RequiredFieldValidator ControlToValidate="userpassword" Display="Static" ErrorMessage="*" runat="server" 
                            ID="vuserpassword" />
                    </td>
                </tr>
                <tr>
                    <td><%= Resources.Language.StayLoggedIn %></td>
                    <td>
                        <ASP:CheckBox id="chkPersistCookie" runat="server" autopostback="false" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <a runat="server" href="#"><%= Resources.Language.ForgotAccount %></a>
                    </td>
                    <td>
                        <asp:Button runat="server" Text="<%$ Resources: Language, Submit %>" id="LoginButton" OnClick="LoginButton_Click" />
                        <a href="/register"><%= Resources.Language.Register %></a>
                    </td>
                </tr>
            </table>
        </div>
        <div class="textAlignCenter">
            <label runat="server" id="ErrorMessage"></label>
            <p><%= Resources.Language.LoginDescription %></p>
        </div>
    </div>
</asp:Content>