<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="mynx.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login to MYNX</title>
    <link href="http://fonts.googleapis.com/css?family=Lato:300,700,300italic,700italic" rel="stylesheet" type="text/css">
    <link rel="stylesheet" href="/themes/ajaxy/ajaxy.css">
    <link rel="stylesheet" href="/lib/base.css">
    <style type="text/css">
        .content, .toolbar, .sidebar, .footer, .content-box, h1 {
        transition: none;
        -moz-transition: none;
        -webkit-transition: none;
        -o-transition: none;
        }
        label 
        {
            width: 200px;
            display: block;
            float: left;
            clear: both;
        }
    </style>
</head>
<body>
    <div class="main">
        <div class="content no-sidebar">
            <h1 style="padding: 20px 0;text-align:center;">Login to MYNX</h1>
            <div class="content-box col-100">
            <form id="form1" runat="server">
                <div>
                    <p><asp:Literal ID="statusMessage" runat="server"></asp:Literal></p>
                    <label for="mynxUsername">MYNX Admin Username</label> <asp:TextBox ID="mynxUsername" runat="server"></asp:TextBox><br />
                    <label for="mynxPassword">MYNX Admin Password</label> <asp:TextBox ID="mynxPassword" runat="server" TextMode="Password"></asp:TextBox><br />
                    <asp:Button ID="installer" runat="server" Text="Install MYNX" onclick="install_Click" />
                </div>
            </form>
            </div>
        </div>
    </div>
</body>
</html>