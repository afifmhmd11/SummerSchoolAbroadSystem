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

public partial class AcadAdvisor_frmViewStudApp : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();

        //string smatric = Session["SMATRIC"].ToString();
        //string readStudent = "SELECT * FROM STUDENT INNER JOIN PROGRAMME ON STUDENT.MATRIC = PROGRAMME.MATRIC INNER JOIN APPLICATION ON STUDENT.MATRIC = APPLICATION.MATRIC WHERE SMATRIC '" + smatric + "'";
        string student = Session["StudentView"].ToString();
        string readStudent = "SELECT * FROM STUDENT INNER JOIN PROGRAMME ON STUDENT.MATRIC = PROGRAMME.MATRIC INNER JOIN APPLICATION ON STUDENT.MATRIC = APPLICATION.MATRIC WHERE STUDENT.MATRIC ='" + student + "'";

        

        SqlCommand cmd = new SqlCommand(readStudent, con);
        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();

        Session["getappid"] = dr["APPID"].ToString();
        

        Session["acadStudMt"] = dr["MATRIC"].ToString();
        Session["acadStudNm"] = dr["NAME"].ToString();
        Session["acadStudTl"] = dr["CONTACTNUM"].ToString();
        Session["acadStudEm"] = dr["EMAIL"].ToString();
        Session["acadStudSv"] = dr["NAME"].ToString();

        Session["acadStudSs"] = "201620171";
        Session["acadStudPr"] = "Bachelor Of Computer Science (Software Engineering)";
        Session["acadStudFn"] = "Computing";
        Session["acadStudBs"] = "5";
        Session["acadStudNs"] = "8";
        Session["acadStudTs"] = "Taught Course";

        Session["acadProgType"] = dr["TYPE"].ToString();
        Session["acadProgUniversity"] = dr["UNIVERSITY"].ToString();
        Session["acadProgCountry"] = dr["COUNTRY"].ToString();
        Session["acadProgStartDate"] = String.Format("{0:dd-MMM-yyyy}", dr["STARTDATE"]);
        Session["acadProgEndDate"] = String.Format("{0:dd-MMM-yyyy}", dr["ENDDATE"]);

        //Session["VER_ID"] = dr["VER_ID"].ToString();
        con.Close();

        if (!IsPostBack)
        {
            //string sesisem = Session["acadStudSs"].ToString();
            showProfile();
        }
    }
    protected void showProfile()
    {
        //con.Open();

        //string getattach = "SELECT * FROM ATTACHMENT WHERE APPID  ='" + Session["getappid"].ToString() + "'";
        //SqlCommand cmd1 = new SqlCommand(getattach, con);
        //SqlDataReader dr1 = cmd1.ExecuteReader();
        //dr1.Read();

        imgPhoto.InnerHtml = "<img src=\"../Styles/images/Apip.jpeg\" class=\"img-profile\" alt=\"profileimage\" />";
        lblName.Text = Session["acadStudNm"].ToString();
        lblProgramme.Text = Session["acadStudPr"].ToString();
        lblFaculty.Text = Session["acadStudFn"].ToString();
        lblMatric.Text = Session["acadStudMt"].ToString();
        lblBilSemester.Text = Session["acadStudBs"].ToString() + " / " + Session["acadStudNs"].ToString();
        lblAA.Text = Session["acadStudSv"].ToString();
        lblToS.Text = Session["acadStudTs"].ToString() + " (Full Time)";
        lblEmail.Text = Session["acadStudEm"].ToString();
        lblPhone.Text = Session["acadStudTl"].ToString();
        lblProgType.Text = Session["acadProgType"].ToString();
        lblUniversity.Text = Session["acadProgUniversity"].ToString();
        lblCountry.Text = Session["acadProgCountry"].ToString();
        lblStartDate.Text = Session["acadProgStartDate"].ToString();
        lblEndDate.Text = Session["acadProgEndDate"].ToString();

        //string filename = dr1["FILENAME"].ToString();
        //Response.ContentType = "application/octet-stream";
        //Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
        //string aaa = Server.MapPath("~/Upload/Documents/" + filename);
        //Response.TransmitFile(Server.MapPath("~/Upload/Documents/" + filename));
        //Response.End();

        //lblStudyPlan.Text = dr1["FILEPATH"].ToString();
        //lblAcceptLetter.Text = dr1["FILEPATH"].ToString();
        //lblBankStatement.Text = dr1["FILEPATH"].ToString();
        //lblPhotoIC.Text = dr1["FILEPATH"].ToString();

        con.Close();
    }

    


    protected void btnRevert_Click(object sender, EventArgs e)
    {
        string APP_APPID = Session["getAppID"].ToString();
        int SVSTAT = 0;
        int SYSSTATUS = 0;
        string sqlUpdate = "UPDATE VERIFICATION SET SVID = @ID, SVDATE = @TODAYSDATE, SYSTEMSTATUS = @SYSTEMSTATUS, SVSTATUS = @SVSTATUS, SVCOMMENT = @COMMENTTEXT WHERE APPID = @APPID";
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = sqlUpdate;
        cmd.Parameters.Add(new SqlParameter("@ID", Session["SMATRIC"].ToString()));
        cmd.Parameters.Add(new SqlParameter("@TODAYSDATE", DateTime.Today.ToString("dd-MMM-yyyy")));
        cmd.Parameters.Add(new SqlParameter("@SYSTEMSTATUS", SYSSTATUS));
        cmd.Parameters.Add(new SqlParameter("@SVSTATUS", SVSTAT));
        cmd.Parameters.Add(new SqlParameter("@COMMENTTEXT", txtComment.Text));
        cmd.Parameters.Add(new SqlParameter("@APPID", APP_APPID));
        //cmd.Parameters.Add(new SqlParameter("@VERID", VER_ID));
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();

        sqlUpdate = "UPDATE APPLICATION SET STATUS = @STATUS WHERE APPID = @APP_APPID";
        cmd.CommandText = sqlUpdate;
        cmd.Parameters.Add(new SqlParameter("@STATUS", "0"));
        cmd.Parameters.Add(new SqlParameter("@APP_APPID", APP_APPID));
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        con.Close();
        //Response.Redirect("Dashboard.aspx");

        sendRejectEmail();

        ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Application Rejected');window.location='Dashboard.aspx';</script>'");
    }

    protected void sendRejectEmail()///////////////////////////////send approved notification
    {

        ///////////////////////////////send approved notification 
        MailMessage mail = new MailMessage();
        mail.To.Add("mohamadafif19@gmail.com");
        mail.From = new MailAddress("mohamadafif95@gmail.com", "SSAP Application Rejected", System.Text.Encoding.UTF8);
        mail.Subject = "SSAP Application.";
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = "Greetings.,<br /><br />Your Summer School Abroad Application has been rejected by your Academic Advisor.<br /><br />Thank you.";
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string APP_APPID = Session["getAppID"].ToString();
        int SVSTAT = 1;
        con.Open();
        string sqlUpdate = "UPDATE VERIFICATION SET SVID = @SVID, SVDATE = @SVDATE, SYSTEMSTATUS = @SYSTEMSTATUS, SVSTATUS = @SVSTATUS, SVCOMMENT = @SVCOMMENT, TDASTATUS = @TDASTATUS WHERE APPID = @APPID";
        
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = sqlUpdate;
        cmd.Parameters.Add(new SqlParameter("@SVID", Session["SMATRIC"].ToString()));
        cmd.Parameters.Add(new SqlParameter("@SVDATE", DateTime.Today.ToString("dd-MMM-yyyy")));
        cmd.Parameters.Add(new SqlParameter("@SYSTEMSTATUS", 1));
        cmd.Parameters.Add(new SqlParameter("@SVSTATUS", SVSTAT));
        cmd.Parameters.Add(new SqlParameter("@SVCOMMENT", txtComment.Text));
        cmd.Parameters.Add(new SqlParameter("@TDASTATUS", "11"));
        cmd.Parameters.Add(new SqlParameter("@APPID", APP_APPID));
        //cmd.Parameters.Add(new SqlParameter("@SVSTATUS", VER_ID));
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        con.Close();

        sendApproveEmail();
        ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Submitted.');window.location='Dashboard.aspx';</script>'");

        //Response.Redirect("Dashboard.aspx");
        
    }

    protected void sendApproveEmail()///////////////////////////////send approved notification
    {

        ///////////////////////////////send approved notification 
        MailMessage mail = new MailMessage();
        mail.To.Add("mohamadafif19@gmail.com");
        mail.From = new MailAddress("mohamadafif95@gmail.com", "SSAP Application Approved", System.Text.Encoding.UTF8);
        mail.Subject = "SSAP Application.";
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = "Greetings.,<br /><br />Your Summer School Abroad Application has been approved by your Academic Advisor.<br /><br />Thank you.";
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
    protected void btnView_Click(object sender, EventArgs e)
    {
        string filename = (sender as LinkButton).CommandArgument;
        string file = Server.MapPath(filename);
        WebClient User = new WebClient();
        Byte[] FileBuffer = User.DownloadData(file);

        if(FileBuffer != null)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", FileBuffer.Length.ToString());
            Response.BinaryWrite(FileBuffer);
        }

        //Response.ContentType = ContentType;
        //Response.AppendHeader("Content/Disposition", "attachment; filename = " + Path.GetFileName(filename));
        //Response.WriteFile(filename);
        //Response.End();
    }

}