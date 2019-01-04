using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewerPart9_1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Session["ID"] = 1;
        int open_id = Convert.ToInt32(Session["ID"]);
        string connectionString;
        connectionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        cnn.Open();
        SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM Advertisement WHERE viewer_id="+open_id, cnn);
        DataTable dataTable = new DataTable();
        sqlData.Fill(dataTable);
        view.DataSource = dataTable;
        view.DataBind();
        cnn.Close();
    }
    public void editad(object sender, EventArgs args)
    {
        string id = "" + Convert.ToInt32((sender as LinkButton).CommandArgument);
        string desc = description.Text;
        string loc = location.Text;
        if (desc == "" || loc == ""|| id=="")
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
            SqlCommand cmd = new SqlCommand("Edit_Ad", cnn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@description", desc));
            cmd.Parameters.Add(new SqlParameter("@viewer_id", open_id)); //change when connection is done
            cmd.Parameters.Add(new SqlParameter("@location", loc));
            cmd.Parameters.Add(new SqlParameter("@ad_id", id));
            SqlDataReader rdr = cmd.ExecuteReader(); //check that it executes the procedure
            cnn.Close();
        }
    }
}