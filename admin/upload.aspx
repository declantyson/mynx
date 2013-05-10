<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/empty.master" Inherits="mynx.admin.upload" ValidateRequest="false" Codebehind="upload.aspx.cs" %>
<%@ Register TagPrefix="CuteWebUI" Namespace="CuteWebUI" Assembly="CuteWebUI.AjaxUploader" %>


<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">

	<h3>Upload a file</h3>
	<ul style="font-size:11px;">
        <li>Maximum file size: 2048 KB</li>
        <li>Allowed file types: jpeg, jpg, gif,png </li>
    </ul>
	<form id="Form1" runat="server" class="uploader">
		<asp:Label ID="feedback" runat="server"></asp:Label>
		<CuteWebUI:Uploader id="uploader" InsertText="Upload a file" OnFileUploaded="uploaded" runat="server">
			<ValidateOption AllowedFileExtensions="jpeg,jpg,gif,png" MaxSizeKB="2048" />
		</CuteWebUI:Uploader>
	</form>
</asp:Content>