using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


public partial class UGStudent_frmDashboard : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();

        if (Session["MATRIC"] != null)
        {
            //dah login
            string matric = Session["MATRIC"].ToString();

            string personal = "SELECT * FROM STUDENT WHERE MATRIC = '" + matric + "'";
            SqlCommand cmd = new SqlCommand(personal, con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            if (dr.HasRows)
            {
                lblDOB.Text = dr["DOB"].ToString();
                lblReligion.Text = dr["RELIGION"].ToString();
                lblIC.Text = dr["IC"].ToString();
                lblHomeAddress.Text = dr["ADDRESS"].ToString();
                lblContact.Text = dr["EMERGENCYCONTACT"].ToString();
                lblCitizenship.Text = dr["CITIZENSHIP"].ToString();
                lblEmail.Text = dr["EMAIL"].ToString();
                lblRace.Text = dr["RACE"].ToString();
                lblNextofKin.Text = dr["KIN"].ToString();
                lblKinAddress.Text = dr["KINADDRESS"].ToString();
            }
        }
        else
        {
            Response.Redirect("UGLogin.aspx");
        }
        con.Close();
        
    }

    protected void btnSave2_Click(object sender, EventArgs e)
    {
        Session["PassportNumber"] = txtPassportNumber.Text;
        Session["PassportExpiredDate"] = txtPassportExpiredDate.Text;
        Response.Redirect("frmAcademic.aspx");
    }
}