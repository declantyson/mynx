<%@ Page Title="" Language="C#" MasterPageFile="/admin/empty.master" AutoEventWireup="true" CodeFile="upload.aspx.cs" Inherits="Page" ValidateRequest="false" %>
<%@ Register TagPrefix="CuteWebUI" Namespace="CuteWebUI" Assembly="CuteWebUI.AjaxUploader" %>


<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">

	<h3>Upload a file</h3>
	<ul style="font-size:11px;">
        <li>Maximum file size: 2048 KB</li>
        <li>Allowed file types: jpeg, jpg, gif,png </li>
    </ul>
	<form runat="server">
		<CuteWebUI:Uploader id="uploader" InsertText="Upload a file" OnFileUploaded="uploaded" runat="server">
			<ValidateOption AllowedFileExtensions="jpeg,jpg,gif,png" MaxSizeKB="2048" />
		</CuteWebUI:Uploader>
        <asp:Label ID="feedback" runat="server"></asp:Label>
	</form>
</asp:Content>