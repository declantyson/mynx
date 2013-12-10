<%@ Page Title="" Language="C#" MasterPageFile="~/themes/mundane/master.master" AutoEventWireup="true" Inherits="mynx.admin.edit" ValidateRequest="false" Codebehind="edit.aspx.cs" %>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">

	<title>Edit "<%= pageTitle %>"</title>

    <p><i>Last updated: <%= date_updated %></i></p>

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
			<div class="clear"></div>

            <label for="desc" style="width:100px;display:inline-block">META Description</label>
			<input name="desc" type="text" value="<%= desc %>"/>
			<div style="clear:both;"></div>

            <label for="keys" style="width:100px;display:inline-block">META Keywords</label>
			<input name="keys" type="text" value="<%= keys %>"/>
			<div style="clear:both;"></div>
			
			<input type="hidden" name="id" value="<%= id %>" />
			<input id="text" type="hidden" name="text" value="<%= text %>" />

            <p class="show-page-options"><small>Show more options</small><img src="/assets/cms/show-more.png" /></p>
            <div class="page-options">
                <hr />
            </div>
            <div class="clear"></div>
        	<asp:Button id="update_blog" runat="Server" Text="Update" OnClientClick="return rasterizeContent();" onClick="update_page"/>
		</div>
	</form>

	<div class="clearfix"></div>

	<div class="widget-col col-33 new-col main-widget-editor">
        <select>
		    <option value="new-content-box">Add content box</option>
		    <option value="new-html">Add rich text column</option>
        </select>
        <input type="button" class="button add-widget-button" value="Add" />
	</div>
	<div class="clearfix"></div>

	<div class="editable-content">

		<%= text %>

	</div>

</asp:Content>