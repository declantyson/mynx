<%@ Page Title="" Language="C#" MasterPageFile="themes/mundane/master.master" AutoEventWireup="true" CodeFile="pages.aspx.cs" Inherits="Page" %>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">
	<title><%= pageTitle %></title>

	<script>
		params = {
			title : $('title').text(),
			bgcolor : '#898989',
			bgimgposhorizontal : 'right',
			bgimgposvertical : 'bottom',
		}
	</script>


	<div class="content-box page-directory">
		<%= data %>
	</div>
</asp:Content>
