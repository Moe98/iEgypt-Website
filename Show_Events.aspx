<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Show_Events.aspx.cs" Inherits="Show_Events" %>

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
        <h1>Events</h1>
	    <asp:GridView ID="view" runat="server" AutoGenerateColumns="false" CssClass="grid"> 
            <Columns>
                <asp:BoundField DataField="description" HeaderText="Description" />
                <asp:BoundField DataField="location" HeaderText="Location" />
                <asp:BoundField DataField="city" HeaderText="City" />
                <asp:BoundField DataField="time" HeaderText="Time" />
                <asp:BoundField DataField="entertainer" HeaderText="Entertainer" />
                <asp:BoundField DataField="first_name" HeaderText="Viewer's First Name" />
                <asp:BoundField DataField="middle_name" HeaderText="Viewer's Middle Name" />
                <asp:BoundField DataField="last_name" HeaderText="Viewer's Last Name" />
                <asp:BoundField DataField="link" HeaderText=" Photos' Link" />
                <asp:BoundField DataField="link" HeaderText="Videos' Link " />
            </Columns>
        </asp:GridView>
        </div>
    </form>
</body>
</html>
