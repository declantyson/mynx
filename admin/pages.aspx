<%@ Page Title="" Language="C#" MasterPageFile="/themes/mundane/master.master" AutoEventWireup="true" CodeFile="pages.aspx.cs" Inherits="Page" %>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">
	<title>Page management</title>
	<div class="content-box">
		<h2>Page management<br><span><small>Choose a page to edit.</small></span></h2>
		<p><a href="/admin/new">Add new page +</a></p>
		<table>
			<thead>
				<th>Page title</th>
				<th>Slug</th>
				<th></th>
			</thead>
			<tbody>
				<%= output %>
			</tbody>
		</table>
	</div>
	
</asp:Content>
