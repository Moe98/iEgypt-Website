<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewerPart5.aspx.cs" Inherits="ViewerPart5" %>

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
    <form id="Rate_OC" runat="server">
        <asp:Label ID="testing" runat="server" CssClass="labelclass"/>
        <h1>Rating Value</h1>
        <asp:TextBox ID="rating_value" runat="server" CssClass="tb_css"/>
        <br>
        <br>
        <asp:GridView ID="view" runat="server" AutoGenerateColumns="false" CssClass="grid">
            <Columns>
                <asp:BoundField DataField="first_name" HeaderText="Contributor's First Name" />
                <asp:BoundField DataField="middle_name" HeaderText="Contributor's Middle Name" />
                <asp:BoundField DataField="last_name" HeaderText="Contributor's Last Name" />
                <asp:BoundField DataField="portfolio_link" HeaderText="Portfolio" />
                <asp:BoundField DataField="specialization" HeaderText="Specialization" />
                <asp:BoundField DataField="uploaded_at" HeaderText="Uploaded At" />
                <asp:BoundField DataField="link" HeaderText="Link" />
                <asp:BoundField DataField="rating" HeaderText="Rating" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="ID" Text="Select Original Content to Rate" runat="server" CommandArgument='<%# Eval("id")%>' OnClick="rateoc" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
