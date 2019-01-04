<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeleteComment.aspx.cs" Inherits="DeleteComment" %>

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
        <h1>Choose a comment to delete</h1>
        <asp:GridView ID="view" runat="server" AutoGenerateColumns="false" CssClass="grid"> 
            <Columns>
                <asp:BoundField DataField="Viewer_id" HeaderText="Viewer ID" />
                <asp:BoundField DataField="original_content_id" HeaderText="Original Content ID" />
                <asp:BoundField DataField="date" HeaderText="Date" />
                <asp:BoundField DataField="text" HeaderText="Comment" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkDel" Text="Delete" runat="server" CommandArgument='<%#Eval("Viewer_id") + "," + Eval("original_content_id")+ "," + Eval("date") %>' OnClick="delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
	</div>
    </form>
</body>
</html>
