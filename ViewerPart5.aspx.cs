using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewerPart5 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int open_id = Convert.ToInt32(Session["ID"]);
        string connectionString;
        connectionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        cnn.Open();
        string query = "SELECT * FROM Original_Content OC INNER JOIN Content C ON OC.ID=C.ID INNER JOIN Contributor CC ON C.contributor_id=CC.ID INNER JOIN [User] U ON CC.ID=U.ID";
        SqlDataAdapter sqlData = new SqlDataAdapter(query, cnn);
        DataTable dataTable = new DataTable();
        sqlData.Fill(dataTable);
        view.DataSource = dataTable;
        view.DataBind();
        // cnn.Close();
    }
    bool IsDigitsOnly(string str)
    {
        foreach (char c in str)
        {
            if (c < '0' || c > '9')
                return false;
        }

        return true;
    }
    public void rateoc(object sender, EventArgs args)
    {
        string id = "" + Convert.ToInt32((sender as LinkButton).CommandArgument);
        string rating = rating_value.Text;
        rating.ToString();
        if (id == "" || rating == "")
        {
            testing.Text = "Please fill in the boxes appropriately";
        }
        else
        {
            if (!IsDigitsOnly(rating))
            {
                testing.Text = "Please insert a number";
            }
            else
            {
                if (System.Convert.ToInt32(rating) < 0 || System.Convert.ToInt32(rating) > 5)
                {
                    testing.Text = "Please choose a rating between 0 and 5 inclusive";
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

                    SqlCommand cmd = new SqlCommand("Rating_Original_Content", cnn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@original_content_id", id));
                    cmd.Parameters.Add(new SqlParameter("@viewer_id", open_id)); //change when connection is done
                    cmd.Parameters.Add(new SqlParameter("@rating_value", rating));
                    try
                    {
                        SqlDataReader rdr = cmd.ExecuteReader(); //check that it executes the procedure
                    }
                    catch (Exception ex)
                    {
                        testing.Text = "You have rated this item before!";
                    }
                    cnn.Close();
                }
            }
        }
    }
}