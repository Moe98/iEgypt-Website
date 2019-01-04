using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Show_Advertisement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connetionString; //connection
        SqlConnection cnn; //connection
        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connetionString);
        cnn.Open();

        SqlDataAdapter sqlData = new SqlDataAdapter("SELECT A.description as d1,A.location,AP.link,AV.link,U.first_name,U.middle_name,U.last_name,E.description,E.location,E.city,E.time,E.entertainer,EP.link,EV.link FROM Advertisement A inner join [User] U on U.ID=A.viewer_id left outer join Ads_Photos_Link AP on AP.advertisement_id=A.id left outer join Ads_Video_Link AV on AV.advertisement_id=A.id left outer join Event E on E.id=A.event_id left outer join Event_Photos_Link EP on EP.event_id=E.id left outer join Event_Videos_Link EV on EV.event_id =E.id ", cnn); //CheckThat
        sqlData.GetFillParameters();
        DataTable dataTable = new DataTable();
        sqlData.Fill(dataTable);
        advertisements.DataSource = dataTable;
        advertisements.DataBind();
    }
}