<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>
<!DOCTYPE html>
<html>
<head runat="server">
<title>Register</title>
    <link href="Style.css" rel ="Stylesheet" type =" text/css" />
</head>
<body>
     <div class ="sidenav">
        <a href ="AboutUs.aspx"> About </a>
        <a href ="Default.aspx"> Home </a>
    </div>
<form id="form2" runat="server">
 <asp:Label id="display_text2" runat="server" CssClass="labelclass"/>
 <h2>Email</h2>
 <asp:TextBox id="email" runat="server" CssClass="tb_css"/>
 <br>
 <h2>Password</h2>
 <asp:TextBox id="password" runat="server" CssClass="tb_css"/>
 <br>
 <h2>User Type</h2>
<asp:DropDownList ID="user_type" runat="server" CssClass="ddl">
            <asp:ListItem Enabled="true" Text="Select Type" Value="-1"></asp:ListItem>
            <asp:ListItem Text="Viewer" Value="1"></asp:ListItem>
            <asp:ListItem Text="Contributor" Value="2"></asp:ListItem>
            <asp:ListItem Text="Content Manager" Value="3"></asp:ListItem>
            <asp:ListItem Text="Authorized Reviewer" Value="4"></asp:ListItem>
            </asp:DropDownList> <br>
 <h2>First Name</h2>
 <asp:TextBox id="first" runat="server" CssClass="tb_css"/>
 <br>
 <h2>Middle Name</h2>
 <asp:TextBox id="middle" runat="server" CssClass="tb_css"/>
 <br>
 <h2>Last Name</h2>
 <asp:TextBox id="last" runat="server" CssClass="tb_css"/>
 <br>
 <h2>Birth Date</h2>
 <asp:TextBox id="birth" runat="server" CssClass="tb_css"/>
 <br>
 <h2>Working Place Name (Not needed if not of type viewer)</h2>
 <asp:TextBox id="wpName" runat="server" CssClass="tb_css"/>
 <br>
 <h2>Working Place Type (Not needed if not of type viewer)</h2>
 <asp:TextBox id="wpType" runat="server" CssClass="tb_css"/>
 <br>
 <h2>Working Place Description (Not needed if not of type viewer)</h2>
 <asp:TextBox id="wpDesc" runat="server" CssClass="tb_css"/>
 <br>
 <h2>Specialization (Not needed if not of type contributor)</h2>
 <asp:TextBox id="special" runat="server" CssClass="tb_css"/>
 <br>
 <h2>Portfolio Link (Not needed if not of type contributor)</h2>
 <asp:TextBox id="portfolio" runat="server" CssClass="tb_css"/>
 <br>
 <h2>Years of Experience (Not needed if not of type contributor)</h2>
 <asp:TextBox id="XP" runat="server" CssClass="tb_css"/>
 <br>
 <h2>Hire Date (Not needed if not of type staff)</h2>
 <asp:TextBox id="hire" runat="server" CssClass="tb_css"/>
 <br>
 <h2>Working Hours (Not needed if not of type staff)</h2>
 <asp:TextBox id="wHours" runat="server" CssClass="tb_css"/>
 <br>
 <h2>Payment Rate (Not needed if not of type staff)</h2>
 <asp:TextBox id="pRate" runat="server" CssClass="tb_css"/>
 <br>
 <br>
 <asp:Button id="button3" runat="server" Text="Done" OnClick="regMethod" class="button"/>
</form>
</body></html>