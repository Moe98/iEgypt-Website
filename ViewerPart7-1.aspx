<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewerPart7-1.aspx.cs" Inherits="ViewerPart7_1" %>

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
        <h1>Text</h1>
        <asp:TextBox ID="comment_text" runat="server" CssClass="tb_css" />
        <br>
        <asp:GridView ID="view" runat="server" AutoGenerateColumns="false" CssClass="grid">
            <Columns>
                <asp:BoundField DataField="date" HeaderText="Date" />
                <asp:BoundField DataField="text" HeaderText="Text" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="original_content_id" Text="Select Comment to Edit!" runat="server" CommandArgument='<%# Eval("original_content_id")+";"+Eval("date")%>' OnClick="editcomment" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
