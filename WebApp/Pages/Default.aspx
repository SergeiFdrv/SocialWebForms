<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Pages.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
	<link rel="stylesheet" href="../Content/Style.css" />
</head>
<body class="home">
    <form id="form" class="content" runat="server">
		<div class="background" style="background: url('../Images/CitiesSkylines_Karlsburg.jpg')"></div>
		<div id="primary" class="content-area">
			<main id="main" class="site-main">
				<div id="core">
					<h1 class="site-title"><%= Resources.Language.SiteName %></h1>
					<p class="site-description" id="desc">
						<i class="fas fa-caret-left" data-toggle="popover" data-placement="top" data-content="Предыдущее сообщение"></i>
						<span id="line"><%= Resources.Language.Description %></span>
						<i id="resume" class="fas fa-pause" data-toggle="popover" data-placement="top" data-content="Продолжить перелистывание"></i>
						<i class="fas fa-caret-right" data-toggle="popover" data-placement="top" data-content="Следующее сообщение"></i>
					</p>
					<% /*footer*/ %>
				</div>
			</main><!-- #main -->
		</div><!-- #primary -->
    </form>
	<script src="../Content/JavaScript.js"></script>
</body>
</html>
