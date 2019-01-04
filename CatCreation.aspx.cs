using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CatCreation : System.Web.UI.Page
{
    protected void CreateCategory(object sender, EventArgs e)
    {
        String Cat= textBox1.Text;
        String SubCat= TextBox2.Text;

        string connetionString; //connection
        SqlConnection cnn; //connection
        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connetionString);
        cnn.Open();

        if(Cat=="" || SubCat=="")
        {
            Label1.Text= "Please fill in the boxes appropriately";
        }
        else
        {
            SqlCommand cmd1 = new SqlCommand("Staﬀ_Create_Category", cnn);
            cmd1.CommandType = System.Data.CommandType.StoredProcedure;
            cmd1.Parameters.Add(new SqlParameter("@category_name",Cat));
            SqlDataReader rdr = cmd1.ExecuteReader();
            rdr.Close();
            SqlCommand cmd2 = new SqlCommand("Staﬀ_Create_Subcategory", cnn);
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.Add(new SqlParameter("@category_name", Cat));
            cmd2.Parameters.Add(new SqlParameter("@subcategory_name", SubCat));
            SqlDataReader rdr2 = cmd2.ExecuteReader();
            cnn.Close();

        }
    }
}