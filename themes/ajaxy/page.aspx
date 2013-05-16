<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/themes/ajaxy/blank.master" Inherits="mynx.themes.ajaxy.page" Codebehind="page.aspx.cs" %>

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

	<asp:Panel ID="dataPanel" runat="server">
    </asp:Panel>
</asp:Content>