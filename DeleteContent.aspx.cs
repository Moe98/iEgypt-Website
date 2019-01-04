using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeleteContent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connetionString; //connection
        SqlConnection cnn; //connection
        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connetionString);
        cnn.Open();

        SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM Content", cnn); // modify to display viewer's name not id using join
        DataTable dataTable = new DataTable();
        sqlData.Fill(dataTable);
        view.DataSource = dataTable;
        view.DataBind();
        cnn.Close();

    }

    protected void delete(object sender, EventArgs e)
    {
        int ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
        string connetionString; //connection
        SqlConnection cnn; //connection
        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connetionString);
        cnn.Open();
        SqlCommand cmd = new SqlCommand("Delete_Content", cnn);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@content_id", ID));
        SqlDataReader rdr = cmd.ExecuteReader();
        cnn.Close();
        Page_Load(null, null);
        //refresh the page, call page load?

    }
}