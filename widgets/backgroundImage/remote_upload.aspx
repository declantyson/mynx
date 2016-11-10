<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/empty.master" Inherits="mynx.widgets.uploadBackgroundImage" ValidateRequest="false" Codebehind="upload.aspx.cs" %>
<%@ Register TagPrefix="CuteWebUI" Namespace="CuteWebUI" Assembly="CuteWebUI.AjaxUploader" %>


<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">
    <script>
		function getParameterByName(name, url) {
		    if (!url) url = window.location.href;
		    name = name.replace(/[\[\]]/g, "\\$&");
		    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
		        results = regex.exec(url);
		    if (!results) return null;
		    if (!results[2]) return '';
		    return decodeURIComponent(results[2].replace(/\+/g, " "));
		}
		
        function bgUploaded() {
			var $img = $('<img/>');
			$img.attr('src', '/assets/background-images/' + getParameterByName('slug') + '.png').css({ width: '100%' });
	    	$('#Form1').replaceWith($img);
        }
    </script>
	<form id="Form1" runat="server" class="uploader">
		<h3 style="margin: 0;">Upload a file</h3>
		<p style="margin-top: 0"><small>PNG only supported currently.</small></p>
        <asp:HiddenField ID="uploadTarget" runat="server" />
		<asp:Label ID="feedback" runat="server"></asp:Label>
        <asp:FileUpload ID="uploadFile" runat="server" />
        <asp:Button ID="uploadButton" runat="server" Text="Upload" 
            onclick="uploaded" />
	</form>
    <p class="newMessage" style="display:none;color: #000000;"><small>Please decide on a slug before uploading a background image.</small></p>
    <script>
		
        if (getParameterByName("slug") === null || getParameterByName === "") {
            $('#Form1').hide();
            $('.newMessage').show();
        } else {
            $('#<%= uploadTarget.ClientID %>').val(getParameterByName("slug"));
        }
    </script>
</asp:Content>