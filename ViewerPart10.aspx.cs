using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewerPart10 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int open_id = Convert.ToInt32(Session["ID"]);
        string connectionString;
        connectionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        cnn.Open();
        string query = "SELECT * FROM New_Content NC INNER JOIN New_Request NR ON NC.new_request_id = NR.id INNER JOIN Contributor C ON NR.contributor_id = C.ID INNER JOIN[User] U ON C.ID = U.ID WHERE NR.accept_status = 1";
        //string query = "SELECT * FROM Contributor";
        SqlDataAdapter sqlData = new SqlDataAdapter(query, cnn);
        DataTable dataTable = new DataTable();
        sqlData.Fill(dataTable);
        view.DataSource = dataTable;
        view.DataBind();
        cnn.Close();
    }
    public void displayc(object sender, EventArgs args)
    {
        string requested_id = "" + Convert.ToInt32((sender as LinkButton).CommandArgument);
        string connetionString;
        SqlConnection cnn;

        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        //connetionString = @"Data Source=localhost;Initial Catalog=GUC_WEB ;User ID=sa;Password=reallyStrongPwd123";

        cnn = new SqlConnection(connetionString);

        cnn.Open();
        Response.Redirect("ViewerPart10Redirect.aspx?requested_id=" + requested_id);
    }
}