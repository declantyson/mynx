<%@ Page Title="" Language="C#" MasterPageFile="/themes/mundane/master.master" AutoEventWireup="true" CodeFile="settings.aspx.cs" Inherits="Page" %>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">
	<title>Website settings</title>

	<div class="content-box">
		<h2>Themes<br><span><small>There are currently <%= themecount %> themes installed.</small></span></h2>
		<form id="choose_theme" runat="server">
			<label for="themes">Change theme</label>
			<label class="select-label"></label>
			<asp:DropDownList name="themes" id="themes" runat="server">
			</asp:DropDownList>
			<asp:Button id="change_theme" OnClick="change_theme_Click" text="Choose this theme" runat="server"/>
		</form>
	</div>

	<div class="content-box">

	</div>
	
</asp:Content>
