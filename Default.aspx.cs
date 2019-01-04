using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
//namespace milestone3WEBSITE
//{
// public partial class Default : System.Web.UI.Page
// {
// }
//}
public partial class Default : System.Web.UI.Page
{
    public void loginmethod(object sender, EventArgs args)
    {
        string e;
        string p;
        e = email.Text;
        p = password.Text;
        if (e == "" || p == "")
            display_text.Text = "Please fill in all info";
        else
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);

            cnn.Open();
            SqlCommand cmd = new SqlCommand("User_login", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@password", p));
            cmd.Parameters.Add(new SqlParameter("@email", e));
            cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int).Direction =
           System.Data.ParameterDirection.Output;
            int user_id = 0;
            // execute the command
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                user_id = Convert.ToInt32(cmd.Parameters["@user_id"].Value);
            }
            cnn.Close();
            Session["ID"] = user_id;
            if (user_id != -1)
            {
                Response.Redirect("UserProfile.aspx?user_id = " + user_id);
            }
            else
            {
                display_text.Text = "Profile deactivated or non existant.Please retry loging in :)";
            }
        }
    }
    public void regRedirect(object sender, EventArgs args)
    {
        Response.Redirect("Register.aspx");
    }
}