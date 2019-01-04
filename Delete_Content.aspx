<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Delete_Content.aspx.cs" Inherits="Delete_Content" %>

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
        <asp:GridView ID="Content" runat="server" AutoGenerateColumns="False" CssClass="grid" >
             <Columns>
                 <asp:BoundField DataField="link" HeaderText="link" SortExpression="link" />
                 <asp:BoundField DataField="uploaded_at" HeaderText="uploaded_at" SortExpression="uploaded_at" />
                 <asp:BoundField DataField="category_type" HeaderText="category_type" SortExpression="category_type" />
                  <asp:BoundField DataField="subcategory_name" HeaderText="subcategory_name" SortExpression="subcategory_name" />
                  <asp:BoundField DataField="type" HeaderText="type" SortExpression="type" />
                 <asp:TemplateField>  
                     <ItemTemplate>
                         <asp:LinkButton ID="linkedButton" Text="Delete Content" runat="server" CommandArgument='<%#Eval("ID")%>' OnClick="DeleteContent" />
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
         </asp:GridView>

    </form>
</body>
</html>
