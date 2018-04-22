using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


public partial class UGStudent_frmFinancialaspx : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void chckSelf_CheckedChanged(object sender, EventArgs e)
    {
        chckSponsor.Checked = false;
        chckUTM.Checked = false;
        Panel2.Visible = false;
        Panel1.Visible = false;
    }
    protected void chckSponsor_CheckedChanged(object sender, EventArgs e)
    {
        chckSelf.Checked = false;
        chckUTM.Checked = false;
        Panel2.Visible = false;
        Panel1.Visible = chckSponsor.Checked;
    }

    protected void chckUTM_CheckedChanged(object sender, EventArgs e)
    {
        chckSelf.Checked = false;
        chckSponsor.Checked = false;
        Panel1.Visible = false;
        Panel2.Visible = chckUTM.Checked;
    }


    protected void btnSave4_Click(object sender, EventArgs e)
    {
        con.Open();

      
        if(chckSelf.Checked)
        {
            Response.Redirect("frmAttachment.aspx");
        }
        else if(chckSponsor.Checked)
        {
            String path = Server.MapPath("~/Upload/Documents/Sponsor/");
            String extendFName = Session["MATRIC"].ToString();

            String fileExtension = System.IO.Path.GetFileName(upldSponsor.PostedFile.FileName);
            String saveLocation = path + extendFName +fileExtension;
            String file1 = "~/Upload/Documents/Sponsor/" + fileExtension;
            String file2 = extendFName + fileExtension;

            string sponsor = "INSERT INTO FINANCIALSPONSOR(SPONSORNAME, FILENAME, FILEPATH, APPID) VALUES (@sponsorname, @filename, @filepath, @appid)";
            SqlCommand cmdSponsor = new SqlCommand(sponsor, con);
            cmdSponsor.Parameters.AddWithValue("@sponsorname", txtSponsorName.Text);
            cmdSponsor.Parameters.AddWithValue("@filename", file2);
            cmdSponsor.Parameters.AddWithValue("@filepath", file1);
            cmdSponsor.Parameters.AddWithValue("@appid", Session["APPID"].ToString());
            cmdSponsor.ExecuteNonQuery();

            upldSponsor.PostedFile.SaveAs(saveLocation);

            Response.Redirect("frmAttachment.aspx");
        }
        else if(chckUTM.Checked)
        {
            string sponsorUTM = "INSERT INTO FINANCIALUTM(FEE, TRANSPORTATION, ACCOMMODATION, MEAL, CONTINGENCY, TOTAL, APPID) VALUES(@fee, @transport, @accommodation, @meal, @contingency, @total, @appid)";
            SqlCommand cmdsponsorUTM = new SqlCommand(sponsorUTM, con);
            cmdsponsorUTM.Parameters.AddWithValue("@fee", txtProgramFee.Text);
            cmdsponsorUTM.Parameters.AddWithValue("@transport", txtTransportation.Text);
            cmdsponsorUTM.Parameters.AddWithValue("@accommodation", txtAccommodation.Text);
            cmdsponsorUTM.Parameters.AddWithValue("@meal", txtMeal.Text);
            cmdsponsorUTM.Parameters.AddWithValue("@contingency", txtContingency.Text);
            cmdsponsorUTM.Parameters.AddWithValue("@total", txtTotal.Text);
            cmdsponsorUTM.Parameters.AddWithValue("@appid", Session["APPID"].ToString());
            cmdsponsorUTM.ExecuteNonQuery();

            Response.Redirect("frmAttachment.aspx");
        }
        else
        {
            string script = "alert('Select your sponsor'); window.location.reload();\n";
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", script, true);
        }


        

        con.Close();
    }
}