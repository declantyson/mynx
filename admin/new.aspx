<%@ Page Title="" Language="C#" MasterPageFile="/themes/mundane/master.master" AutoEventWireup="true" CodeFile="new.aspx.cs" Inherits="Page" ValidateRequest="false" %>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">

	<title>New page</title>

	<form id="pageForm" class="edit" style="padding: 1%" method="post" runat="server">
		<h3>New page</h3>
		<asp:Label ID="error" runat="server"></asp:Label>
		<div>
			<label for="title" style="width:100px;display:inline-block">Title</label>
			<input name="title" type="text"/>
			<div style="clear:both;"></div>

			<label for="slug" style="width:100px;display:inline-block">Slug</label>
			<input name="slug" type="text" />
			<div style="clear:both;"></div>
			
			<input id="text" type="hidden" name="text" />

        	<asp:Button id="update_blog" runat="Server" Text="Update" OnClientClick="return rasterizeContent();" onClick="update_page"/>
		</div>
	</form>

	<div class="clearfix"></div>

	<div class="widget-col col-33 new-col main-widget-editor">
		<p class="new-content-box">Add content box</p>
		<p class="new-html">Add raw HTML column</p>
	</div>
	<div class="clearfix"></div>

	<div class="editable-content">

		<%= text %>

	</div>

</asp:Content>