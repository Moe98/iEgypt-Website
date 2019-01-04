using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShowingNewRequests : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString;
        SqlConnection cnn;
        connectionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connectionString);
        cnn.Open();
        int id = Convert.ToInt32(Session["ID"]);
        SqlDataAdapter sqlData = new SqlDataAdapter("Show_New_Requests ", cnn);
        sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
        sqlData.SelectCommand.Parameters.AddWithValue("@contributor_id", id);
        DataTable dataTable = new DataTable();
        sqlData.Fill(dataTable);
        New_Requests.DataSource = dataTable;
        New_Requests.DataBind();
        cnn.Close();

    }
    protected void AcceptRequest(object sender, EventArgs e)
    {
        string command = (sender as LinkButton).CommandArgument;
        int r_id = Convert.ToInt32((command));
        int id = Convert.ToInt32(Session["ID"]);
        SqlConnection cnn;
        string connectionString;
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
        if (canReceive == 1)
        {
            cnn.Open();
            cmd = new SqlCommand("Respond_New_Request", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@contributor_id", id));
            cmd.Parameters.Add(new SqlParameter("@accept_status", true));
            cmd.Parameters.Add(new SqlParameter("@request_id", r_id));
            dr = cmd.ExecuteReader();
            dr.Close();
            cnn.Close();
            Response.Redirect("UserProfile.aspx");
        }


    }
    protected void RejectRequest(object sender, EventArgs e)
    {



        string command = (sender as LinkButton).CommandArgument;
        int r_id = Convert.ToInt32((command));
        int id = Convert.ToInt32(Session["ID"]);
        SqlConnection cnn;
        string connectionString;
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
        if (canReceive == 1)
        {
            cnn.Open();
            cmd = new SqlCommand("Respond_New_Request", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@contributor_id", id));
            cmd.Parameters.Add(new SqlParameter("@accept_status", false));
            cmd.Parameters.Add(new SqlParameter("@request_id", r_id));
            dr = cmd.ExecuteReader();
            dr.Close();
            cnn.Close();
            Response.Redirect("UserProfile.aspx");
        }
    }
}