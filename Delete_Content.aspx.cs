using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Delete_Content : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Session["ID"]);
        string connectionString;
        SqlConnection cnn;
        connectionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connectionString);
        cnn.Open();
        SqlDataAdapter sqlData = new SqlDataAdapter("ShowingContent", cnn);
        sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
        sqlData.SelectCommand.Parameters.AddWithValue("@contrID", id);
        DataTable dataTable = new DataTable();
        sqlData.Fill(dataTable);
        Content.DataSource = dataTable;
        Content.DataBind();
    }
    public void DeleteContent(object sender, EventArgs e)
    {

        string command = (sender as LinkButton).CommandArgument;
        int id;
        id = Convert.ToInt32((command));
        string connectionString;
        SqlConnection cnn;
        connectionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connectionString);
        cnn.Open();
        SqlCommand cmd = new SqlCommand("typeOfContent", cnn);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("id", id));
        cmd.Parameters.Add("@OriginalContent", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
        int contentType = 0;
        SqlDataReader dr;
        using (dr = cmd.ExecuteReader())
        {
            contentType = Convert.ToInt32(cmd.Parameters["@OriginalContent"].Value);
        }
        dr.Close();
        cnn.Close();
        cnn.Open();

        if (contentType == 1)
        {

            cmd = new SqlCommand("Delete_Original_Content", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("content_id", id));
            dr = cmd.ExecuteReader();
        }
        else
        {
            if (contentType == 0)
            {
                cmd = new SqlCommand("Delete_New_Content", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("content_id", id));
                dr = cmd.ExecuteReader();
            }
        }
        Response.Redirect("UserProfile.aspx");
        cnn.Close();


    }

}