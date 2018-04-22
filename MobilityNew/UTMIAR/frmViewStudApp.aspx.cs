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

public partial class UTMIAR_frmViewStudApp : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();

        string student = Session["StudentView"].ToString();
        string readStudent = "SELECT * FROM STUDENT INNER JOIN PROGRAMME ON STUDENT.MATRIC = PROGRAMME.MATRIC INNER JOIN APPLICATION ON STUDENT.MATRIC = APPLICATION.MATRIC INNER JOIN ACADEMIC ON STUDENT.MATRIC = ACADEMIC.MATRIC INNER JOIN VERIFICATION ON VERIFICATION.APPID = APPLICATION.APPID WHERE STUDENT.MATRIC ='" + student + "'";

        SqlCommand cmd = new SqlCommand(readStudent, con);
        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();

        Session["getappid"] = dr["APPID"].ToString();


        Session["acadStudMt"] = dr["MATRIC"].ToString();
        Session["acadStudNm"] = dr["NAME"].ToString();
        Session["acadStudTl"] = dr["CONTACTNUM"].ToString();
        Session["acadStudEm"] = dr["EMAIL"].ToString();
        Session["acadStudSv"] = dr["NAME"].ToString();

        Session["acadStudSs"] = dr["SEMESTER"].ToString();
        Session["acadStudPr"] = dr["PROGRAMME"].ToString();
        Session["acadStudFn"] = dr["FACULTY"].ToString();
        Session["acadStudBs"] = dr["SEMESTER"].ToString();
        
        Session["acadStudTs"] = dr["STATUS"].ToString();

        Session["acadProgType"] = dr["TYPE"].ToString();
        Session["acadProgUniversity"] = dr["UNIVERSITY"].ToString();
        Session["acadProgCountry"] = dr["COUNTRY"].ToString();
        Session["acadProgStartDate"] = String.Format("{0:dd-MMM-yyyy}", dr["STARTDATE"]);
        Session["acadProgEndDate"] = String.Format("{0:dd-MMM-yyyy}", dr["ENDDATE"]);

        Session["VER_ID"] = dr["VERID"].ToString();
        Session["acadStudSv"] = dr["SVID"].ToString();
        Session["acadProgAAComment"] = dr["SVCOMMENT"].ToString();
        Session["acadProgAADate"] = String.Format("{0:dd-MMM-yyyy}", dr["SVDATE"]);
        Session["acadStudDean"] = dr["TDAID"].ToString();
        Session["acadProgDeanComment"] = dr["TDACOMMENT"].ToString();
        Session["acadProgDeanDate"] = String.Format("{0:dd-MMM-yyyy}", dr["TDADATE"]);

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

        string appid = Session["getappid"].ToString();

        con.Open();
        string financial = "SELECT * FROM FINANCIALUTM WHERE APPID ='" + appid + "'";
        SqlCommand cmd1 = new SqlCommand(financial, con);
        SqlDataReader dr1 = cmd1.ExecuteReader();
        dr1.Read();

        Session["acadFinancialFee"] = dr1["FEE"].ToString();
        Session["acadFinancialTransportation"] = dr1["TRANSPORTATION"].ToString();
        Session["acadFinancialAccommodation"] = dr1["ACCOMMODATION"].ToString();
        Session["acadFinancialMeal"] = dr1["MEAL"].ToString();
        Session["acadFinancialContigency"] = dr1["CONTINGENCY"].ToString();

        imgPhoto.InnerHtml = "<img src=\"../Styles/images/Apip.jpeg\" class=\"img-profile\" alt=\"profileimage\" />";
        lblName.Text = Session["acadStudNm"].ToString();
        lblProgramme.Text = Session["acadStudPr"].ToString();
        lblFaculty.Text = Session["acadStudFn"].ToString();
        lblMatric.Text = Session["acadStudMt"].ToString();
        lblBilSemester.Text = Session["acadStudBs"].ToString();
        lblAA.Text = Session["acadStudSv"].ToString();
        lblToS.Text = Session["acadStudTs"].ToString() + " (Full Time)";
        lblEmail.Text = Session["acadStudEm"].ToString();
        lblPhone.Text = Session["acadStudTl"].ToString();
        lblProgType.Text = Session["acadProgType"].ToString();
        lblUniversity.Text = Session["acadProgUniversity"].ToString();
        lblCountry.Text = Session["acadProgCountry"].ToString();
        lblStartDate.Text = Session["acadProgStartDate"].ToString();
        lblEndDate.Text = Session["acadProgEndDate"].ToString();

        lblAAName.Text = Session["acadStudSv"].ToString();
        lblAAComment.Text = Session["acadProgAAComment"].ToString();
        lblAADate.Text = Session["acadProgAADate"].ToString();
        lblDeanName.Text = Session["acadStudDean"].ToString();
        lblDeanComment.Text = Session["acadProgDeanComment"].ToString();
        lblDeanDate.Text = Session["acadProgDeanDate"].ToString();

        lblFee.Text = string.Format("{0:RM #,#.##}", int.Parse(Session["acadFinancialFee"].ToString()));
        lblTransportation.Text = string.Format("{0:RM #,#.##}", int.Parse(Session["acadFinancialTransportation"].ToString()));
        lblAccommodation.Text = string.Format("{0:RM #,#.##}", int.Parse(Session["acadFinancialAccommodation"].ToString()));
        lblMeal.Text = string.Format("{0:RM #,#.##}", int.Parse(Session["acadFinancialMeal"].ToString()));
        lblContingency.Text = string.Format("{0:RM #,#.##}", int.Parse(Session["acadFinancialContigency"].ToString()));
        int total = int.Parse(Session["acadFinancialFee"].ToString()) + int.Parse(Session["acadFinancialTransportation"].ToString()) + int.Parse(Session["acadFinancialAccommodation"].ToString()) + int.Parse(Session["acadFinancialMeal"].ToString()) + int.Parse(Session["acadFinancialContigency"].ToString());
        lblTotalProposed.Text = string.Format("{0:RM #,#.##}", total);

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
        string sqlUpdate = "UPDATE VERIFICATION SET UTMIARID = @UTMIARID, UTMIARDATE = @UTMIARDATE, SYSTEMSTATUS = @SYSTEMSTATUS, UTMIARSTATUS = @UTMIARSTATUS, UTMIARCOMMENT = @UTMIARCOMMENT, UTMIDSTATUS = @UTMIDSTATUS WHERE APPID = @APPID";
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = sqlUpdate;
        cmd.Parameters.Add(new SqlParameter("@ID", Session["SMATRIC"].ToString()));
        cmd.Parameters.Add(new SqlParameter("@UTMIARDATE", DateTime.Today.ToString("dd-MMM-yyyy")));
        cmd.Parameters.Add(new SqlParameter("@SYSTEMSTATUS", SYSSTATUS));
        cmd.Parameters.Add(new SqlParameter("@UTMIARSTATUS", SVSTAT));
        cmd.Parameters.Add(new SqlParameter("@UTMIARCOMMENT", txtComment.Text));
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

        //sendRejectEmail();

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
        mail.Body = "Greetings.,<br /><br />Your Summer School Abroad Application has been rejected by UTM International Assistant Registrar.<br /><br />Thank you.";
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
        int UTMIARSTAT = 3;
        con.Open();
        string sqlUpdate = "UPDATE VERIFICATION SET UTMIARID = @UTMIARID, UTMIARDATE = @UTMIARDATE, SYSTEMSTATUS = @SYSTEMSTATUS, UTMIARSTATUS = @UTMIARSTATUS, UTMIARCOMMENT = @UTMIARCOMMENT, UTMIDSTATUS = @UTMIDSTATUS WHERE APPID = @APPID";

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = sqlUpdate;
        cmd.Parameters.Add(new SqlParameter("@UTMIARID", Session["SMATRIC"].ToString()));
        cmd.Parameters.Add(new SqlParameter("@UTMIARDATE", DateTime.Today.ToString("dd-MMM-yyyy")));
        cmd.Parameters.Add(new SqlParameter("@SYSTEMSTATUS", 3));
        cmd.Parameters.Add(new SqlParameter("@UTMIARSTATUS", UTMIARSTAT));
        cmd.Parameters.Add(new SqlParameter("@UTMIARCOMMENT", txtComment.Text));
        cmd.Parameters.Add(new SqlParameter("@UTMIDSTATUS", "11"));
        cmd.Parameters.Add(new SqlParameter("@APPID", APP_APPID));
        //cmd.Parameters.Add(new SqlParameter("@SVSTATUS", VER_ID));
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();


        sqlUpdate = "UPDATE FINANCIALUTM SET UTMSPONSOR = @UTMSPONSOR WHERE APPID = @APPID";
        cmd.CommandText = sqlUpdate;
        cmd.Parameters.Add(new SqlParameter("@UTMSPONSOR", txtTotalAllocated.Text));
        cmd.Parameters.Add(new SqlParameter("@APPID", APP_APPID));
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        con.Close();


        //sendApproveEmail();
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
        mail.Body = "Greetings.,<br /><br />Your Summer School Abroad Application has been approved by UTM International Assistant Registrar.<br /><br />Thank you.";
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

        if (FileBuffer != null)
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