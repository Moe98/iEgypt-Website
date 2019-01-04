using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateContentType : System.Web.UI.Page
{
    public void createType(Object sender, EventArgs args)
    {
        String type = Type.Text;

        string connetionString; //connection
        SqlConnection cnn; //connection

        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        cnn = new SqlConnection(connetionString);

        cnn.Open();


        if (type == "") //if the user clicks the button without filling in any info
        {
            Label1.Text = "Please fill in the boxes appropriately";
        }
        else
        {
            SqlCommand cmd = new SqlCommand("Staff_Create_Type", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@type_name", type));
            SqlDataReader rdr = cmd.ExecuteReader();
            cnn.Close();
        }
    }
}