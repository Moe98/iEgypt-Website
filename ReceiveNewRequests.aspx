<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReceiveNewRequests.aspx.cs" Inherits="ReceiveNewRequests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
            <link href="Style.css" rel ="Stylesheet" type =" text/css" />

</head>
<body>
    <form id="form1" runat="server">
          <asp:Button id="ReceiveRequests" runat="server" Text="Receive New Requests" OnClick="receive_new_requests" CssClass="button"/>
    </form>
</body>
</html>
