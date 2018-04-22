using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UGStudent_frmProgramme : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["MATRIC"] != null)
        {
            if (Session["StartDate"] != null)
            {
                txtboxStartDate.Text = Session["StartDate"].ToString();
                txtboxEndDate.Text = Session["EndDate"].ToString();
                txtboxUName.Text = Session["UniversityName"].ToString();
                drpdwnCountry.Text = Session["ProgramCountry"].ToString();
            }
        }
        else
        {
            Response.Redirect("UGLogin.aspx");
        }
    }

    protected void btnSave1_Click(object sender, EventArgs e)
    {
        Session["StartDate"] = txtboxStartDate.Text;
        Session["EndDate"] = txtboxEndDate.Text;
        Session["UniversityName"] = txtboxUName.Text;
        Session["ProgramCountry"] = drpdwnCountry.Text;
       
        con.Open();

        using (SqlCommand cmd1 = new SqlCommand("SELECT * FROM PROGRAMME WHERE MATRIC = '"+ Session["MATRIC"].ToString()+"'", con))
        {
            using (SqlDataReader reader = cmd1.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    reader.Close();

                    string insert = "INSERT INTO PROGRAMME(UNIVERSITY, COUNTRY, STARTDATE, ENDDATE, TYPE, PROGNAME, MATRIC) VALUES(@uni,@country,@startdate,@endate,@type,@progname,@matric)";
                    SqlCommand cmdInsert = new SqlCommand(insert, con);
                    cmdInsert.Parameters.AddWithValue("@uni", txtboxUName.Text);
                    cmdInsert.Parameters.AddWithValue("@country", drpdwnCountry.Text);
                    cmdInsert.Parameters.AddWithValue("@startdate", Convert.ToDateTime(txtboxStartDate.Text));
                    cmdInsert.Parameters.AddWithValue("@endate", Convert.ToDateTime(txtboxStartDate.Text));
                    cmdInsert.Parameters.AddWithValue("@type", "SUMMER SCHOOL");
                    cmdInsert.Parameters.AddWithValue("@progname", "SUMMER SCHOOL");
                    cmdInsert.Parameters.AddWithValue("@matric", Session["MATRIC"].ToString());
                    cmdInsert.ExecuteNonQuery();


                    string appid = "SELECT PROGID FROM PROGRAMME WHERE MATRIC = '" + Session["MATRIC"].ToString() + "'";
                    SqlCommand cmd = new SqlCommand(appid, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    string PID = dr["PROGID"].ToString();
                    dr.Close();

                    string insertApp = "INSERT INTO APPLICATION(MATRIC, STATUS, PROGID) VALUES(@matric,@status,@progid)";
                    SqlCommand cmdinsertApp = new SqlCommand(insertApp, con);
                    cmdinsertApp.Parameters.AddWithValue("@matric", Session["MATRIC"].ToString());
                    cmdinsertApp.Parameters.AddWithValue("@status", "Draft");
                    cmdinsertApp.Parameters.AddWithValue("@progid", PID);
                    cmdinsertApp.ExecuteNonQuery();

                    Response.Redirect("frmPersonal.aspx");
                }
                else
                {

                    Response.Redirect("frmPersonal.aspx");
                }
            } // reader closed and disposed up here

        } // command disposed here

        con.Close();



    }
    
        
}