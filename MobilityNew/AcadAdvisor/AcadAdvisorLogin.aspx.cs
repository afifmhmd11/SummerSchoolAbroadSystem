using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AcadAdvisor_AcadAdvisorLogin : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAALogin_Click(object sender, EventArgs e)
    {
        string smatric = txtboxSUsername.Text;
        string ic = txtboxSPassword.Text;

        con.Open();

        string UGlogin = "SELECT * FROM STAFF WHERE SMATRIC = '" + smatric + "' AND  IC ='" + ic + "'";
        SqlCommand cmd = new SqlCommand(UGlogin, con);
        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();

        if (dr.HasRows)
        {

            Session["SMATRIC"] = dr["SMATRIC"].ToString();
            Response.Redirect("Dashboard.aspx");
        }
        else
        {
            string script = "alert(Maaf)";
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", script, true);

        }

        con.Close();
    }
}