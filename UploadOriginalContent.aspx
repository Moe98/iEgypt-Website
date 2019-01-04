<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadOriginalContent.aspx.cs" Inherits="UploadOriginalContent" %>

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
    <form id="form" runat="server">
     
         <asp:Label ID="Label1" runat="server" CssClass="labelclass"/> 
         <h2> Type  </h2>
         <asp:SqlDataSource ID="type" runat="server" ConnectionString="<%$ ConnectionStrings:constr %>" SelectCommand="SELECT [type] FROM [Content_type]"></asp:SqlDataSource>
         <asp:DropDownList ID="type_ID" runat="server" DataSourceID="type" DataTextField="type" DataValueField="type" CssClass="ddl">
              </asp:DropDownList>

       <asp:Label ID="SubcategoryName" runat="server" CssClass="labelclass"/>
       <h2> Subcategory Name  </h2>
       <asp:TextBox ID="Subcategory_Name" runat="server" CssClass="tb_css"/>

       <asp:Label ID="CategoryID" runat="server" CssClass="labelclass"/>
       <h2> Category ID </h2>
       <asp:TextBox ID="Category_ID" runat="server" CssClass="tb_css"/>   
        
       <asp:Label ID="link" runat="server" CssClass="labelclass"/>
       <h2> Link </h2>
       <asp:TextBox ID="Contentlink" runat="server" CssClass="tb_css"/>   

        <br/>
         <asp:Button id="buttonOriginalContent" runat="server" Text="Add Original Content" OnClick="addingOriginalContent" CssClass="button"/>
       
    </form>
</body>
</html>
