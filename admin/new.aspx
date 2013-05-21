<%@ Page Title="" Language="C#" MasterPageFile="~/themes/mundane/master.master" AutoEventWireup="true" Inherits="mynx.admin._new" ValidateRequest="false" Codebehind="new.aspx.cs" %>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">

	<title>New page</title>

	<form id="pageForm" class="edit" style="padding: 1%" method="post" runat="server">
		<h3>New page</h3>
		<asp:Label ID="error" runat="server"></asp:Label>
		<div>
			<label for="title" style="width:100px;display:inline-block">Title</label>
			<input name="title" type="text"/>
			<div class="clear"></div>

			<label for="slug" style="width:100px;display:inline-block">Slug</label>
			<input name="slug" type="text" />
			<div class="clear"></div>			

			<label for="cat" style="width:100px;display:inline-block">Category</label>
			<label class="select-label"></label>
			<select name="cat_drop">
				<option value="new">Add new category</option>
				<%= catOptions %>
			</select>
			<input name="cat_text" type="text" class="category-input"/>
			<div class="clear"></div>
			
			<input id="text" type="hidden" name="text" />

        	<asp:Button id="update_blog" runat="Server" Text="Update" OnClientClick="return rasterizeContent();" onClick="update_page"/>
		</div>
	</form>

	<div class="clearfix"></div>

	<div class="widget-col col-33 new-col main-widget-editor">
        <select>
		    <option value="new-content-box">Add content box</option>
		    <option value="new-html">Add raw HTML column</option>
        </select>
        <input type="button" class="button add-widget-button" value="Add" />
	</div>
	<div class="clearfix"></div>

	<div class="editable-content">

		<%= text %>

	</div>

</asp:Content>