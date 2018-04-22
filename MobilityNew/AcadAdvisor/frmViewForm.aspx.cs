using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Data;

public partial class AcadAdvisor_frmViewForm : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        //string APP_APPID = Session["APPID"].ToString();
        string studMatric = Session["acadStudMt"].ToString();

        string sql = "SELECT * FROM APPLICATION a INNER JOIN STUDENT s ON a.MATRIC = s.MATRIC INNER JOIN PROGRAMME p ON a.MATRIC = p.MATRIC INNER JOIN HSUBJECT h ON a.APPID = h.APPID INNER JOIN ACADEMIC ac ON a.MATRIC = ac.MATRIC WHERE a.MATRIC ='" + studMatric + "'";

        
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();
   

        Session["acadStudMt"] = dr["MATRIC"].ToString();
        Session["acadStudNm"] = dr["NAME"].ToString();
        Session["acadStudDoB"] = String.Format("{0:dd-MMM-yyyy}", dr["DOB"]);
        Session["acadStudIC"] = dr["IC"].ToString();
        Session["acadStudTl"] = dr["CONTACTNUM"].ToString();
        Session["acadStudEm"] = dr["EMAIL"].ToString();
        Session["acadStudReligion"] = dr["RELIGION"].ToString();
        Session["acadStudCitizenship"] = dr["CITIZENSHIP"].ToString();
        Session["acadStudRace"] = dr["RACE"].ToString();
        Session["acadStudAddress"] = dr["ADDRESS"].ToString();
        Session["acadStudNextOfKin"] = dr["KIN"].ToString();
        Session["acadStudEmergencyContact"] = dr["EMERGENCYCONTACT"].ToString();
        Session["acadStudKinAddress"] = dr["KINADDRESS"].ToString();

        Session["acadStudSs"] = "201620171";
        Session["acadStudPr"] = "Bachelor Of Computer Science (Software Engineering)";
        Session["acadStudFn"] = "Computing";
        Session["acadStudBs"] = "5";
        Session["acadStudNs"] = "8";
        Session["acadStudPassport"] = "1234567890";
        Session["acadStudPassportEx"] = "31/12/2020";
        Session["acadStudCGPA"] = "3.98";
        Session["acadStudStatus"] = "Active";
        Session["acadStudGraduation"] = "2018";
        Session["acadStudField"] = "-";

        Session["acadProgType"] = dr["TYPE"].ToString();
        Session["acadProgUniversity"] = dr["UNIVERSITY"].ToString();
        Session["acadProgCountry"] = dr["COUNTRY"].ToString();
        Session["acadProgStartDate"] = String.Format("{0:dd-MMM-yyyy}", dr["STARTDATE"]);
        Session["acadProgEndDate"] = String.Format("{0:dd-MMM-yyyy}", dr["ENDDATE"]);

        //Session["acadFinancialSources"] = dr["FIN_SOURCES"].ToString();
        //Session["acadFinancialSponsor"] = dr["FIN_SPONNAME"].ToString();
        //Session["acadFinancialFee"] = dr["FIN_FEE"].ToString();
        //Session["acadFinancialTransportation"] = dr["FIN_TRAN"].ToString();
        //Session["acadFinancialAccommodation"] = dr["FIN_ACCO"].ToString();
        //Session["acadFinancialMeal"] = dr["FIN_MEAL"].ToString();
        //Session["acadFinancialContigency"] = dr["FIN_CONT"].ToString();

        con.Close();  // Close Connection with database

        if (!IsPostBack)
        {
            string sesisem = Session["acadStudSs"].ToString();
            showForm();
            //BindRepeater();
        }
    }

    protected void showForm()
    {
        //imgPhoto.InnerHtml = "<img src=\"../Styles/images/PhotoStudent.ashx.jpeg\" class=\"img-profile\" width=\"100\" alt=\"profileimage\" />";
        lblName.Text = Session["acadStudNm"].ToString();
        lblProgramme.Text = Session["acadStudPr"].ToString();
        lblFaculty.Text = Session["acadStudFn"].ToString();
        lblMatric.Text = Session["acadStudMt"].ToString();
        lblSemesterNorm.Text = Session["acadStudBs"].ToString() + " / " + Session["acadStudNs"].ToString();
        //lblAA.Text = Session["acadStudSv"].ToString();
        //lblToS.Text = Session["acadStudTs"].ToString() + " (Full Time)";
        lblEmail.Text = Session["acadStudEm"].ToString();
        lblContact.Text = Session["acadStudTl"].ToString();
        lblIC.Text = Session["acadStudIC"].ToString();
        lblDoB.Text = Session["acadStudDoB"].ToString();
        lblReligion.Text = Session["acadStudReligion"].ToString();
        lblRace.Text = Session["acadStudRace"].ToString();
        lblCitizenship.Text = Session["acadStudCitizenship"].ToString();
        lblNextKin.Text = Session["acadStudNextOfKin"].ToString();
        lblEmergency.Text = Session["acadStudEmergencyContact"].ToString();
        lblAddress.Text = Session["acadStudAddress"].ToString();
        lblNextKinAddress.Text = Session["acadStudAddress"].ToString();
        lblPassportNo.Text = Session["acadStudPassport"].ToString();
        lblPassportExDate.Text = Session["acadStudPassportEx"].ToString();
        lblCGPA.Text = Session["acadStudCGPA"].ToString();
        lblStatus.Text = Session["acadStudStatus"].ToString();
        lblGraduation.Text = Session["acadStudGraduation"].ToString();
        lblField.Text = Session["acadStudField"].ToString();

        lblProgType.Text = Session["acadProgType"].ToString();
        //lblProgName.Text = Session["acadProgName"].ToString();
        lblUniversity.Text = Session["acadProgUniversity"].ToString();
        lblCountry.Text = Session["acadProgCountry"].ToString();
        lblStartDate.Text = Session["acadProgStartDate"].ToString();
        lblEndDate.Text = Session["acadProgEndDate"].ToString();

        //lblSources.Text = Session["acadFinancialSources"].ToString();
        //lblSponsorName.Text = Session["acadFinancialSponsor"].ToString();
        //lblFee.Text = Session["acadFinancialFee"].ToString();
        //lblTransportation.Text = Session["acadFinancialTransportation"].ToString();
        //lblAccommodation.Text = Session["acadFinancialAccommodation"].ToString();
        //lblMeal.Text = Session["acadFinancialMeal"].ToString();
        //lblContingency.Text = Session["acadFinancialContigency"].ToString();
        //int total = int.Parse(lblFee.Text) + int.Parse(lblTransportation.Text) + int.Parse(lblAccommodation.Text) + int.Parse(lblMeal.Text) + int.Parse(lblContingency.Text);
        //lblTotalProposed.Text = total.ToString();
    }
    //private void BindRepeater()
    //{
    //    string APP_APPID = Session["getappid"].ToString();
    //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))  
    //    {
    //        using (SqlCommand cmd = new SqlCommand("SELECT * FROM HSUBJECT WHERE APPID = " + APP_APPID, con))
    //        {
    //            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
    //            {
    //                DataTable dt = new DataTable();
    //                sda.Fill(dt);
    //                rptSubjects.DataSource = dt;
    //                rptSubjects.DataBind();
    //            }
    //        }
    //    }
    //}
}