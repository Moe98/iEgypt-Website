<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewerPart8.aspx.cs" Inherits="ViewerPart8" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="Style.css" rel ="Stylesheet" type =" text/css" />

</head>
<body>
    <div class ="sidenav">
        <a href ="UserProfile.aspx"> Home </a>
        <a href ="Default.aspx"> Log out </a>
        <a href ="ViewerPart1.aspx"> Create Event </a>
        <a href ="ViewierPart2.aspx"> Apply for Existing Request </a>
        <a href ="ViewerPart3.aspx"> Apply for New Request </a>
        <a href ="ViewerPart4.aspx"> Delete Request </a>
        <a href ="ViewerPart5.aspx"> Review Original Content </a>
        <a href ="ViewerPart6.aspx"> Add Comment </a>
        <a href ="ViewerPart7-1.aspx"> Edit Comment </a>
        <a href ="ViewerPart7-2.aspx"> Delete Comment </a>
        <a href ="ViewerPart8.aspx"> Create Ad </a>
        <a href ="ViewerPart9-1.aspx"> Edit Ad </a>
        <a href ="ViewerPart9-2.aspx"> Delete Ad </a>
        <a href ="ViewerPart10.aspx"> Show New Content </a>
      
    </div>
    <form id="form1" runat="server">
        <asp:Label ID="testing" runat="server" CssClass="labelclass"/>
        <h1>Description</h1>
        <asp:TextBox ID="description" runat="server" CssClass="tb_css"/>
        <br>
        <h1>Location</h1>
        <asp:TextBox  ID="location" runat="server" CssClass="tb_css"/>
        <br>
        <br>
        <asp:Button id="button1" runat="server" Text="Create!" OnClick="createads" class="button"/>
    </form>
</body>
</html>
