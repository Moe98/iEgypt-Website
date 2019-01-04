using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShowNotifications : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string connetionString; //connection
        SqlConnection cnn; //connection
        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connetionString);
        cnn.Open();

        int ID = Convert.ToInt32(Session["ID"]);
        int NotifID = 0;
        SqlCommand cm = new SqlCommand("getNotifiedID", cnn);
        cm.CommandType = System.Data.CommandType.StoredProcedure;
        cm.Parameters.Add(new SqlParameter("@ID", ID));
        cm.Parameters.Add("@notifID", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
        using (SqlDataReader rdrid = cm.ExecuteReader())
        {
            NotifID = Convert.ToInt32(cm.Parameters["@notifID"].Value);
        }
        if (NotifID == 0)
        {
            Label1.Text = "" + NotifID;
        }
        else
        {
            SqlCommand cmd = new SqlCommand("updateSeen", cnn);
            cmd.Parameters.Add(new SqlParameter("@ID", NotifID));
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader rdr = cmd.ExecuteReader();
            cnn.Close();
            cnn.Open();
            String query = "Show_Notification " + ID;
            SqlDataAdapter sqlData = new SqlDataAdapter(query, cnn);
            sqlData.GetFillParameters();
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            view.DataSource = dataTable;
            view.DataBind();
        }
        cnn.Close();

    }
}