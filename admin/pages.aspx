<%@ Page Title="" Language="C#" MasterPageFile="~/themes/mundane/master.master" AutoEventWireup="true" Inherits="mynx.admin.pages" Codebehind="pages.aspx.cs" %>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">
	<title>Page management</title>
	<div class="content-box">
		<h2>Page management<br><span><small>Choose a page to edit.</small></span></h2>
		<p><a href="/admin/new">Add new page +</a></p>
		<table>
			<thead>
				<th>Page title</th>
				<th>Slug</th>
                <th>Date</th>
				<th></th>
			</thead>
			<tbody>
				<%= output %>
			</tbody>
		</table>
	</div>
	
</asp:Content>
