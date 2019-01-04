<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AcceptFiltered.aspx.cs" Inherits="AcceptFiltered" %>

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
        <asp:Label ID="Filtering" runat="server" CssClass="labelclass"/>
        <h1>Filter Original Content</h1>
        <div>
        <asp:TextBox ID="original_content_id" runat="server" CssClass="tb_css" />
        <asp:Label ID="SLabel" runat="server" CssClass="labelclass" />
        <h1>Enter Filtering Status</h1>
        <div>
        <asp:TextBox ID="S" runat="server" CssClass="tb_css" />
        <asp:Button id="button1" runat="server" Text="Filter Content" OnClick="filter" CssClass="button"/>
        </div>   
        </div>
    </form>
</body>
</html>
