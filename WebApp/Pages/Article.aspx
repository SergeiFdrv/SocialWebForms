<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Article.aspx.cs" Inherits="WebApp.Pages.Article" MasterPageFile="~/MainMaster.Master" %>
<%@ Register TagPrefix="custom" TagName="PostTiles" Src="~/Controls/PostTileList.ascx" %>
<%@ Register TagPrefix="custom" TagName="CommentSection" Src="~/Controls/CommentSection.ascx" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <title><%= Post.PostTitle %></title>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div>
        <div class="bs-container">
            <h6><%= Category.CategoryName %></h6>
            <h1><%= Post.PostTitle %></h1>
        </div>
        <div class="bs-container">
            <div class="postContent">
                <%= Server.HtmlDecode(Post.PostContent) %>
            </div>
        </div>
        <div class="bs-container childrenInlineBlock">
        <% if (Post.PostAuthor != null)
           { %>
            <h4><%= Post.PostAuthor.UserName %></h4>
        <% } %>
            <h4><a href="#">Like</a> <%= Post.PostRP %> <a href="#">Dislike</a></h4>
        </div>
        <div class="bs-container">
            <h3>Comments</h3>
        </div>
        <div class="bs-container">
            <textarea id="commentEditor" name="ckeditor0"></textarea>
            <asp:Button runat="server" Text="<%$ Resources: Language, Submit %>" id="CommentSubmitButton" OnClick="CommentSubmit_Click" />
        </div>
        <% if (PostComments.Any())
            { %>
        <div class="bs-container">
            <custom:CommentSection runat="server" ID="PostCommentSection" />
        </div>
        <% }
           else
           { %>
        <div class="bs-container">
            <p>Be the first to comment</p>
        </div>
        <% } %>
        <% if (UserPosts.Any())
           { %>
        <div class="bs-container">
            <h3>Other posts by <%= Post.PostAuthor.UserName %></h3>
        </div>
        <div class="bs-container">
            <div class="bs-row bs-row-4">
                <custom:PostTiles runat="server" ID="UserPostTiles" />
            </div>
        </div>
        <% } %>
        <% if (CategoryPosts.Any())
           { %>
        <div class="bs-container">
            <h3>Other posts: <%= Category.CategoryName %></h3>
        </div>
        <div class="bs-container">
            <div class="bs-row bs-row-4">
                <custom:PostTiles runat="server" ID="CategoryPostTiles" />
            </div>
        </div>
        <% } %>
    </div>
    <script src="https://cdn.ckeditor.com/4.16.0/basic/ckeditor.js"></script>
    <script>
        CKEDITOR.replace('ckeditor0', { htmlEncodeOutput: true });
    </script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdn.ckeditor.com/4.16.0/standard/styles.js" type="text/javascript"></script>
</asp:Content>
