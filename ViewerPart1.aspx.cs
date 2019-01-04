using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Linq;
using System.Web.UI.WebControls;

using System;
using System.Web;
using System.Web.UI;

using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Viewer : System.Web.UI.Page
{
    // private object location;
    static int event_id;
    //handle if any box is empty
    public void addphotos(object sender, EventArgs args)
    {
        string photosLink = link.Text;
        string connetionString;
        SqlConnection cnn;
        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        if (photosLink == "")
        {
            testing.Text = "Please insert a link!";
        }
        else if (event_id == 0)
        {
            testing.Text = "Please create an event first!";
        }
        else
        {
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Viewer_Upload_Event_Photo", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@event_id", event_id));
            cmd.Parameters.Add(new SqlParameter("@link", photosLink));
            testing.Text = "";
            try
            {
                SqlDataReader rdr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                testing.Text = "Dude seriously don't insert the same link twice...";
            }
            cnn.Close();
        }

    }
    public void addvideos(object sender, EventArgs args)
    {
        string videosLink = link.Text;
        string connetionString;
        SqlConnection cnn;
        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        if (videosLink == "")
        {
            testing.Text = "Please insert a link!";
        }
        else if (event_id == 0)
        {
            testing.Text = "Please create an event first!";
        }
        else
        {
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Viewer_Upload_Event_Video", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@event_id", event_id));
            cmd.Parameters.Add(new SqlParameter("@link", videosLink));
            testing.Text = "";
            try
            {
                SqlDataReader rdr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                testing.Text = "Dude seriously don't insert the same link twice...";
            }
            cnn.Close();
        }

    }
    public void eventnoad(object sender, EventArgs args)
{
//string linkphotos1;
//string linkvideos1;
string city1;
string event_date_time1;
string description1;
string entertainer1;
string location1;


// linkphotos1 = link.Text;
//linkvideos1 = linkvideos.Text;
city1 = city.Text;
event_date_time1 = eventdate.Text;
description1 = description.Text;
entertainer1 = entertainer.Text;
location1 = location.Text;



string connetionString;
SqlConnection cnn;

connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        //connetionString = @"Data Source=localhost;Initial Catalog=GUC_WEB ;User ID=sa;Password=reallyStrongPwd123";
        if (city1 == "" || event_date_time1 == "" || description1 == "" || entertainer1 == "" || location1 == "")
        {
            testing.Text = "Please fill in the boxes appropriately";
        }
        else {
            testing.Text = "";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            int open_id = Convert.ToInt32(Session["ID"]);

            SqlCommand cmd = new SqlCommand("Viewer_Create_Event", cnn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@city", city1));
            cmd.Parameters.Add(new SqlParameter("@event_date_time", event_date_time1));
            cmd.Parameters.Add(new SqlParameter("@description", description1));
            cmd.Parameters.Add(new SqlParameter("@entertainer", entertainer1));
            cmd.Parameters.Add(new SqlParameter("@viewer_id", open_id));  //change when login is done
            cmd.Parameters.Add(new SqlParameter("@location", location1));

            cmd.Parameters.Add("@event_id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;

            // execute the command
            try {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    event_id = Convert.ToInt32(cmd.Parameters["@event_id"].Value);
                }
            }
            catch(Exception ex)
            {
                testing.Text = "Insert a proper date";
            }

   //System.Threading.Thread.Sleep(5);
/*   SqlCommand cmd2 = new SqlCommand("Viewer_Upload_Event_Photo", cnn);
   cmd2.CommandType = System.Data.CommandType.StoredProcedure;
   if (linkphotos1 != null)
   {
       // testing.Text = "Test "+ event_id;
       cmd2.Parameters.Add(new SqlParameter("@event_id", event_id));
       cmd2.Parameters.Add(new SqlParameter("@link", linkphotos1));
       cnn.Close();
       cnn.Open();
       SqlDataReader rdr2 = cmd2.ExecuteReader();

       //check if this executes the method
   }
   SqlCommand cmd3 = new SqlCommand("Viewer_Upload_Event_Video", cnn);
   cmd3.CommandType = System.Data.CommandType.StoredProcedure;
   if (linkvideos1 != null)
   {
       cmd3.Parameters.Add(new SqlParameter("@event_id", event_id));
       cmd3.Parameters.Add(new SqlParameter("@link", linkvideos1));
       cnn.Close();
       cnn.Open();
       SqlDataReader rdr3 = cmd3.ExecuteReader();

       //check if this executes the method
   } */
            cnn.Close();
        }
    }


    public void eventwithad(object sender, EventArgs args)
    {
     //   string linkphotos2;
      //  string linkvideos2;
        string city2;
        string event_date_time2;
        string description2;
        string entertainer2;
        string location2;


     //   linkphotos2 = link.Text;
     //   linkvideos2 = linkvideos.Text;
        city2 = city.Text;
        event_date_time2 = eventdate.Text;
        description2 = description.Text;
        entertainer2 = entertainer.Text;
        location2 = location.Text;

        // testing.Text = "" + linkphotos2;
        if (city2 == "" || event_date_time2 == "" || description2 == "" || entertainer2 == "" || location2 == "")
        {
            testing.Text = "Please fill in the boxes appropriately";
        }
        else
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            //connetionString = @"Data Source=localhost;Initial Catalog=GUC_WEB ;User ID=sa;Password=reallyStrongPwd123";

            cnn = new SqlConnection(connetionString);

            cnn.Open();

            SqlCommand cmd = new SqlCommand("Viewer_Create_Event", cnn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int open_id = Convert.ToInt32(Session["ID"]);
            cmd.Parameters.Add(new SqlParameter("@city", city2));
            cmd.Parameters.Add(new SqlParameter("@event_date_time", event_date_time2));
            cmd.Parameters.Add(new SqlParameter("@description", description2));
            cmd.Parameters.Add(new SqlParameter("@entertainer", entertainer2));
            cmd.Parameters.Add(new SqlParameter("@viewer_id", open_id));  //change when login is done
            cmd.Parameters.Add(new SqlParameter("@location", location2));

            cmd.Parameters.Add("@event_id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;

            // execute the command
            try
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    event_id = Convert.ToInt32(cmd.Parameters["@event_id"].Value);
                }
            

            /*     SqlCommand cmd2 = new SqlCommand("Viewer_Upload_Event_Photo", cnn);
                 cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                 if (linkphotos2 != null)
                 {
                     cmd2.Parameters.Add(new SqlParameter("@event_id", event_id));
                     cmd2.Parameters.Add(new SqlParameter("@link", linkphotos2));
                     cnn.Close();
                     cnn.Open();
                     using (SqlDataReader rdr2 = cmd2.ExecuteReader())
                     {
                     }//check if this executes the method
                 }
                 SqlCommand cmd3 = new SqlCommand("Viewer_Upload_Event_Video", cnn);
                 cmd3.CommandType = System.Data.CommandType.StoredProcedure;
                 if (linkvideos2 != null)
                 {
                     cmd3.Parameters.Add(new SqlParameter("@event_id", event_id));
                     cmd3.Parameters.Add(new SqlParameter("@link", linkvideos2));
                     cnn.Close();
                     cnn.Open();
                     using (SqlDataReader rdr3 = cmd3.ExecuteReader())
                     {
                     }//check if this executes the method
                 }
                 */
            SqlCommand cmd4 = new SqlCommand("Viewer_Create_Ad_From_Event", cnn);
            cmd4.CommandType = System.Data.CommandType.StoredProcedure;
            cmd4.Parameters.Add(new SqlParameter("@event_id", event_id));
            cnn.Close();
            cnn.Open();
            SqlDataReader rdr4 = cmd4.ExecuteReader(); //Check if this executes it
        }
        catch(Exception ex)
        {
            testing.Text = "Insert a proper date...";
        }
        cnn.Close();
        }
    }
}