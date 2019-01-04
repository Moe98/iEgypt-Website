using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewerPart10Redirect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String s = Request.QueryString["requested_id"];
        string connectionString;
        connectionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        cnn.Open();
        string query = "SELECT * FROM Contributor C INNER JOIN [User] U ON C.ID=U.ID WHERE C.ID="+s.ToString();
        SqlDataAdapter sqlData = new SqlDataAdapter(query, cnn);
        DataTable dataTable = new DataTable();
        sqlData.Fill(dataTable);
        view.DataSource = dataTable;
        view.DataBind();
        cnn.Close();
    }
}