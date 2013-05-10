<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/empty.master" Inherits="mynx.admin.imagelibrary_min" ValidateRequest="false" Codebehind="imagelibrary_min.aspx.cs" %>

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