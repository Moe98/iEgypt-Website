<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CatCreation.aspx.cs" Inherits="CatCreation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class ="sidenav">
        <a href ="UserProfile.aspx"> Home </a>
        <a href ="Default.aspx"> Log out </a>
        <a href ="CatCreation.aspx"> Create Category/Subcategory </a>
        <a href ="CreateContentType.aspx"> Create type </a>
        <a href ="GetExistingRequests.aspx"> Show Existing Requests </a>
        <a href ="WorkingPlaceTypeRequests.aspx"> Weird relation </a>
        <a href ="ShowNotifications.aspx"> Notifications </a>
        <a href ="DeleteComment.aspx"> Delete Comment</a>
        <a href ="DeleteContent.aspx"> Delete Content </a>
        <a href ="BestContributors.aspx"> Show Contributors </a>     
    </div>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" CssClass="labelclass"/>
        <h1>Enter Category</h1>
        <asp:TextBox ID="textBox1" runat="server" CssClass="tb_css" />
        <div>
        <asp:Label ID="Label2" runat="server" CssClass="labelclass"/>
        <h1>Enter Subcategory</h1>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="tb_css"/>
       
        <br />
        <asp:Button class="button" id="button1" runat="server" Text="Create" OnClick="CreateCategory"/>


        
        </div>   
    </form>
</body>
</html>
