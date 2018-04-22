using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;


public partial class UTMIAR_frmAddNewProg : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        {
            Random rnd = new Random();
            // Declaration
            string strInsertProgramme = "INSERT INTO PROGRAMME (PROGID, TYPE, PROGNAME, UNIVERSITY, COUNTRY, STARTDATE, ENDDATE, DEADLINE, STATUS) VALUES (:PROGID, :TYPE, :PROGNAME, :UNIVERSITY, :COUNTRY, :STARTDATE, :ENDDATE, :DEADLINE, :STATUS)";
   
            con.Open();  // Open Connection with database

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strInsertProgramme;
            cmd.Parameters.Add(new SqlParameter("PROGID", rnd.Next(9999)));
            cmd.Parameters.Add(new SqlParameter("TYPE", ddlTypes.Text));
            cmd.Parameters.Add(new SqlParameter("PROGNAME", txtProgName.Text));
            cmd.Parameters.Add(new SqlParameter("UNIVERSITY", txtUniversity.Text));
            cmd.Parameters.Add(new SqlParameter("COUNTRY", ddlCountry.SelectedValue));
            cmd.Parameters.Add(new SqlParameter("STARTDATE", DateTime.ParseExact(txtStartDate.Text, "dd-MMM-yyyy", null)));
            cmd.Parameters.Add(new SqlParameter("ENDDATE", DateTime.ParseExact(txtEndDate.Text, "dd-MMM-yyyy", null)));
            cmd.Parameters.Add(new SqlParameter("DEADLINE", DateTime.ParseExact(txtDeadline.Text, "dd-MMM-yyyy", null)));
            cmd.Parameters.Add(new SqlParameter("STATUS", "Submitted"));
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            con.Close();  // Close Connection with database

            // Message Box
            string script = "alert('New Programme Added.'); window.location.reload();\n";
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", script, true);

            Response.Redirect("frmProgramme.aspx");
        }
    }

    protected void btnDraft_Click(object sender, EventArgs e)
    {
        Random rnd = new Random();
        // Declaration
        string strInsertProgramme = "INSERT INTO PROGRAMME (PROGID, TYPE, PROGNAME, UNIVERSITY, COUNTRY, STARTDATE, ENDDATE, DEADLINE, STATUS) VALUES (:PROGID, :TYPE, :PROGNAME, :UNIVERSITY, :COUNTRY, :STARTDATE, :ENDDATE, :DEADLINE, :STATUS)";

        con.Open();  // Open Connection with database

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = strInsertProgramme;
        cmd.Parameters.Add(new SqlParameter("PROGID", rnd.Next(9999)));
        cmd.Parameters.Add(new SqlParameter("TYPE", ddlTypes.Text));
        cmd.Parameters.Add(new SqlParameter("PROGNAME", txtProgName.Text));
        cmd.Parameters.Add(new SqlParameter("UNIVERSITY", txtUniversity.Text));
        cmd.Parameters.Add(new SqlParameter("COUNTRY", ddlCountry.SelectedValue));
        cmd.Parameters.Add(new SqlParameter("STARTDATE", DateTime.ParseExact(txtStartDate.Text, "dd-MMM-yyyy", null)));
        cmd.Parameters.Add(new SqlParameter("ENDDATE", DateTime.ParseExact(txtEndDate.Text, "dd-MMM-yyyy", null)));
        cmd.Parameters.Add(new SqlParameter("DEADLINE", DateTime.ParseExact(txtDeadline.Text, "dd-MMM-yyyy", null)));
        cmd.Parameters.Add(new SqlParameter("STATUS", "Draft"));
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();

        con.Close();  // Close Connection with database

        // Message Box
        string script = "alert('New Programme Drafted.'); window.location.reload();\n";
        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", script, true);

        Response.Redirect("frmProgramme.aspx");
    }
}