<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadNewContent.aspx.cs" Inherits="UploadNewContent" %>

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
         <asp:Label ID="Label1" runat="server" CssClass="labelclass"/> 
        <br />
        <asp:Label ID="typeID" runat="server" CssClass="labelclass"/> 
        <h2> Type  </h2>
        <asp:DropDownList ID="type_ID" runat="server" DataSourceID="SqlDataSource1" DataTextField="type" DataValueField="type" CssClass="ddl">
           </asp:DropDownList>
           <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:constr %>" SelectCommand="SELECT [type] FROM [Content_type]"></asp:SqlDataSource>
       
         <asp:Label ID="SubcategoryName" runat="server" CssClass="labelclass"/>
       <h2> Subcategory Name  </h2>
       <asp:TextBox ID="Subcategory_Name" runat="server" CssClass="tb_css"/>

       <asp:Label ID="CategoryID" runat="server" CssClass="labelclass"/>
       <h2> Category ID </h2>
       <asp:TextBox ID="Category_ID" runat="server" CssClass="tb_css"/>   
        
       <asp:Label ID="link" runat="server" CssClass="labelclass"/>
       <h2> Link </h2>
       <asp:TextBox ID="Contentlink" runat="server" CssClass="tb_css"/>   

         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" CssClass="grid">
             <Columns>
                 <asp:BoundField DataField="information" HeaderText="information" SortExpression="information" />
                 <asp:TemplateField>  
                     <ItemTemplate>
                         <asp:LinkButton ID="linkedButton" Text="Add  Content" runat="server" CommandArgument='<%#Eval("id")%>' OnClick="adding" />
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
         </asp:GridView>
         <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:constr%>" SelectCommand="SELECT [information],[id] FROM [New_Request]"></asp:SqlDataSource>
       
      

       
       
    </form>
</body>
</html>

        <div>
        </div>
    </form>
</body>
</html>
