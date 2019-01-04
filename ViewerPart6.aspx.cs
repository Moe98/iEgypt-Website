using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewerPart6 : System.Web.UI.Page
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
    public static String GetTimestamp(DateTime value)
    {
        return value.ToString("yyyy-MM-dd-HH-mm-ss");
    }
    public void writecomment(object sender, EventArgs args)
    {
        string text = comment_text.Text;
        string id = "" + Convert.ToInt32((sender as LinkButton).CommandArgument);
        if (text == "" || id == "")
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
            SqlCommand cmd2 = new SqlCommand("getTime", cnn);
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.Add("@time", System.Data.SqlDbType.DateTime).Direction = System.Data.ParameterDirection.Output;
            string now = "";
            using (SqlDataReader rdr2 = cmd2.ExecuteReader())
            {
                now = Convert.ToString(cmd2.Parameters["@time"].Value);
            }
            int open_id = Convert.ToInt32(Session["ID"]);
            String timeStamp = GetTimestamp(DateTime.Now);
            var Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            SqlCommand cmd = new SqlCommand("Write_Comment", cnn);
           // DateTime now = DateTime.Now;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@original_content_id", id));
                cmd.Parameters.Add(new SqlParameter("@viewer_id", open_id)); //change when connection is done
                cmd.Parameters.Add(new SqlParameter("@written_time", now));
                cmd.Parameters.Add(new SqlParameter("@comment_text", text));
                try
                {
                     SqlDataReader rdr = cmd.ExecuteReader(); //check that it executes the procedure
                }
                catch(Exception ex)
                {
                     testing.Text = "You already commented on this before!";
                }
                cnn.Close();
        }
    }
}