<%@ Page Title="" Language="C#" MasterPageFile="~/themes/mundane/master.master" AutoEventWireup="true" Inherits="mynx.admin._new" ValidateRequest="false" Codebehind="new.aspx.cs" %>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">

	<title>New page</title>

	<form id="pageForm" class="edit" style="padding: 1%" method="post" runat="server">
		<asp:Label ID="error" runat="server"></asp:Label>
		<div>
			<input name="title" type="hidden" id="title-input"/>
			<input name="slug" type="hidden" id="slug"/>
			<input name="keys" type="hidden" id="keys"/>
			<div class="category-select">
				<label class="select-label"></label>
				<select name="cat_drop">
					<option>Select category</option>
					<option value="new">New category</option>
					<%= catOptions %>
				</select>
				<input name="cat_text" type="text" class="category-input" placeholder="New category name"/>
				<p class="show-page-options"><small>Show more options</small><img src="/assets/cms/show-more.png" /></p>
				<div class="clear"></div>
	            <div class="page-options">
					<input name="desc" type="text" placeholder="Description"/>
	            </div>
			</div>
			<input id="text" type="hidden" name="text" />
			<div class="update-button">
	        	<asp:Button id="update_blog" runat="Server" Text="Update" OnClientClick="return rasterizeContent();" onClick="update_page"/>
			</div>
		</div>
	</form>

	<div class="clearfix"></div>

	<div class="widget-col col-33 new-col main-widget-editor template">
        <select>
		    <!--<option value="new-content-box">Add content box</option>-->
		    <option value="new-html">Add rich text column</option>
        </select>
        <input type="button" class="button add-widget-button" value="Add" />
	</div>
	<div class="clearfix"></div>

	<div class="editable-content">
		<div class="content-box">
			<%= text %>
		</div>
	</div>

	<style>
		.cms-header input {
			display: inline-block;
		}
	</style>
	<script>
		preRasterize.slug = function() {
			var title = $('.cms-header input').val();
			$('#title-input').val(title);
		};
	</script>

</asp:Content>