<%@ Page Language="C#" MasterPageFile="~/themes/mundane/master.master" AutoEventWireup="true" Inherits="mynx.admin.image" Codebehind="image.aspx.cs" %>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">
    <div class="content-box">
        <div class="col col-50">
            <img src="<%= filePath %>" alt="<%= alt %>" />
        </div>
        <div class="col col-50">
            <form runat="server" method="post" action="#">
                <h3>Filepath</h3><p><%= filePath %></p>
                <h3>Album</h3><input name="album" type="text" value="<%= album %>"/>
                <h3>Alt text</h3><input name="alt" type="text" value="<%= alt %>"/>
                <br />
                <asp:HiddenField ID="id" runat="server" />
                <asp:Button ID="updateImage" runat="server" Text="Update image" onclick="update_image" />
            </form>
        </div>
        <div class="clearfix"></div>
    </div>
</asp:Content>