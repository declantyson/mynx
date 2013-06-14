<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/empty.master" Inherits="mynx.widgets.uploadBackgroundImage" ValidateRequest="false" Codebehind="upload.aspx.cs" %>
<%@ Register TagPrefix="CuteWebUI" Namespace="CuteWebUI" Assembly="CuteWebUI.AjaxUploader" %>


<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">
    <script>
        function bgUploaded() {
            var uploadedImage = $('iframe#bgImgUploader', parent.document).contents().find('.col-content');
            setTimeout(function () {
                if ($('iframe.refresh', parent.document).length > 0) {
                    parent.location.reload();
                } else {
                    $('#bgCol img', parent.document).remove();
                    $('iframe#bgImgUploader', parent.document).before(uploadedImage);
                }
            }, 1);
        }
    </script>
	<h3>Upload a file</h3>
	<ul style="font-size:11px;">
        <li>Maximum file size: 2048 KB</li>
        <li>Allowed file types: jpeg, jpg, gif,png </li>
    </ul>
	<form id="Form1" runat="server" class="uploader">
        <asp:HiddenField ID="uploadTarget" runat="server" />
		<asp:Label ID="feedback" runat="server"></asp:Label>
        <asp:FileUpload ID="uploadFile" runat="server" />
        <asp:Button ID="uploadButton" runat="server" Text="Upload" 
            onclick="uploaded" />
	</form>
    <p class="newMessage" style="display:none;"><small>Please decide on a slug before uploading a background image.</small></p>
    <script>
        var loc = parent.document.location.pathname;
        if (loc == "/admin/new" || loc == "/admin/new/") {
            $('#Form1').hide();
            $('.newMessage').show();
            $('input[name="slug"]', parent.document).on('change keypress paste textInput input', function () {
                if ($(this).val() == "") {
                    $('#Form1').hide();
                    $('.newMessage').show();
                } else {
                    $('#Form1').show();
                    $('.newMessage').hide();
                    $('#<%= uploadTarget.ClientID %>').val($(this).val());
                }
            });
        } else {
            loc = loc.split('/');
            loc = loc[loc.length - 1];
            $('#<%= uploadTarget.ClientID %>').val(loc);
        }
        
        function UrlExists(url) {
            var http = new XMLHttpRequest();
            http.open('HEAD', url, false);
            http.send();
            return http.status != 404;
        }

        formats = ['.jpg', '.gif', '.png'];
        for (f in formats) {
            url = '/assets/featured-images/' + $('input[name="slug"]', parent.document).val() + formats[f];
            if (UrlExists(url)) {
                $('iframe#bgImgUploader', parent.document).before("<img src='" + url + "'/>");console.log('appending');
            }
        }
    </script>
</asp:Content>