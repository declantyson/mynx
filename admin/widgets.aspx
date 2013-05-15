<%@ Page Title="" Language="C#" MasterPageFile="~/themes/mundane/master.master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="widgets.aspx.cs" Inherits="mynx.admin.widgets" %>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">
    <title>Install and manage widgets</title>
    <form id="widgets_form" runat="server" class="settings_form">
        <div class="content-box">
            <h2>Widgets<br>
                <small><span>There are currently <%= installedWidgetCount %> widgets installed.</span></small>
            </h2>
            <label for="installedwidgetlist">Installed widgets:</label><label class='select-label'></label>
            <asp:DropDownList name="installedwidgetlist" id="installedwidgetlist" runat="server">
	        </asp:DropDownList>
           <asp:Button id="reinstall_widget" OnClick="reinstall_widget_Click" text="Re-install this widget" runat="server"/>
        </div>
	    <label for="widgetlist">Install new widget</label>
	    <label class="select-label"></label>
	    <asp:DropDownList name="widgetlist" id="widgetlist" runat="server">
	    </asp:DropDownList>
        <asp:Button id="install_widget" OnClick="install_widget_Click" text="Install this widget" runat="server"/>
        <asp:Panel ID="widgetinstallpanel" class="widgetinstallpanel" runat="server"></asp:Panel>
    </form>
</asp:Content>