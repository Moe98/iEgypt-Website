<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Edit" %>
<!DOCTYPE html>
<html>
<head runat="server">
 <title>Profile</title>
    <link href="Style.css" rel ="Stylesheet" type =" text/css" />
</head>
<body>
     <div class ="sidenav">
        <a href ="UserProfile.aspx"> Home </a>
        <a href ="Default.aspx"> Log out </a>
    </div>
 <form id="form3" runat="server">
 <asp:Label id="display_text2" runat="server" CssClass="labelclass"/>
 <h2>Email</h2>
 <asp:TextBox id="email" runat="server" CssClass="tb_css"/>
 <br`>
 <h2>Password</h2>
 <asp:TextBox id="password" runat="server" CssClass="tb_css"/>
 <br>
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
 <% if (getUserType()=="Viewer") {%>
 <h2>Working Place Name </h2>
 <asp:TextBox id="wpName" runat="server" CssClass="tb_css"/>
 <br>
 <h2>Working Place Type </h2>
 <asp:TextBox id="wpType" runat="server" CssClass="tb_css"/>
 <br>
 <h2>Working Place Description </h2>
 <asp:TextBox id="wpDesc" runat="server" CssClass="tb_css"/>
 <br>
 <%}%>
 <% if (getUserType()=="Contributor") {%>
 <h2>Specialization </h2>
 <asp:TextBox id="special" runat="server" CssClass="tb_css"/>
 <br>
 <h2>Portfolio Link</h2>
 <asp:TextBox id="portfolio" runat="server" CssClass="tb_css"/>
 <br>
 <h2>Years of Experience </h2>
 <asp:TextBox id="XP" runat="server" CssClass="tb_css"/>
 <br>
 <%}%>
 <% if (getUserType()=="Authorized Reviewer" || getUserType()=="Content Manager") {%>
 <h2>Hire Date </h2>
 <asp:TextBox id="hire" runat="server" CssClass="tb_css"/>
 <br>
 <h2>Working Hours</h2>
 <asp:TextBox id="wHours" runat="server" CssClass="tb_css"/>
 <br>
 <h2>Payment Rate</h2>
 <asp:TextBox id="pRate" runat="server" CssClass="tb_css"/>
 <br>
 <%}%>
 <br>
 <asp:Button id="button3" runat="server" Text="Done" OnClick="editMethod"  class="button"/>
 </form>
</body>
</html>