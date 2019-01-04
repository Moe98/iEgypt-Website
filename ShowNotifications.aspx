<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowNotifications.aspx.cs" Inherits="ShowNotifications" %>

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
 	<div>
        <asp:Label ID="Label1" runat="server" CssClass="labelclass"/>
        <h1>Your Notifications</h1>
	    <asp:GridView ID="view" runat="server" AutoGenerateColumns="false" CssClass="grid"> 
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="Notification ID" />
                <asp:BoundField DataField="seen_at" HeaderText="Seen at" />
                <asp:BoundField DataField="sent_at" HeaderText="Send at" />
                <asp:BoundField DataField="notified_person_id" HeaderText="Person ID" />
                <asp:BoundField DataField="notification_object_id" HeaderText="Object ID" />
            </Columns>
        </asp:GridView>
        </div>
    </form>>
</body>
</html>
