<%@ Page Title="" Language="C#" MasterPageFile="/admin/empty.master" AutoEventWireup="true" CodeFile="imagelibrary_min.aspx.cs" Inherits="Page" ValidateRequest="false" %>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">
	<title>Image library</title>
	<h3>Image library</h3>
	<div class="image-library">
		<%= output %>
	</div>
	<div class="clearfix"></div>
	<style>
		body {
			overflow-y: auto;
		}
	</style>
</asp:Content>