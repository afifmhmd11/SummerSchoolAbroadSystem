using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class UGStudent_frmAcademic : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();

        string matric = Session["MATRIC"].ToString();

        string personal = "SELECT * FROM STUDENT WHERE MATRIC = '" + matric + "'";
        SqlCommand cmd = new SqlCommand(personal, con);
        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();

        lblGraduationYear.Text = dr["GRADUATEYEAR"].ToString();
        lblStatus.Text = dr["STATUS"].ToString();
        con.Close();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        con.Open();
        string insertHSubject = "INSERT INTO HSUBJECT(SUBJECTCODE, SUBJECTNAME, SCREDIT, APPID, UTMCODE) VALUES(@scode,@sname,@scredit, @appid, @utmcode)";
        SqlCommand cmdinsertHSubject = new SqlCommand(insertHSubject, con);
        cmdinsertHSubject.Parameters.AddWithValue("@scode", txtHostSubjectCode.Text);
        cmdinsertHSubject.Parameters.AddWithValue("@sname", txtHostSubjectName.Text);
        cmdinsertHSubject.Parameters.AddWithValue("@scredit", txtHostCredit.Text);
        cmdinsertHSubject.Parameters.AddWithValue("@appid", Session["APPID"].ToString());
        cmdinsertHSubject.Parameters.AddWithValue("@utmcode", txtSubjectCode.Text);
        cmdinsertHSubject.ExecuteNonQuery();

        Response.Redirect("frmAcademic.aspx");

        con.Close();  
    }

    
}