using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class UGStudent_Home : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        con.Open();

        using (SqlCommand cmd1 = new SqlCommand("SELECT * FROM APPLICATION WHERE MATRIC = '" + Session["MATRIC"].ToString() + "'", con))
        {
            using (SqlDataReader reader = cmd1.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Close();

                    
                    string getApp = "SELECT APPID FROM APPLICATION WHERE MATRIC = '" + Session["MATRIC"].ToString() + "'";
                    SqlCommand cmd2 = new SqlCommand(getApp, con);
                    SqlDataReader dr1 = cmd2.ExecuteReader();
                    dr1.Read();

                    Session["APPID"] = dr1["APPID"].ToString();

                    con.Close();

                    Response.Redirect("frmProgramme.aspx");
                }
                Response.Redirect("frmProgramme.aspx");
            }
        }

        
    }
}