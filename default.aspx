<%@ Page Title="" Language="C#" MasterPageFile="themes/mundane/master.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="xampp_Default" %>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">
 	<title><%= title %></title>
 	<h1><%= title %></h1>
 	<%= data %>
</asp:Content>
