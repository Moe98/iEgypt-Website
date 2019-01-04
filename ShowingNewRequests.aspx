<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowingNewRequests.aspx.cs" Inherits="ShowingNewRequests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
            <link href="Style.css" rel ="Stylesheet" type =" text/css" />

</head>
<body>
            <form id="form1" runat="server">
        <asp:GridView ID="New_Requests" runat="server" AutoGenerateColumns="False" CssClass="grid" >
             <Columns>
                 <asp:BoundField DataField="specified" HeaderText="Specified" />
                 <asp:BoundField DataField="information" HeaderText="Information" />
                 <asp:BoundField DataField="f1" HeaderText="Viewer's first name"  />
                  <asp:BoundField DataField="m1" HeaderText="Viewer's middle name"  />
                  <asp:BoundField DataField="l1" HeaderText="Viewer's last name"  />
                  <asp:BoundField DataField="f2" HeaderText="Contributors's first name (If Specified)"  />
                  <asp:BoundField DataField="m2" HeaderText="Contributors's middle name (If Specified)"  />
                  <asp:BoundField DataField="l2" HeaderText="Contributors's last name (If Specified)"  />
                 <asp:TemplateField>  
                     <ItemTemplate>
                         <asp:LinkButton ID="AcceptButton" Text="Accept Request" runat="server" CommandArgument='<%#Eval("id")%>' OnClick="AcceptRequest" />
                     </ItemTemplate>
                     </asp:TemplateField>
                  <asp:TemplateField> 
                     <ItemTemplate>
                      <asp:LinkButton ID="RejectButton" Text="Reject Request" runat="server" CommandArgument='<%#Eval("id")%>' OnClick="RejectRequest" />
                      </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
         </asp:GridView>

    </form>
</body>
</html>
