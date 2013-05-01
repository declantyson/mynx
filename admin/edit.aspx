<%@ Page Title="" Language="C#" MasterPageFile="/themes/mundane/master.master" AutoEventWireup="true" CodeFile="edit.aspx.cs" Inherits="Page" ValidateRequest="false" %>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">

	<title>Edit "<%= pageTitle %>"</title>

	<form id="pageForm" class="edit" style="padding: 1%" method="post" runat="server">
		<h3>Edit "<%= pageTitle %>"</h3>
		<div>
			<label for="title" style="width:100px;display:inline-block">Title</label>
			<input name="title" type="text" value="<%= pageTitle %>"/>
			<div style="clear:both;"></div>

			<label for="slug" style="width:100px;display:inline-block">Slug</label>
			<input name="slug" type="text" value="<%= slug %>"/>
			<div style="clear:both;"></div>

			<label for="cat" style="width:100px;display:inline-block">Category</label>
			<label class="select-label"></label>
			<select name="cat_drop">
				<option value="new">Add new category</option>
				<%= catOptions %>
			</select>
			<input name="cat_text" type="text" class="category-input"/>
			<div style="clear:both;"></div>
			
			<input type="hidden" name="id" value="<%= id %>" />
			<input id="text" type="hidden" name="text" value="<%= text %>" />

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

	<div class="widget-col col-33 new-col main-widget-editor">
		<p class="new-content-box">Add content box</p>
		<p class="new-html">Add raw HTML column</p>
	</div>

</asp:Content>