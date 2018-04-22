using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class UGStudent_ActivityUpdate : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        con.Open();

        string matric = Session["MATRIC"].ToString();
        string appid = Session["APPID"].ToString();

        string insert = "INSERT INTO UPDATED_INFO(APPID, PHONENUMBER, ADDRESS, CONTACTNAME, CONTACTRELATION, CONTACTPHONENUMBER, MATRIC) VALUES(@appid,@phoneno,@address,@cn,@cr,@cpn,@matric)";
        SqlCommand cmdInsert = new SqlCommand(insert, con);
        cmdInsert.Parameters.AddWithValue("@appid", appid);
        cmdInsert.Parameters.AddWithValue("@phoneno", txtboxPhoneNo.Text);
        cmdInsert.Parameters.AddWithValue("@address", txtboxAddress.Text);
        cmdInsert.Parameters.AddWithValue("@cn", txtboxEmergencyContact.Text);
        cmdInsert.Parameters.AddWithValue("@cr", txtboxEContactRelation.Text);
        cmdInsert.Parameters.AddWithValue("@cpn", txtboxEContactPhoneNo.Text);
        cmdInsert.Parameters.AddWithValue("@matric", matric);
        cmdInsert.ExecuteNonQuery();

        con.Close();



    }
}