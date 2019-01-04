using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewerPart3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int open_id = Convert.ToInt32(Session["ID"]);
        string connectionString;
        connectionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        cnn.Open();
        string query = "SELECT * FROM Contributor C INNER JOIN [User] U ON C.ID=U.ID";
        SqlDataAdapter sqlData = new SqlDataAdapter(query, cnn);
        DataTable dataTable = new DataTable();
        sqlData.Fill(dataTable);
        view.DataSource = dataTable;
        view.DataBind();
        // cnn.Close();
    }
    public void applynr(object sender, EventArgs args)
    {
        string cont_id;
        string info;
        cont_id = "" + Convert.ToInt32((sender as LinkButton).CommandArgument);
        info = information.Text;
        if (cont_id == "" || info == "")
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
            SqlCommand cmd = new SqlCommand("Apply_New_Request", cnn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@contributor_id", cont_id));
            cmd.Parameters.Add(new SqlParameter("@information", info));
            cmd.Parameters.Add(new SqlParameter("@viewer_id", open_id)); //change when connection is done
            SqlDataReader rdr = cmd.ExecuteReader(); //check that it executes the procedure
            cnn.Close();
        }
    }
}