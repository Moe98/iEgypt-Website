<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Show_Notifications.aspx.cs" Inherits="Show_Notifications" %>

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
        <a href ="UploadOriginalContent.aspx"> Add Original Content </a>
        <a href ="UploadNewContent.aspx"> Add New Content </a>
        <a href ="ReceiveNewRequests.aspx"> New Requests </a>
        <a href ="Messages.aspx"> Messages </a>
        <a href ="Delete_Content.aspx"> Delete Content </a>
        <a href ="Show_Events.aspx"> Events </a>
        <a href ="Show_Notifications.aspx"> Notifications </a>
        <a href ="Show_Advertisement.aspx"> Advertisements </a>
    </div>
    <form id="form1" runat="server">
        <div>
        <asp:Label ID="Label1" runat="server" CssClass="labelclass"/>
        <h1>Your Notifications</h1>
	    <asp:GridView ID="notifications" runat="server" AutoGenerateColumns="false" CssClass="grid"> 
            <Columns>
                <asp:BoundField DataField="seen_at" HeaderText="Seen at" />
                <asp:BoundField DataField="sent_at" HeaderText="Sent at" />
                <asp:BoundField DataField="Description" HeaderText="Event's Description" />
                <asp:BoundField DataField="Location" HeaderText="Event's Location" />
                <asp:BoundField DataField="City" HeaderText="Event's city" />
                <asp:BoundField DataField="Time" HeaderText="Event's Time" />
                <asp:BoundField DataField="Entertainer" HeaderText="Event's Entertainer" />
                <asp:BoundField DataField="f1" HeaderText="Viewer's First Name (Event)" />
                <asp:BoundField DataField="m1" HeaderText=" Viewer's Middle Name(Event)" />
                <asp:BoundField DataField="l1" HeaderText="Viewer's Last Name (Event)" />
                <asp:BoundField DataField="accept_status" HeaderText="New Request's Accept Status" />
                <asp:BoundField DataField="specified" HeaderText="Specification of the New Request" />
                <asp:BoundField DataField="information" HeaderText="New Request's Information" />
                <asp:BoundField DataField="Accepted_at" HeaderText="Date of New Request's acceptance" />
                <asp:BoundField DataField="f2" HeaderText="First Name of viewer(New Request)" />
                <asp:BoundField DataField="m2" HeaderText="Middle Name of viewer(New Request)" />
                <asp:BoundField DataField="l2" HeaderText="Last Name of viewer (New Request)" />
            </Columns>
        </asp:GridView>
        </div>
    </form>
</body>
</html>
