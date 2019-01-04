using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeleteComment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connetionString; //connection
        SqlConnection cnn; //connection
        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connetionString);
        cnn.Open();

        SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM Comment", cnn); // modify to display viewer's name not id using join
        DataTable dataTable = new DataTable();
        sqlData.Fill(dataTable);
        view.DataSource = dataTable;
        view.DataBind();
        cnn.Close();


    }


    protected void delete(object sender, EventArgs e)
    {
        string command = (sender as LinkButton).CommandArgument;
        string[] ar = command.Split(',');
        int V = Convert.ToInt32((ar[0]));
        int C = Convert.ToInt32((ar[1]));
        DateTime D = Convert.ToDateTime((ar[2]));

        string connetionString; //connection
        SqlConnection cnn; //connection
        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connetionString);
        cnn.Open();
        SqlCommand cmd = new SqlCommand("Delete_Comment", cnn);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@viewer_id", V));
        cmd.Parameters.Add(new SqlParameter("@original_content_id", C));
        cmd.Parameters.Add(new SqlParameter("@written_time", D));
        SqlDataReader rdr = cmd.ExecuteReader();
        cnn.Close();
        Page_Load(null, null);
        //refresh the page, call page load?

    }


}
