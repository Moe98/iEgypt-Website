<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Send Message.aspx.cs" Inherits="Send_Message" %>

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
         <asp:Label ID="label1" runat="server" CssClass="labelclass"/> 
        <h1> Text  </h1>
       <asp:TextBox ID="textMessage" runat="server" CssClass="tb_css" />
        <br/>
        <br/>
        <br/>

            <asp:GridView ID="Viewers" runat="server" AutoGenerateColumns="False" CssClass="grid" >
             <Columns>
                 <asp:BoundField DataField="first_name" HeaderText="Viewer's first name"  />
                 <asp:BoundField DataField="middle_name" HeaderText="Viewer's middle name"  />
                 <asp:BoundField DataField="last_name" HeaderText="Viewer's last name"  />  
                 <asp:TemplateField>  
                     <ItemTemplate>
                         <asp:LinkButton ID="linkedButton" Text="Choose Viewer" runat="server" CommandArgument='<%#Eval("ID")%>' OnClick="ChoosingViewer" />
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
         </asp:GridView>

      
      
    </form>
</body>
</html>
