using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Receive_Message : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Session["ID"]);
        string connectionString;
        SqlConnection cnn;
        connectionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connectionString);
        cnn.Open();
        SqlDataAdapter sqlData = new SqlDataAdapter("showMessages", cnn);
        sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
        sqlData.SelectCommand.Parameters.AddWithValue("@id", id);
        DataTable dataTable = new DataTable();
        sqlData.Fill(dataTable);
        MessagesReceived.DataSource = dataTable;
        MessagesReceived.DataBind();
        cnn.Close();
        cnn.Open();
        SqlCommand cmd = new SqlCommand("updateMessageSeen", cnn);
        cmd.Parameters.Add(new SqlParameter("@ID", id));
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        SqlDataReader rdr = cmd.ExecuteReader();
        rdr.Close();
        cnn.Close();
    }

    protected void MessagesReceived_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}