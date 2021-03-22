<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostEditor.aspx.cs" Inherits="WebApp.Pages.PostEditor" MasterPageFile="~/Pages/ProfileMaster.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <title><%= CurrentUser.UserName %>'s post editor</title>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ProfileContent">
    <table>
        <tr>
            <td colspan="2">
                <h4><%= Resources.Language.PostEditor %></h4>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server"><%= Resources.Language.Title %></asp:Label>
                <ASP:RequiredFieldValidator ControlToValidate="PostTitle" Display="Static" ErrorMessage="*" runat="server" 
                    ID="vPostTitle" />
            </td>
            <td>
                <input runat="server" type="text" ID="PostTitle" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server"><%= Resources.Language.Category %></asp:Label>
            </td>
            <td>
                <select name="categoryList">
                    <% foreach (var c in Categories)
                       { %>
                    <option value="<%= c.CategoryID %>"
                        <% if (CurrentPost?.PostCategoryID == c.CategoryID)
                           { %> selected <% } %>
                        ><%= c.CategoryName %></option>
                    <% } %>
                </select>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <textarea name="ckeditor" id="editor"><%= Server.HtmlDecode(CurrentPost?.PostContent) %></textarea>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button runat="server" Text="<%$ Resources: Language, Submit %>" id="SubmitButton" OnClick="Submit_Click" />
                <% if (CurrentPost != null)
                   { %>
                <input type="button" value="<%= Resources.Language.Delete %>" id="DeleteButton" onclick="document.getElementById('deletePostDialog').style.display = 'flex'" />
                <% } %>
            </td>
        </tr>
    </table>
    <div id="deletePostDialog" class="screenCover" style="display: none;">
        <div class="bs-container darkBackground popup marginAuto" style="background: #000e; border-radius: 3px;">
            <div class="bs-row">
                <p>Delete this post permanently?</p>
            </div>
            <div class="answerOptions">
                <asp:LinkButton runat="server" CssClass="entryLink" ID="DeleteYes" OnClick="DeleteYes_Click">
                    <%= Resources.Language.Yes %>
                </asp:LinkButton>
                <a href="#" class="entryLink" onclick="document.getElementById('deletePostDialog').style.display = 'none'">
                    <%= Resources.Language.No %>
                </a>
            </div>
        </div>
    </div>
    <script src="https://cdn.ckeditor.com/4.16.0/standard/ckeditor.js"></script>
    <script>
        CKEDITOR.replace('editor', { htmlEncodeOutput: true });
    </script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdn.ckeditor.com/4.16.0/standard/styles.js" type="text/javascript"></script>
</asp:Content>