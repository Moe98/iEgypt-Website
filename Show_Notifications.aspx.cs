using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Show_Notifications : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        int ID = Convert.ToInt32(Session["ID"]);
        int NotifID = 0;
        SqlConnection cnn;
        string connectionString;
        connectionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connectionString);
        cnn.Open();
        SqlCommand cm = new SqlCommand("getNotifiedIDCont", cnn);
        cm.CommandType = System.Data.CommandType.StoredProcedure;
        cm.Parameters.Add(new SqlParameter("@ID", ID));
        cm.Parameters.Add("@notifID", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;

        using (SqlDataReader rdrid = cm.ExecuteReader())
        {
            NotifID = Convert.ToInt32(cm.Parameters["@notifID"].Value);

        }
        if (NotifID != 0)
        {


            SqlCommand cmd = new SqlCommand("updateSeen", cnn);
            cmd.Parameters.Add(new SqlParameter("@ID", ID));
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Close();
            SqlDataAdapter sqlData = new SqlDataAdapter("Show_NotificationContributor", cnn);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@user_id", ID);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            notifications.DataSource = dataTable;
            notifications.DataBind();
            cnn.Close();

        }


    }

}
