using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

    public partial class UserProfile : System.Web.UI.Page
    {
        public void searchOrigContent(object sender, EventArgs args)
        {
            string type_or_cat;
            type_or_cat = sorigcont.Text;
        string connetionString;
        SqlConnection cnn;

        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connetionString);

        cnn.Open();
            SqlCommand cmd = new SqlCommand("Original_Content_Search", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@typename", type_or_cat));
            cmd.Parameters.Add(new SqlParameter("@categoryname", type_or_cat));
            String s = Request.QueryString["user_id"];
            SqlDataReader dataReader;
            String Output = " ";
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Output = Output + " ID: " + dataReader.GetValue(0) + ", Content_manager_id: " +
               dataReader.GetValue(1) + ", reviewer_id: " +
                dataReader.GetValue(2) + ", review_status: " +
               dataReader.GetValue(3) +
                ", filter_status: " + dataReader.GetValue(4) + ", rating: " +
                dataReader.GetValue(5) + ", link: " + dataReader.GetValue(7) +
                ", uploaded at: " + dataReader.GetValue(8) + ", contributor_id: " +
                dataReader.GetValue(9) + ", category_type: " +
               dataReader.GetValue(10) +
                ", subcategory: " + dataReader.GetValue(11) + ", content_type: " +
                dataReader.GetValue(12) + "</br>";
            }
            dataReader.Close();
            cnn.Close();
            OrigCont.Text = Output;
        }
        public void searchContributor(object sender, EventArgs args)
        {
            string name;
            name = searchCont.Text;
        string connetionString;
        SqlConnection cnn;

        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connetionString);

        cnn.Open();
            SqlCommand cmd = new SqlCommand("Contributor_Search", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fullname", name));
            String s = Request.QueryString["user_id"];
            SqlDataReader dataReader;
            String Output = " ";
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Output = Output + " ID: " + dataReader.GetValue(0) + ", years of experience: " +
               dataReader.GetValue(1) + ", notified_id: " +
                dataReader.GetValue(2) + ", specialization: " +
               dataReader.GetValue(3) +
                ", portfolio_link: " + dataReader.GetValue(4) + ", email: " +
                dataReader.GetValue(6) + ", deactivation status: " +
               dataReader.GetValue(7) +
                ", deactivation date: " + dataReader.GetValue(8) + ", first name: "
               +
                dataReader.GetValue(9) + ", middle name: " +
               dataReader.GetValue(10) +
                ", last name: " + dataReader.GetValue(11) + ", birth date: " +
                dataReader.GetValue(12) + ", age" +
               dataReader.GetValue(13) + "</br>";
            }
            dataReader.Close();
            cnn.Close();
            contributor.Text = Output;
        }
        public void showAllContributor(object sender, EventArgs args)
        {
        string connetionString;
        SqlConnection cnn;

        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connetionString);

        cnn.Open();
            SqlCommand cmd = new SqlCommand("Order_Contributor", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            String s = Request.QueryString["user_id"];
            SqlDataReader dataReader;
            String Output = " ";
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Output = Output + " ID: " + dataReader.GetValue(0) + ", years of experience: " +
               dataReader.GetValue(1) + ", notified_id: " +
                dataReader.GetValue(2) + ", specialization: " +
               dataReader.GetValue(3) +
                ", portfolio_link: " + dataReader.GetValue(4) + "</br>";
            }
            dataReader.Close();
            cnn.Close();
            contributors.Text = Output;
        }
        public void searchOrigContent2(object sender, EventArgs args)
        {
            string name;
            name = contributorname.Text;
            if (name != "")
            {
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);

            cnn.Open();
                SqlCommand cm = new SqlCommand("existCont", cnn);
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add(new SqlParameter("@name", name));
                cm.Parameters.Add("@out", System.Data.SqlDbType.Bit).Direction =
               System.Data.ParameterDirection.Output;
                bool flag = false;
                using (SqlDataReader rdr = cm.ExecuteReader())
                {
                    flag = Convert.ToBoolean(cm.Parameters["@out"].Value);
                }
                if (flag == true)
                {
                    //SqlCommand cmd = new SqlCommand("getContributorID", cnn);
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("@name", name));
                    //cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                    //int user_id = 0;
                    //using (SqlDataReader rdr = cmd.ExecuteReader())
                    //{
                    // user_id = Convert.ToInt32(cmd.Parameters["@id"].Value);
                    //}
                    SqlCommand cmd2 = new SqlCommand("Show_Original_Content2", cnn);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd2.Parameters.Add(new SqlParameter("@name", name));
                    SqlDataReader dataReader;
                    String Output = " ";
                    dataReader = cmd2.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Output = Output + " ID: " + dataReader.GetValue(0) + ", content manager id: " +
                       dataReader.GetValue(1) + ", reviewer id: " +
                        dataReader.GetValue(2) + ", review status: " +
                       dataReader.GetValue(3) +
                        ", filter status: " + dataReader.GetValue(4) + ", rating: " +
                       dataReader.GetValue(5) + ", link: " + dataReader.GetValue(7) + ", uploaded at: " +
                       dataReader.GetValue(8) +
                        ", contributor id: " + dataReader.GetValue(9) + ", category type: " + dataReader.GetValue(10) + ", subcategory: " + dataReader.GetValue(11) + ", type: " +
                   dataReader.GetValue(12) + ", years of experience:" + dataReader.GetValue(14) + ", notified id:" + dataReader.GetValue(15) + ", specialization: " + dataReader.GetValue(16) + ",portfolio_link: " + dataReader.GetValue(17) +
                    ", contributor mail: " + dataReader.GetValue(19) + ", contributor's name: "+ dataReader.GetValue(22)+" "+ dataReader.GetValue(23)+ " "+ dataReader.GetValue(24) + ", age: " + dataReader.GetValue(26) + "</br>";
                    }
                    dataReader.Close();
                    cnn.Close();
                    cont.Text = Output;
                }
                else
                {
                    cont.Text = "No contributor with this name";
                }
            }
            else
            {
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);

            cnn.Open();
                SqlCommand cmd2 = new SqlCommand("Show_Original_Content2", cnn);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.Add(new SqlParameter("@name", DBNull.Value));
                SqlDataReader dataReader;
                String Output = " ";
                dataReader = cmd2.ExecuteReader();
                while (dataReader.Read())
                {
                    Output = Output + " ID: " + dataReader.GetValue(0) + ", content manager id: " +
                   dataReader.GetValue(1) + ", reviewer id: " +
                    dataReader.GetValue(2) + ", review status: " +
                   dataReader.GetValue(3) +
                    ", filter status: " + dataReader.GetValue(4) + ", rating: " +
                   dataReader.GetValue(5) + ", link: " + dataReader.GetValue(7) + ", uploaded at: " +
                   dataReader.GetValue(8) +
                    ", contributor id: " + dataReader.GetValue(9) + ", category  type: " + dataReader.GetValue(10) + ", subcategory: " + dataReader.GetValue(11) + ", type: " +    dataReader.GetValue(12) +
                ", years of experience:" + dataReader.GetValue(14) + ",notified id:" + dataReader.GetValue(15) + ", specialization: " + dataReader.GetValue(16) + ",portfolio_link: " + dataReader.GetValue(17) +
                ", contributor mail: " + dataReader.GetValue(19) + ",contributor's name: " + dataReader.GetValue(22) + " " + dataReader.GetValue(23) + " " +dataReader.GetValue(24) + ", age: " + dataReader.GetValue(26) + "</br>";
                }
                dataReader.Close();
                cnn.Close();
                cont.Text = Output;
            }
        }
        public void show(object sender, EventArgs args)
        {
            if (Session["ID"] != null)
            {
                int id = Convert.ToInt32(Session["ID"]);
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);

            cnn.Open();
                SqlCommand cmd = new SqlCommand("Show_Profile", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@user_id", id));
                cmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar, 50).Direction =
               System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 50).Direction =
               System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@firstname", System.Data.SqlDbType.VarChar, 50).Direction =
               System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@middlename", System.Data.SqlDbType.VarChar, 50).Direction =
               System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@lastname", System.Data.SqlDbType.VarChar, 50).Direction =
               System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@birth_date", System.Data.SqlDbType.Date).Direction =
               System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@working_place_name", System.Data.SqlDbType.VarChar,
               50).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@working_place_type", System.Data.SqlDbType.VarChar,
               50).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@wokring_place_description", System.Data.SqlDbType.VarChar,
               50).Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@specilization", System.Data.SqlDbType.VarChar, 50).Direction =
               System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@portofolio_link", System.Data.SqlDbType.VarChar, 50).Direction
               = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@years_experience", System.Data.SqlDbType.Int).Direction =
               System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@hire_date", System.Data.SqlDbType.Date).Direction =
               System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@working_hours", System.Data.SqlDbType.Int).Direction =
               System.Data.ParameterDirection.Output;
                cmd.Parameters.Add("@payment_rate", System.Data.SqlDbType.Decimal).Direction =
               System.Data.ParameterDirection.Output;
                string email = "";
                string password = "";
                string firstname = "";
                string middlename = "";
                string lastname = "";
                DateTime birthdate;
                string working_place_name = "";
                string working_place_type = "";
                string wokring_place_description = "";
                string specilization = "";
                string portfolio_link = "";
                int years_experience;
                DateTime hire_date;
                int working_hours;
                double payment_rate;
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    email = Convert.ToString(cmd.Parameters["@email"].Value);
                    password = Convert.ToString(cmd.Parameters["@password"].Value);
                    firstname = Convert.ToString(cmd.Parameters["@firstname"].Value);
                    middlename = Convert.ToString(cmd.Parameters["@middlename"].Value);
                    lastname = Convert.ToString(cmd.Parameters["@lastname"].Value);
                    if (cmd.Parameters["@birth_date"].Value != DBNull.Value)
                        birthdate = Convert.ToDateTime(cmd.Parameters["@birth_date"].Value);
                    else
                        birthdate = DateTime.Now;
                    if (cmd.Parameters["@working_place_name"].Value != DBNull.Value)
                        working_place_name =
                       Convert.ToString(cmd.Parameters["@working_place_name"].Value);
                    else
                        working_place_name = "-";
                    if (cmd.Parameters["@working_place_type"].Value != DBNull.Value)
                        working_place_type =
                       Convert.ToString(cmd.Parameters["@working_place_type"].Value);
                    else
                        working_place_type = "-";
                    if (cmd.Parameters["@wokring_place_description"].Value != DBNull.Value)
                        wokring_place_description =
                       Convert.ToString(cmd.Parameters["@wokring_place_description"].Value);
                    else
                        wokring_place_description = "-";
                    if (cmd.Parameters["@specilization"].Value != DBNull.Value)
                        specilization = Convert.ToString(cmd.Parameters["@specilization"].Value);
                    else
                        specilization = "-";
                    if (cmd.Parameters["@portofolio_link"].Value != DBNull.Value)
                        portfolio_link = Convert.ToString(cmd.Parameters["@portofolio_link"].Value);
                    else
                        portfolio_link = "-";
                    if (cmd.Parameters["@years_experience"].Value != DBNull.Value)
                        years_experience =
                       Convert.ToInt32(cmd.Parameters["@years_experience"].Value);
                    else
                        years_experience = 0;
                    if (cmd.Parameters["@hire_date"].Value != DBNull.Value)
                        hire_date = Convert.ToDateTime(cmd.Parameters["hire_date"].Value);
                    else
                        hire_date = DateTime.Now;
                    if (cmd.Parameters["@working_hours"].Value != DBNull.Value)
                        working_hours = Convert.ToInt32(cmd.Parameters["@working_hours"].Value);
                    else
                        working_hours = 0;
                    if (cmd.Parameters["@payment_rate"].Value != DBNull.Value)
                        payment_rate = Convert.ToDouble(cmd.Parameters["@payment_rate"].Value);
                    else
                        payment_rate = 0.0;
                }
                String Output = " ";
                if (getUserType() == "Viewer")
                {
                    Output = Output + " email: " + email + ", password: " + password + ", first name: " +
                    firstname + ", middle name: " + middlename +
                    ", last name: " + lastname + ", birth date: " + birthdate + ", working place: " +
                   working_place_name + ", working place type: " + working_place_type +
                    ", working place description: " + wokring_place_description + "</br>";
                }
                else
                {
                    if (getUserType() == "Contributor")
                    {
                        Output = Output + " email: " + email + ", password: " + password + ", first name: " +
                        firstname + ", middle name: " + middlename +
                        ", last name: " + lastname + ", birth date: " + birthdate + ", specialization: " +
                       specilization + ", portofolio_link: " + portfolio_link + ", years of experience: " + years_experience +
                        "</br>";
                    }
                    else
                    {
                    Output = Output + " email: " + email + ", password: " + password + ", first name: " + firstname + ", middle name: " + middlename +", last name: " + lastname + ", birth date: " + birthdate + ", hire date:"+hire_date+", working hours: "+working_hours+", payment rate: "+payment_rate+"</br>";
                }
                }
                cnn.Close();
                info.Text = Output;
            }
        }
        public void edit(object sender, EventArgs args)
        {
            Response.Redirect("Edit.aspx");
        }
        public void deac(object sender, EventArgs args)
        {
            int id = Convert.ToInt32(Session["ID"]);
        string connetionString;
        SqlConnection cnn;

        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connetionString);

        cnn.Open();
            SqlCommand cmd = new SqlCommand("Deactivate_Profile", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@user_id", id));
            SqlDataReader rdr = cmd.ExecuteReader();
            Response.Redirect("Default.aspx");
        }
        public string getUserType()
        {
            int id = Convert.ToInt32(Session["ID"]);
        string connetionString;
        SqlConnection cnn;

        connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        cnn = new SqlConnection(connetionString);

        cnn.Open();
            SqlCommand cmd = new SqlCommand("getTypeofUser", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add("@type", System.Data.SqlDbType.VarChar, 50).Direction =
           System.Data.ParameterDirection.Output;
            string t;
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                t = Convert.ToString(cmd.Parameters["@type"].Value);
            }
            return t;
        }
        public void cevent(object sender, EventArgs args)
        {
            Response.Redirect("ViewerPart1.aspx");
        }
        public void applyEx(object sender, EventArgs args)
        {
            Response.Redirect("ViewierPart2.aspx");
        }
        public void applyNew(object sender, EventArgs args)
        {
            Response.Redirect("ViewerPart3.aspx");
        }
        public void deleteReq(object sender, EventArgs args)
        {
            Response.Redirect("ViewerPart4.aspx");
        }
        
        public void review(object sender, EventArgs args)
        {
            Response.Redirect("ViewerPart5.aspx");
        }
        public void comment(object sender, EventArgs args)
        {
            Response.Redirect("ViewerPart6.aspx");
        }
        public void editcomment(object sender, EventArgs args)
        {
            Response.Redirect("ViewerPart7-1.aspx");
        }
    public void deletecomment(object sender, EventArgs args)
    {
        Response.Redirect("ViewerPart7-2.aspx");
    }
        public void createAd(object sender, EventArgs args)
        {
            Response.Redirect("ViewerPart8.aspx");
        }
        public void editAd(object sender, EventArgs args)
        {
            Response.Redirect("ViewerPart9-1.aspx");
        }
    public void deleteAd(object sender, EventArgs args)
    {
        Response.Redirect("ViewerPart9-2.aspx");
    }
    public void showNewC(object sender, EventArgs args)
        {
            Response.Redirect("ViewerPart10.aspx");
        }
    public void fil(object sender, EventArgs args)
    {
        Response.Redirect("Filter.aspx");
    }
    public void afil(object sender, EventArgs args)
    {
        Response.Redirect("AcceptFiltered.aspx");
    }
    public void cconttype(object sender, EventArgs args)
    {
        Response.Redirect("CreateContentType.aspx");
    }
    public void getEXCont(object sender, EventArgs args)
    {
        Response.Redirect("GetExistingRequests.aspx");
    }
    public void wptr(object sender, EventArgs args)
    {
        Response.Redirect("workingPlaceTypeRequests.aspx");
    }
    public void showNot(object sender, EventArgs args)
    {
        Response.Redirect("ShowNotifications.aspx");
    }
    public void delcom(object sender, EventArgs args)
    {
        Response.Redirect("DeleteComment.aspx");
    }
    public void delcont(object sender, EventArgs args)
    {
        Response.Redirect("DeleteContent.aspx");
    }
    public void createcat(object sender, EventArgs args)
    {
        Response.Redirect("CatCreation.aspx");
    }
    public void showCont(object sender, EventArgs args)
    {
        Response.Redirect("BestContributors.aspx");
    }
    public void upOrgCont(object sender, EventArgs args)
    {
        Response.Redirect("UploadOriginalContent.aspx");
    }
    public void upNewCont(object sender, EventArgs args)
    {
        Response.Redirect("UploadNewContent.aspx");
    }
    public void RecNewReq(object sender, EventArgs args)
    {
        Response.Redirect("ReceiveNewRequests.aspx");
    }
    public void Messages(object sender, EventArgs args)
    {
        Response.Redirect("Messages.aspx");
    }
    public void DelCont(object sender, EventArgs args)
    {
        Response.Redirect("Delete_Content.aspx");
    }
    public void ShowNOTIFICATION(object sender, EventArgs args)
    {
        Response.Redirect("Show_Notifications.aspx");
    }
    public void SHOWev(object sender, EventArgs args)
    {
        Response.Redirect("Show_Events.aspx");
    }
    public void SHOWad(object sender, EventArgs args)
    {
        Response.Redirect("Show_Advertisement.aspx");
    }
}
