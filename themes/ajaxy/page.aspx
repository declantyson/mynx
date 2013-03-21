<%@ Page Title="" MasterPageFile="/themes/ajaxy/blank.master" Language="C#" AutoEventWireup="true" CodeFile="page.aspx.cs" Inherits="xampp_Default" %>


<asp:Content ID="content" ContentPlaceHolderID="ajax_content" Runat="Server">
	<script>
		params = {
			bgcolor : '#898989',
			bgimgposhorizontal : 'right',
			bgimgposvertical : 'bottom',
		}
	</script>

	<img src="/assets/featured-images/<%= slug %>.png" class="bg-img"/>

	<div class="main">
		<h1><%= title %></h1>
		<%= data %>
	</div>
</asp:Content>