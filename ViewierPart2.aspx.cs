using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewierPart2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int open_id = Convert.ToInt32(Session["ID"]);
        object id5 = Session["ID"];
        string connectionString;
        connectionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        cnn.Open();
        string query = "SELECT * FROM Original_Content OC INNER JOIN Content C ON OC.ID=C.ID INNER JOIN Contributor CC ON C.contributor_id=CC.ID INNER JOIN [User] U ON CC.ID=U.ID WHERE rating>=4";
        SqlDataAdapter sqlData = new SqlDataAdapter(query, cnn);
        DataTable dataTable = new DataTable();
        sqlData.Fill(dataTable);
        view.DataSource = dataTable;
        view.DataBind();
        // cnn.Close();
    }
    public void applyer(object sender, EventArgs args)
    {
        string org_cont_id; //we initiate a string to take in what the user writes in the frontend
        org_cont_id = ""+Convert.ToInt32((sender as LinkButton).CommandArgument); //it's done through this part


        string connetionString; //connection
        SqlConnection cnn; //connection

        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString; //this is to initiate the connection with the database through the constr string however it changes depending on what you named the conneciton

        //connetionString = @"Data Source=localhost;Initial Catalog=GUC_WEB ;User ID=sa;Password=reallyStrongxPwd123"; //ignore this

        cnn = new SqlConnection(connetionString); //connection
        int open_id = Convert.ToInt32(Session["ID"]);   //this is for my part [Viewer] because the [User] part isn't done yet
        cnn.Open(); //you open the connection
        if (org_cont_id == null) //if the user clicks the button without filling in any info
        {
            testing.Text = "Please fill in the boxes appropriately";
        }
        else
        {
            testing.Text = "";
            SqlCommand cmd = new SqlCommand("Apply_Existing_Request", cnn); //we specify which Procedure we will be connected to
            cmd.CommandType = System.Data.CommandType.StoredProcedure; //we tell it that the SqlCommand cmd is of type stored procedure
            cmd.Parameters.Add(new SqlParameter("@original_content_id", org_cont_id)); //we add parameters that we will pass to the stored procedure
            cmd.Parameters.Add(new SqlParameter("@viewer_id", open_id)); //change when connection is done
            SqlDataReader rdr = cmd.ExecuteReader(); //check that it executes the procedure //it executes the procedure
            cnn.Close(); //we close and open the connection after executing any procedure
        }
    }

    protected void view_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}