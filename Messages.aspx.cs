using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Messages : System.Web.UI.Page
{
    protected void sendMessage(object sender, EventArgs e)
    {
        Response.Redirect("Send Message.aspx");
    }
    protected void receiveMessage(object sender, EventArgs e)
    {
        Response.Redirect("Receive_Messages.aspx");
    }
}