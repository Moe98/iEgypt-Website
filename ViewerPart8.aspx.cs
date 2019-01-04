using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewerPart8 : System.Web.UI.Page
{
    public void createads(object sender, EventArgs args)
    {
        string desc = description.Text;
        string loc = location.Text;
        if (desc == "" || loc == "")
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
            SqlCommand cmd = new SqlCommand("Create_Ads", cnn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@description", desc));
            cmd.Parameters.Add(new SqlParameter("@viewer_id", open_id)); //change when connection is done
            cmd.Parameters.Add(new SqlParameter("@location", loc));
            SqlDataReader rdr = cmd.ExecuteReader(); //check that it executes the procedure
            cnn.Close();
        }
    }
}