using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class workingPlaceTypeRequests : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connetionString; //connection
        SqlConnection cnn; //connection

        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        cnn = new SqlConnection(connetionString);

        cnn.Open();

        SqlDataAdapter sqlData = new SqlDataAdapter("Workingplace_Category_Relation", cnn);
        DataTable dataTable = new DataTable();
        sqlData.Fill(dataTable);
        view.DataSource = dataTable;
        view.DataBind();
        cnn.Close();


    }
}