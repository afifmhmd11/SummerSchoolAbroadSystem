using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class UGStudent_UGLogin : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
   
    protected void Page_Load(object sender, EventArgs e)
    {
    
    }

    protected void btnUGLogin_Click(object sender, EventArgs e)
    {
        string matric = txtboxUGUsername.Text;
        string ic = txtboxUGPassword.Text;

        con.Open();

        string UGlogin = "SELECT * FROM STUDENT WHERE MATRIC = '" + matric + "' AND  IC ='" + ic + "'";
        SqlCommand cmd = new SqlCommand(UGlogin, con);
        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();

        if (dr.HasRows)
        {

            Session["MATRIC"] = dr["MATRIC"].ToString();
            Response.Redirect("Home.aspx");
        }
        else
        {
            string script = "alert(Maaf)";
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", script, true);
            
        }

        con.Close();
    }
}