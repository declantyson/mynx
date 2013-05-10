<%@ Page Title="" Language="C#" MasterPageFile="themes/mundane/master.master" AutoEventWireup="true" Inherits="mynx._default" Codebehind="default.aspx.cs" %>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">
 	<title><%= title %></title>
 	<h1><%= title %></h1>
    <asp:Panel ID="dataPanel" runat="server">
    </asp:Panel>
</asp:Content>
