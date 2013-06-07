<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="install.aspx.cs" Inherits="mynx.install" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Install MYNX</title>
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
            <h1 style="padding: 20px 0;text-align:center;">Install MYNX</h1>
            <div class="content-box col-100">
            <form id="form1" runat="server">
            <div>
                <label for="ipAddress">IP/Web Address</label> <asp:TextBox ID="ipAddress" runat="server" Text="localhost"></asp:TextBox><br />
                <label for="serverType">Server Type</label> <asp:DropDownList ID="serverType" runat="server">
                    <asp:ListItem Value="">Non-Express SQL Server</asp:ListItem>
                    <asp:ListItem Value="\SQLEXPRESS">SQL Server Express</asp:ListItem>
                    <asp:ListItem Value="\SQLEXPRESSR2">SQL Server Express R2</asp:ListItem>
                </asp:DropDownList><br />
                <label for="databaseName">Database Name</label> <asp:TextBox ID="databaseName" runat="server"></asp:TextBox><br />
                <label for="databaseUsername">Database Username</label> <asp:TextBox ID="databaseUsername" runat="server"></asp:TextBox><br />
                <label for="databasePassword">Database Password</label> <asp:TextBox ID="databasePassword" TextMode="Password" runat="server"></asp:TextBox><br />
                <label for="mynxUsername">MYNX Admin Username</label> <asp:TextBox ID="mynxUsername" runat="server"></asp:TextBox><br />
                <label for="mynxPassword">MYNX Admin Password</label> <asp:TextBox ID="mynxPassword" runat="server"></asp:TextBox><br />
                <asp:Button ID="installer" runat="server" Text="Install MYNX" onclick="install_Click" />
                </div>
            </div>
            </form>
        </div>
    </div>
</body>
</html>
