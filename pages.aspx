<%@ Page Language="C#" MasterPageFile="themes/mundane/master.master" AutoEventWireup="true" Inherits="mynx.pages" Codebehind="pages.aspx.cs" %>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">
	<title><%= pageTitle %></title>

	<h1 class="directory-title"><%= pageTitle %></h1>

	<div class="content-box page-directory">
		<%= data %>
	</div>
</asp:Content>
