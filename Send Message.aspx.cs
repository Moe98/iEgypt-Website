using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Send_Message : System.Web.UI.Page
{
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString;
        SqlConnection cnn;
        connectionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connectionString);
        cnn.Open();
        SqlDataAdapter sqlData = new SqlDataAdapter("SELECT first_name,middle_name,last_name,ID From [User] where ID in  (Select ID from Viewer ) ", cnn);
        DataTable dataTable = new DataTable();
        sqlData.Fill(dataTable);
        Viewers.DataSource = dataTable;
        Viewers.DataBind();
        cnn.Close();
    }
    public void ChoosingViewer(object sender, EventArgs e)
    {
        string text;
        DateTime sent_at;
        sent_at = DateTime.Now;
        text = textMessage.Text;
        string connectionString;
        SqlConnection cnn;
        int cid = Convert.ToInt32(Session["ID"]);
        connectionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connectionString);
        cnn.Open();
        string command = (sender as LinkButton).CommandArgument;
        id = Convert.ToInt32((command));
        if (text == "" || id == 0)
        {
            label1.Text = "please fill this box";
        }
        else
        {
            SqlCommand cmd = new SqlCommand("Send_Message", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@msg_text", text));
            cmd.Parameters.Add(new SqlParameter("@viewer_id", id));
            cmd.Parameters.Add(new SqlParameter("@contributor_id", cid));
            cmd.Parameters.Add(new SqlParameter("@sender_type", 1));
            cmd.Parameters.Add(new SqlParameter("@sent_at", DateTime.Now));
            SqlDataReader rdr = cmd.ExecuteReader();
            Response.Redirect("Messages.aspx");
            cnn.Close();
        }






    }
}