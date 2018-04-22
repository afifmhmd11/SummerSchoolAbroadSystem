using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections;
using System.Drawing;
using System.Net.Mail;
public partial class UGStudent_frmDeclaration : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void chckDeclaration_CheckedChanged(object sender, EventArgs e)
    {
        btnSubmit.Visible = chckDeclaration.Checked;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        con.Open();

        using (SqlCommand cmd1 = new SqlCommand("SELECT * FROM ATTACHMENT WHERE APPID = '" + Session["APPID"].ToString() + "'", con))
        {
            using (SqlDataReader reader = cmd1.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Close();
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Application Submitted');", true);

                    string appid = Session["APPID"].ToString();

                    int SYSSTATUS = 11;
                    string insert = "INSERT INTO VERIFICATION(APPID, SYSTEMDATE, SYSTEMSTATUS) VALUES(@APPID,@SYSTEMDATE,@SYSTEMSTATUS)";
                    SqlCommand cmdInsert = new SqlCommand(insert, con);
                    cmdInsert.Parameters.AddWithValue("@APPID", appid);
                    cmdInsert.Parameters.AddWithValue("@SYSTEMDATE", DateTime.Today.ToString("dd-MMM-yyyy"));
                    cmdInsert.Parameters.AddWithValue("@SYSTEMSTATUS", SYSSTATUS);

                    cmdInsert.ExecuteNonQuery();

                    sendEmail();

                    ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Application Submitted');window.location='Homeafter.aspx';</script>'");

                    con.Close();

                    //Response.Redirect("Homeafter.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Error", "<script type='text/javascript'>alert('Error!.Application not completed');window.location='frmDeclaration.aspx';</script>'");
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error! Application not completed');", true);
                    //Response.Write("<script>alert('Error. Application not completed');</script>");
                }
                
            }
        }
    }

    protected void sendEmail()///////////////////////////////send approved notification
    {

        ///////////////////////////////send approved notification 
        MailMessage mail = new MailMessage();
        mail.To.Add("mohamadafif19@gmail.com");
        mail.From = new MailAddress("mohamadafif95@gmail.com", "SSAP Application Submitted", System.Text.Encoding.UTF8);
        mail.Subject = "SSAP Application.";
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = "Greetings.,<br />Your Summer School Abroad Application has been submitted for approval.<br /><br />Thank you.";
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;
        SmtpClient user = new SmtpClient();
        user.Credentials = new System.Net.NetworkCredential("mohamadafif95@gmail.com", "Nurain846");
        user.Port = 587;
        user.Host = "smtp.gmail.com";
        user.EnableSsl = true;
        user.Send(mail);
        //try
        //{
        //    user.Send(mail);
        //}
        //catch (Exception e)
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Gagal');window.location ='frmProgramme.aspx';", true);
        //}



    }
}