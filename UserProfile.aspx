<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>
<!DOCTYPE html>
<html>
<head runat="server">
<title>Profile</title>
    <link href="Style.css" rel ="Stylesheet" type =" text/css" />
</head>
<body>
    <div class ="sidenav">
        <a href ="UserProfile.aspx"> Home </a>
        <a href ="Default.aspx"> Log out </a>
    </div>
<form id="form3" runat="server">
 <h2>Search for original content by type or category</h2>
 <asp:TextBox id="sorigcont" runat="server" CssClass="tb_css"/>
 <br><br>
 <asp:Button id="button" runat="server" Text="Search" OnClick="searchOrigContent" class="button"/>
 <br><br>
 <asp:Label id="OrigCont" runat="server" CssClass="labelclass"/>
 <h2>Search for contributor by name</h2>
 <asp:TextBox id="searchCont" runat="server" CssClass="tb_css"/>
 <br><br>
 <asp:Button id="button1" runat="server" Text="Search" OnClick="searchContributor" class="button"/>
 <br><br>
 <asp:Label id="contributor" runat="server" CssClass="labelclass"/>
 <br><br>
 <asp:Button id="button2" runat="server" Text="Show Contributors"
OnClick="showAllContributor" class="button"/>
 <br><br>
 <asp:Label id="contributors" runat="server" CssClass="labelclass"/>
 <h2>Search for original content by contributor's name</h2>
 <asp:TextBox id="contributorname" runat="server" CssClass="tb_css"/>
 <br><br>
 <asp:Button id="button3" runat="server" Text="Search" OnClick="searchOrigContent2" class="button"/>
 <br><br>
 <asp:Label id="cont" runat="server" CssClass="labelclass"/>
 <br /><br />
 <asp:Button id="button4" runat="server" Text="ShowMyInfo" OnClick="show" class="button"/>
 <br><br>
 <asp:Label id="info" runat="server" CssClass="labelclass"/>
 <br><br>
 <asp:Button id="button5" runat="server" Text="edit profile" OnClick="edit" class="button"/>
 <br><br>
 <asp:Button id="button6" runat="server" Text="deactivate" OnClick="deac" class="button"/>
 <br><br>

 <% if (getUserType()=="Viewer") {%>
 <asp:Button id="button7" runat="server" Text="createEvent" OnClick="cevent" class="button"/>
 <br><br>
 <asp:Button id="button8" runat="server" Text="apply for existent" OnClick="applyEx" class="button"/>
 <br><br>
 <asp:Button id="button9" runat="server" Text="apply for new" OnClick="applyNew" class="button"/>
 <br><br>
 <asp:Button id="button10" runat="server" Text="delete request" OnClick="deleteReq" class="button"/>
 <br><br>
 <asp:Button id="button12" runat="server" Text="review original content" OnClick="review" class="button"/>
 <br><br>
 <asp:Button id="button13" runat="server" Text="add comment" OnClick="comment" class="button"/>
 <br><br>
 <asp:Button id="button14" runat="server" Text="delete comment" OnClick="deletecomment" class="button"/>
 <br><br>
 <asp:Button id="button15" runat="server" Text="edit comment" OnClick="editcomment" class="button"/>
 <br><br>
 <asp:Button id="button16" runat="server" Text="create ad" OnClick="createAd" class="button"/>
 <br><br>
 <asp:Button id="button17" runat="server" Text="edit ad" OnClick="editAd" class="button"/>
 <br><br>
<asp:Button ID="button19" runat="server" Text="delete ad" OnClick="deleteAd" class="button"/>
<br /><br>
 <asp:Button id="button18" runat="server" Text="show new content" OnClick="showNewC" class="button"/>
    <br />
 <br>
 <% }%>
    <% if (getUserType()=="Authorized Reviewer" || getUserType()=="Content Manager") {%>
            <% if (getUserType()=="Authorized Reviewer"){%>
            <asp:Button id="button11" runat="server" Text="Filter" OnClick="fil" class="button"/>
            <br />
            <br>
            <%  }%>
            <% if (getUserType()=="Content Manager"){%>
            <asp:Button id="button20" runat="server" Text="Accept Filter" OnClick="afil" class="button"/>
            <br />
            <br>
            <%  }%>
            <asp:Button id="button21" runat="server" Text="Create Content Type" OnClick="cconttype" class="button"/>
            <br>
            <br>
            <asp:Button id="button22" runat="server" Text="Get Existing Requests" OnClick="getEXCont" class="button"/>
            <br>
            <br>
            <asp:Button id="button23" runat="server" Text="Working Place Type Requests" OnClick="wptr" class="button"/>
            <br><br>
            <asp:Button id="button24" runat="server" Text="Show Notifications" OnClick="showNot" class="button"/>
            <br><br>
            <asp:Button id="button25" runat="server" Text="Delete Comment" OnClick="delcom" class="button"/>
            <br><br>
            <asp:Button id="button26" runat="server" Text="Delete Content" OnClick="delcont" class="button"/>
            <br><br>
            <asp:Button id="button27" runat="server" Text="Create Category" OnClick="createcat" class="button"/>
            <br><br>
            <asp:Button id="button28" runat="server" Text="Show Contributors" OnClick="showCont" class="button"/> 
            <br><br>
            <%  }%>
    <% if (getUserType()=="Contributor") {%>
            <asp:Button id="button29" runat="server" Text="Upload Original Content" OnClick="upOrgCont" class="button"/>
            <br><br>
            <asp:Button id="button30" runat="server" Text="Upload New Content" OnClick="upNewCont" class="button"/>
            <br><br>
            <asp:Button id="button31" runat="server" Text="Receive New Requests" OnClick="RecNewReq" class="button"/>
            <br><br>
            <asp:Button id="button32" runat="server" Text="Messages" OnClick="Messages" class="button"/>
            <br><br>
            <asp:Button id="button33" runat="server" Text="Delete Content" OnClick="DelCont" class="button"/>
            <br><br>
            <asp:Button id="button34" runat="server" Text="Show Notification" OnClick="ShowNOTIFICATION" class="button"/>
            <br><br>
            <asp:Button id="button35" runat="server" Text="Show Event" OnClick="SHOWev" class="button"/>
            <br><br>
            <asp:Button id="button36" runat="server" Text="Show ad" OnClick="SHOWad" class="button"/>
            <br><br>
            <%  }%>

</form>
</body>
</html>