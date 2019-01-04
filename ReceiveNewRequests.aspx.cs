using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReceiveNewRequests : System.Web.UI.Page
{
    protected void receive_new_requests(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Session["ID"]);
        string connectionString;
        SqlConnection cnn;
        connectionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connectionString);
        cnn.Open();
        SqlCommand cmd = new SqlCommand("Receive_New_Request", cnn);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("contributor_id", id));
        cmd.Parameters.Add("@can_receive", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
        int canReceive = 0;
        SqlDataReader dr;
        using (dr = cmd.ExecuteReader())
        {
            canReceive = Convert.ToInt32(cmd.Parameters["@can_receive"].Value);
        }
        dr.Close();
        cnn.Close();
        cnn.Open();
        if (canReceive == 0)
        {
            ReceiveRequests.Text = "Can't receive new Requests right now ";
        }
        if (canReceive == 1)
        {
            Response.Redirect("ShowingNewRequests");
        }

    }
}