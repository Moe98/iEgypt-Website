<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
 <title></title>
    <link href="Style.css" rel ="Stylesheet" type =" text/css" />
</head>
<body>
    <div class ="sidenav">
        <a href ="AboutUs.aspx"> About </a>
    </div>
 <form id="Login" runat="server">
 <h1>Welcome to iEgypt</h1>
 <asp:Label id="display_text" runat="server" CssClass="labelclass"/>
 <h2>Email</h2>
 <asp:TextBox id="email" runat="server" CssClass="tb_css"/>
 <br>
 <h2>Password</h2>
 <asp:TextBox id="password" runat="server" CssClass="tb_css"/>
 <br>
 <br>
 <asp:Button id="button" runat="server" Text="Login" OnClick="loginmethod" class="button"/>
 <br>
 <br>
 <asp:Button id="button2" runat="server" Text="Register" OnClick="regRedirect" class="button"/>
 </form>
</body>
</html>