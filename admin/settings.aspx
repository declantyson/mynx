<%@ Page Title="" Language="C#" MasterPageFile="~/themes/mundane/master.master" AutoEventWireup="true" Inherits="mynx.admin.settings" Codebehind="settings.aspx.cs" %>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">
	<title>Website settings</title>
	
	<form id="settings_form" runat="server" class="settings_form">

		<div class="content-box">
			<h2>Themes<br><span><small>There are currently <%= themecount %> themes installed.</small></span></h2>
			<label for="themes">Change theme</label>
			<label class="select-label"></label>
			<asp:DropDownList name="themes" id="themes" runat="server">
			</asp:DropDownList>
			<asp:Button id="change_theme" OnClick="change_theme_Click" text="Choose this theme" runat="server"/>
		</div>

		<div class="content-box block-settings">
			<h2>Blocks<br><small><span>Content you want to appear on every page.</span></small></h2>

			<h3>Sidebar</h3>
			<div class="block-sidebar">
				<asp:CheckBox id="block_sidebar" runat="server"/> <label for="block_sidebar">Enable this block</label>
			</div>
			<asp:Textbox id="sidebar_code" runat="server" class="sidebar-code" Textmode="Multiline" />

			<h3>Toolbar</h3>
			<div class="block-toolbar">
				<asp:CheckBox id="block_toolbar" runat="server"/> <label for="block_toolbar">Enable this block</label>
			</div>
			<asp:Textbox id="toolbar_code" runat="server" class="toolbar-code" Textmode="Multiline" />

			<h3>Footer</h3>
			<div class="block-footer">
				<asp:CheckBox id="block_footer" runat="server"/> <label for="block_footer">Enable this block</label>
			</div>
			<asp:Textbox id="footer_code" runat="server" class="footer-code" Textmode="Multiline" />

			<asp:Button id="update_blocks" OnClick="update_blocks_Click" text="Update block settings" runat="server"/>
		</div>
	</form>
</asp:Content>
