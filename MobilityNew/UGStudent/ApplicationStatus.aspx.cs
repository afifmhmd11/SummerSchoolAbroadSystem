using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class UGStudent_inbox : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected string checkStatus(string Status)
    {
        string stat = "";
        if (Status == "0")
        {
            stat = "<span class='label label-danger'>Rejected<span>";
            //Panel1.Visible = true;
            //Panel2.Visible = false;
        }
        else if(Status == "1")
        {
            stat = "<span class='label label-success'>Academic Advisor<span>";
            Panel1.Visible = true;
        }
        else if (Status == "2")
        {
            stat = "<span class='label label-success'>Faculty Dean<span>";
            Panel1.Visible = true;
            Panel2.Visible = true;
        }
        else if (Status == "3")
        {
            stat = "<span class='label label-success'>UTMI Assistant Registrar<span>";
            Panel1.Visible = true;
            Panel2.Visible = true;
            Panel3.Visible = true;
        }
        else if (Status == "4")
        {
            stat = "<span class='label label-success'>UTMI Director<span>";
            Panel1.Visible = true;
            Panel2.Visible = true;
            Panel3.Visible = true;
            Panel4.Visible = true;
        }
        else if (Status == "5")
        {
            stat = "<span class='label label-success'>TNCAA<span>";
            Panel1.Visible = true;
            Panel2.Visible = true;
            Panel3.Visible = true;
            Panel4.Visible = true;
            Panel5.Visible = true;
            
        }
        return stat;
       
    }

    protected void ViewStatus(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        string matric = (sender as LinkButton).CommandArgument;
        //Session.Add("MATRIC", matric);
        Session["StudentView"] = matric;
        Panel1.Visible = true;
        //Response.Redirect("Home.aspx");

        con.Open();

        //"SELECT STUDENT.MATRIC FROM STUDENT INNER JOIN  STAFF ON STAFF.SMATRIC = STUDENT.SMATRIC WHERE STUDENT.MATRIC = '" + matric + "'";
        //

        string matric1 = Session["MATRIC"].ToString();
        string getStatus = "SELECT STAFF.SMATRIC, STAFF.NAME FROM STAFF INNER JOIN STUDENT ON STUDENT.SMATRIC = STAFF.SMATRIC WHERE STUDENT.MATRIC = '" + matric1 + "'";

        SqlCommand cmd = new SqlCommand(getStatus, con);
        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();
        
        lblAcadAdvisor.Text = dr["NAME"].ToString();
        con.Close();

        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        con1.Open();

        string appid = Session["APPID"].ToString();
        string getVerID = "SELECT * FROM VERIFICATION WHERE APPID = '" + appid + "'";

        SqlCommand cmd1 = new SqlCommand(getVerID, con1);
        SqlDataReader dr1 = cmd1.ExecuteReader();
        dr1.Read();

        lblAADate.Text = String.Format("{0:dd-MMM-yyyy}", dr1["SYSTEMDATE"]);
        lblStatus.Text = checkStatus(dr1["SYSTEMSTATUS"].ToString());

       
        cmd1.Parameters.Clear();

        con1.Close();





    }

}