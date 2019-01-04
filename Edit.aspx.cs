using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

    public partial class Edit : System.Web.UI.Page
    {
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
        public void editMethod(object sender, EventArgs args)
        {
            string e;
            string p;
            string f_name;
            string m_name;
            string l_name;
            string b_date;
            string wpn;
            string wpt;
            string wpd;
            string sp;
            string port_link;
            int yoXP;
            string h_date;
            int w_Hours;
            double paymentRate;
            int id = Convert.ToInt32(Session["ID"]);
            e = email.Text;
            p = password.Text;
            f_name = first.Text;
            m_name = middle.Text;
            l_name = last.Text;
            b_date = birth.Text;
            wpn = wpName.Text;
            wpt = wpType.Text;
            wpd = wpDesc.Text;
            sp = special.Text;
            port_link = portfolio.Text;
            if (XP.Text != "")
                yoXP = Convert.ToInt32(XP.Text);
            else
                yoXP = 0;
            h_date = hire.Text;
            if (wHours.Text != "")
                w_Hours = Convert.ToInt32(wHours.Text);
            else
                w_Hours = 0;
            if (pRate.Text != "")
                paymentRate = Convert.ToDouble(pRate.Text);
            else
                paymentRate = 0;
            if (e == "" || p == "" || f_name == "" || m_name == "" || l_name == "")
            {
                display_text2.Text = "Please fill in all info";
            }
            else
            {
            string connetionString;
            SqlConnection cnn;

            connetionString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
                SqlCommand cmd = new SqlCommand("searchMail", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@email", e));
                cmd.Parameters.Add("@out", System.Data.SqlDbType.Bit).Direction =
               System.Data.ParameterDirection.Output;
                bool flag = false;
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    flag = Convert.ToBoolean(cmd.Parameters["@out"].Value);
                }
                if (flag == false)
                {
                try
                {
                    SqlCommand cm = new SqlCommand("Edit_Profile", cnn);
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.Add(new SqlParameter("@user_id", id));
                    cm.Parameters.Add(new SqlParameter("@email", e));
                    cm.Parameters.Add(new SqlParameter("@password", p));
                    cm.Parameters.Add(new SqlParameter("@firstname", f_name));
                    cm.Parameters.Add(new SqlParameter("@middlename", m_name));
                    cm.Parameters.Add(new SqlParameter("@lastname", l_name));
                    cm.Parameters.Add(new SqlParameter("@birth_date", b_date));
                    cm.Parameters.Add(new SqlParameter("@working_place_name", wpn));
                    cm.Parameters.Add(new SqlParameter("@working_place_type", wpt));
                    cm.Parameters.Add(new SqlParameter("@wokring_place_description", wpd));
                    cm.Parameters.Add(new SqlParameter("@specilization", sp));
                    cm.Parameters.Add(new SqlParameter("@portofolio_link", port_link));
                    cm.Parameters.Add(new SqlParameter("@years_experience", yoXP));
                    cm.Parameters.Add(new SqlParameter("@hire_date", h_date));
                    cm.Parameters.Add(new SqlParameter("@working_hours", w_Hours));
                    cm.Parameters.Add(new SqlParameter("@payment_rate", paymentRate));
                    SqlDataReader rdr = cm.ExecuteReader();
                    cnn.Close();
                    Response.Redirect("UserProfile.aspx?user_id=" + id);
                } catch(Exception ex)
                {
                    display_text2.Text = "Wrong Date Entry";
                }
                }
                else
                {
                    display_text2.Text = "This mail is already in our DB";
                }
            }
        }
    }