<%@ Page Title="" MasterPageFile="/themes/ajaxy/blank.master" Language="C#" AutoEventWireup="true" CodeFile="page.aspx.cs" Inherits="Page" %>


<asp:Content ID="content" ContentPlaceHolderID="ajax_content" Runat="Server">
	<title><%= title %></title>

	<script>
		params = {
			title : $('title').text(),
			bgcolor : '#898989',
			bgimgposhorizontal : 'right',
			bgimgposvertical : 'bottom',
		}
	</script>

	<img src="/assets/featured-images/<%= slug %>.png" class="bg-img"/>

	<%= data %>
</asp:Content>