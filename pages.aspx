<%@ Page Title="" Language="C#" MasterPageFile="themes/mundane/master.master" AutoEventWireup="true" CodeFile="pages.aspx.cs" Inherits="Page" %>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">
	<title><%= pageTitle %></title>

	<h1 class="directory-title"><%= pageTitle %></h1>

	<div class="content-box page-directory">
		<%= data %>
	</div>
</asp:Content>
