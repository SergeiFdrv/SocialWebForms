<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApp.Pages.Register" MasterPageFile="~/MainMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <title><%= Resources.Language.Register %></title>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table runat="server">
        <thead>
            <tr>
                <td>
                    <h3><%= Resources.Language.Register %></h3>
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    <label runat="server"><%= Resources.Language.AccountLogin %></label>
                </td>
                <td>
                    <input runat="server" type="text" ID="userlogin" />
                </td>
                <td>
                    <ASP:RequiredFieldValidator ControlToValidate="userlogin" Display="Static" ErrorMessage="*" runat="server" 
                        ID="vuserlogin" />
                </td>
            </tr>
            <tr>
                <td>
                    <label runat="server"><%= Resources.Language.UserName %></label>
                </td>
                <td>
                    <input runat="server" type="text" ID="username" />
                </td>
                <td>
                    <ASP:RequiredFieldValidator ControlToValidate="username" Display="Static" ErrorMessage="*" runat="server" 
                        ID="vusername" />
                </td>
            </tr>
            <tr>
                <td>
                    <label runat="server"><%= Resources.Language.AccountPassword %></label>
                </td>
                <td id="passwordTD">
                    <input runat="server" type="password" ID="userpassword" />
                </td>
                <td>
                    <ASP:RequiredFieldValidator ControlToValidate="userpassword" Display="Static" ErrorMessage="*" runat="server" 
                        ID="vuserpassword" />
                </td>
            </tr>
            <tr>
                <td>
                    <label runat="server"><%= Resources.Language.RepeatPassword %></label>
                </td>
                <td id="passwordconfirmTD">
                    <input runat="server" type="password" ID="userpasswordconfirm" />
                </td>
                <td>
                    <ASP:RequiredFieldValidator ControlToValidate="userpasswordconfirm" Display="Static" ErrorMessage="*" runat="server" 
                        ID="vuserpasswordconfirm" />
                    <asp:CompareValidator ID="vuserpasswordcompare" runat="server" 
                                          ControlToValidate="userpasswordconfirm"
                                          CssClass="ValidationError"
                                          ControlToCompare="userpassword"
                                          ErrorMessage="No Match" 
                                          ToolTip="Password must be the same" />

                </td>
            </tr>
            <tr>
                <td>
                    <label runat="server">Email</label>
                </td>
                <td>
                    <input runat="server" type="text" ID="useremail" />
                </td>
                <td>
                    <ASP:RequiredFieldValidator ControlToValidate="useremail" Display="Static" ErrorMessage="*" runat="server" 
                        ID="vuseremail" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="server" ID="SubmitButton" OnClick="Submit_Click" Text="<%$ Resources: Language, Submit %>" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
