<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BestContributors.aspx.cs" Inherits="BestContributors" %>

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
        <h1>List of Contributors</h1>
	<asp:GridView ID="view" runat="server" AutoGenerateColumns="false" CssClass="grid"> 
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Number of handled requests" HeaderText="Number of handled requests" />
                <asp:TemplateField>
                    <ItemTemplate>
                         <asp:LinkButton ID="LinkDel" Text="Select" runat="server" CommandArgument='<%#Eval("ID") %>' OnClick="setC" />
                    </ItemTemplate>
</asp:TemplateField>
            </Columns>
        </asp:GridView>
         <br />
         <h2>List of New Requests</h2>
         <br />
         <asp:GridView ID="view2" runat="server" AutoGenerateColumns="false" CssClass="grid"> 
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="accept_status" HeaderText="Status" />
                <asp:BoundField DataField="specified" HeaderText="Specified" />
                <asp:BoundField DataField="information" HeaderText="Information" />
                <asp:BoundField DataField="viewer_id" HeaderText="Viewer ID" />
                <asp:BoundField DataField="notif_obj_id" HeaderText="Object ID" />
                <asp:TemplateField>
                    <ItemTemplate>
                         <asp:LinkButton ID="LinkDel" Text="Select" runat="server" CommandArgument='<%#Eval("id") %>' OnClick="setR" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

         <h2>Contributor</h2>
         <asp:Label ID="C_ID" runat="server" CssClass="labelclass"/>
         <asp:GridView ID="view3" runat="server" AutoGenerateColumns="false" CssClass="grid"> 
            <Columns>
                <asp:BoundField DataField="first_name" HeaderText="First name" />
                <asp:BoundField DataField="middle_name" HeaderText="Middle name" />
                <asp:BoundField DataField="last_name" HeaderText="Last name" />
            </Columns>
        </asp:GridView>
         <h2>Requests</h2>
         <asp:Label ID="R_ID" runat="server" CssClass="labelclass"/>
         <br />
         <asp:Button id="button1" runat="server" Text="Assign" OnClick="assign" CssClass="button"/>
        </div>
    </form>
</body>
</html>
