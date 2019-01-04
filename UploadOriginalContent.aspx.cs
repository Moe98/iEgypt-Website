using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UploadOriginalContent : System.Web.UI.Page
{
    protected void addingOriginalContent(object sender, EventArgs e)
    {
        string type_id;
        string subcategory_name;
        string category_id;
        string link;

        type_id = type_ID.SelectedItem.Text;
        subcategory_name = Subcategory_Name.Text;
        category_id = Category_ID.Text;
        link = Contentlink.Text;
        int id = Convert.ToInt32(Session["ID"]);
        if (type_id == "" || subcategory_name == "" || category_id == "" || link == "")
        {
            Label1.Text = "Please fill the remaining boxes";
        }
        else
        {
            string connectionString;
            SqlConnection cnn;
            connectionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("Upload_Original_Content", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@contributor_id", id));
                cmd.Parameters.Add(new SqlParameter("@type_id", type_id));
                cmd.Parameters.Add(new SqlParameter("@subcategory_name", subcategory_name));
                cmd.Parameters.Add(new SqlParameter("@category_id", category_id));
                cmd.Parameters.Add(new SqlParameter("@link", link));
                SqlDataReader rdr = cmd.ExecuteReader();
                Response.Redirect("UserProfile.aspx");
            }
            catch (Exception ex)
            {
                Label1.Text = "Please enter valid category and subcategory";
            }
           
            
            cnn.Close();
        }

    }
}