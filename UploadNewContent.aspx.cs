using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UploadNewContent : System.Web.UI.Page
{
    public int r_id;


    public void adding(object sender, EventArgs e)
    {
        string command = (sender as LinkButton).CommandArgument;
        r_id = Convert.ToInt32((command));
        string type_id;
        string subcategory_name;
        string categoryId;
        string link;
        type_id = type_ID.SelectedItem.Text;

        subcategory_name = Subcategory_Name.Text;
        categoryId = Category_ID.Text;
        link = Contentlink.Text;
        if (type_id == "" || subcategory_name == "" || categoryId == "" || link == "" || r_id == 0)
        {
            Label1.Text = "Please fill all Data";
        }
        else
        {


            string connectionString;
            SqlConnection cnn;
            connectionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            int id = Convert.ToInt32(Session["ID"]);
            try
            {
                SqlCommand cmd = new SqlCommand("Upload_New_Content", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@new_request_id", r_id));
                cmd.Parameters.Add(new SqlParameter("@contributor_id", id));
                cmd.Parameters.Add(new SqlParameter("@subcategory_name", subcategory_name));
                cmd.Parameters.Add(new SqlParameter("@category_id", categoryId));
                cmd.Parameters.Add(new SqlParameter("@link", link));
                cmd.Parameters.Add(new SqlParameter("@type", type_id));
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Close();
                Response.Redirect("UserProfile.aspx");
            }
            catch (Exception ex)
            {
                Label1.Text = "Please enter valid category or subcategory";
            }

        }
    }

}