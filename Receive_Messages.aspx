<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Receive_Messages.aspx.cs" Inherits="Receive_Message" %>

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
         <asp:GridView ID="MessagesReceived" runat="server" AutoGenerateColumns="False" CssClass="grid" OnSelectedIndexChanged="MessagesReceived_SelectedIndexChanged" >
             <Columns>
                 <asp:BoundField DataField="sent_at" HeaderText="Sent at"  />
                 <asp:BoundField DataField="first_name" HeaderText="Viewer's First name" />
                  <asp:BoundField DataField="middle_name" HeaderText="Viewer's Middle name"/>
                  <asp:BoundField DataField="last_name" HeaderText="Viewer's last name"  />
                  <asp:BoundField DataField="read_at" HeaderText="Read at"  />
                  <asp:BoundField DataField="text" HeaderText="Text"  />
                 <asp:BoundField DataField="read_Status" HeaderText="Read Status"  />
             </Columns>
         </asp:GridView>
    </form>
</body>
</html>
