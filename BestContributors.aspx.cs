using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BestContributors : System.Web.UI.Page
{
    int c_ID;
    int r_ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        string connetionString; //connection
        SqlConnection cnn; //connection
        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connetionString);
        cnn.Open();

        SqlDataAdapter sqlData = new SqlDataAdapter("Show_Possible_Contributors", cnn);
        DataTable dataTable = new DataTable();
        sqlData.Fill(dataTable);
        view.DataSource = dataTable;
        view.DataBind();

        SqlDataAdapter sqlData2 = new SqlDataAdapter("SELECT id,accept_status,specified,information,viewer_id,notif_obj_id FROM New_Request WHERE contributor_id is NULL", cnn);
        DataTable dataTable2 = new DataTable();
        sqlData2.Fill(dataTable2);
        view2.DataSource = dataTable2;
        view2.DataBind();
        cnn.Close();
    }

    protected void assign(object sender, EventArgs e)
    {
        string connetionString; //connection
        SqlConnection cnn; //connection
        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connetionString);
        cnn.Open();
       
        if (C_ID.Text == "" || R_ID.Text == "")
        {
            C_ID.Text = "Select Contributor";
            R_ID.Text = "Select Request";
        }
        else
        {
            if(!(C_ID.Text == "Select Contributor" || R_ID.Text == "Select Request"))
            {
                c_ID = Convert.ToInt32(C_ID.Text);
                r_ID = Convert.ToInt32(R_ID.Text);
                SqlCommand cmd = new SqlCommand("Assign_Contributor_Request", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@contributor_id", c_ID));
                cmd.Parameters.Add(new SqlParameter("@new_request_id", r_ID));
                SqlDataReader rdr = cmd.ExecuteReader();
            }

        }
        cnn.Close();
        Page_Load(null, null);


    }

    protected void setC(object sender, EventArgs e)
    {
        c_ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
        C_ID.Text = "" + c_ID;
        string connetionString; //connection
        SqlConnection cnn; //connection
        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connetionString);
        cnn.Open();

        SqlDataAdapter sqlData3 = new SqlDataAdapter("SELECT * FROM [User] WHERE " + c_ID + " = ID", cnn);
        DataTable dataTable3 = new DataTable();
        sqlData3.Fill(dataTable3);
        view3.DataSource = dataTable3;
        view3.DataBind();



    }


    protected void setR(object sender, EventArgs e)
    {
        r_ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
        R_ID.Text = "" + r_ID;

    }
}