<%@ Page Title="" Language="C#" MasterPageFile="/admin/empty.master" AutoEventWireup="true" CodeFile="upload.aspx.cs" Inherits="Page" ValidateRequest="false" %>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">

	<h3>Upload a file</h3>
	<form runat="server">
		<asp:FileUpload ID="the_file" runat="server" /><br/>
		<asp:Button ID="upload_file" runat="server" OnClick="upload_it" 
         Text="Upload File" />
        <asp:Label ID="feedback" runat="server"></asp:Label>
	</form>
</asp:Content>