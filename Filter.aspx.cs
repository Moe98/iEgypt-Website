using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Filter : System.Web.UI.Page
{

    bool IsDigitsOnly(string str)
    {
        foreach (char c in str)
        {
            if (c < '0' || c > '9')
                return false;
        }

        return true;
    }

    public void filter(Object sender, EventArgs args)
    {
        string org_cont_id;
        org_cont_id = original_content_id.Text;
        String Sts = S.Text;

        string connetionString; //connection
        SqlConnection cnn; //connection

        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        cnn = new SqlConnection(connetionString);

        cnn.Open();

        /* if () // Authorized reviewer
         {

         }
         else // content manager
         {

         }*/

        Byte status = 0;
        if (IsDigitsOnly(Sts) && IsDigitsOnly(org_cont_id) && !(org_cont_id == "" || Sts == ""))
        {
            if (Sts != null)
            {
                status = Convert.ToByte(Sts);
            }

            if (org_cont_id == "" || Sts == "") //if the user clicks the button without filling in any info
            {
                Filtering.Text = "Please fill in the boxes appropriately";
            }
            else
            {
                Filtering.Text = "";
                SqlCommand cmd = new SqlCommand("reviewer_filter_content", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@reviewer_id", Session["ID"]));
                cmd.Parameters.Add(new SqlParameter("@original_content", org_cont_id));
                cmd.Parameters.Add(new SqlParameter("@status", status));
                SqlDataReader rdr = cmd.ExecuteReader();

            }
        }
        else
        {
            Filtering.Text = "Please fill in the boxes appropriately";

        }

        cnn.Close();


    }
}