using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewerPart7_2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //  Session["ID"] = 1;
        int open_id = Convert.ToInt32(Session["ID"]);
        string connectionString;
        connectionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        cnn.Open();
        string query = "SELECT * FROM Comment WHERE viewer_id=" + open_id;
        SqlDataAdapter sqlData = new SqlDataAdapter(query, cnn);
        DataTable dataTable = new DataTable();
        sqlData.Fill(dataTable);
        view.DataSource = dataTable;
        view.DataBind();
        // cnn.Close();
    }
    public void deletecomment(object sender, EventArgs args)
    {
        //string id = "" + Convert.ToInt32((sender as LinkButton).CommandArgument);
        //string time = written_time.Text;
        string[] s = new string[2];
        s = Convert.ToString((sender as LinkButton).CommandArgument).Split(';');
        string id = s[0];
        string time = s[1];
        if (id == "" || time == "" )
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
            SqlCommand cmd = new SqlCommand("Delete_Comment", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@original_content_id", id));
            cmd.Parameters.Add(new SqlParameter("@viewer_id", open_id)); //change when connection is done
            cmd.Parameters.Add(new SqlParameter("@written_time", time));
            SqlDataReader rdr = cmd.ExecuteReader(); //check that it executes the procedure
            cnn.Close();
        }
    }
}