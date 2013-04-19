<%@ Page Title="" Language="C#" MasterPageFile="/themes/mundane/master.master" AutoEventWireup="true" CodeFile="imagelibrary.aspx.cs" Inherits="Page" %>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">
	<title>Image library</title>
	<div class="content-box">
		<h2>Image library<br><span><small>Manage your images.</small></span></h2>
		<div class="image-library">
			<%= output %>
		</div>
		<div class="clearfix"></div>
	</div>
	
</asp:Content>