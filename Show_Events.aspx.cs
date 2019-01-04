using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Show_Events : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString;
        SqlConnection cnn;
        connectionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connectionString);
        cnn.Open();

        SqlDataAdapter sqlData = new SqlDataAdapter("Select E.description,E.location,E.city,E.time,E.entertainer,U.first_name,U.middle_name,U.last_name,EP.link,EV.link from Event E inner join [User] U on U.ID=E.viewer_id left outer join Event_Photos_Link EP on EP.event_id=E.id left outer join Event_Videos_Link EV on EV.event_id=E.id", cnn);
        sqlData.GetFillParameters();
        DataTable dataTable = new DataTable();
        sqlData.Fill(dataTable);
        view.DataSource = dataTable;
        view.DataBind();

        cnn.Close();
    }
}