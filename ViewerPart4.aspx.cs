using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewerPart4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int open_id = Convert.ToInt32(Session["ID"]);

        string connectionString;
        connectionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        cnn.Open();
        string query = "SELECT * FROM New_Request NR INNER JOIN Contributor C ON NR.contributor_id=C.ID INNER JOIN [User] U ON U.ID= C.ID WHERE viewer_id="+open_id + " AND NR.accept_status iS NULL OR NR.accept_status=0";
        SqlDataAdapter sqlData = new SqlDataAdapter(query, cnn);
        DataTable dataTable = new DataTable();
        sqlData.Fill(dataTable);
        view.DataSource = dataTable;
        view.DataBind();
        // cnn.Close();
    }
    public void deletenr(object sender, EventArgs args)
    {
        string id;
        id = "" + Convert.ToInt32((sender as LinkButton).CommandArgument);
        if (id == "")
        {
            testing.Text = "Please fill in the boxes appropriately";
        }
        else
        {
            testing.Text = "";
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            //connetionString = @"Data Source=localhost;Initial Catalog=GUC_WEB ;User ID=sa;Password=reallyStrongPwd123";

            cnn = new SqlConnection(connetionString);

            cnn.Open();
            int open_id = Convert.ToInt32(Session["ID"]);
            SqlCommand cmd = new SqlCommand("Delete_New_Request", cnn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@request_id", id));
           // cmd.Parameters.Add(new SqlParameter("@viewer_id", Session["ID"])); //change when connection is done
            SqlDataReader rdr = cmd.ExecuteReader(); //check that it executes the procedure
            cnn.Close();
        }
    }
}