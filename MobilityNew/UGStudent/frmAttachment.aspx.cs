using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class UGStudent_frmAttachment : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSave5_Click(object sender, EventArgs e)
    {
        con.Open();

        String path1 = Server.MapPath("~/Upload/Documents/Study Plan/");
        String path2 = Server.MapPath("~/Upload/Documents/Acceptance Letter/");
        String path3 = Server.MapPath("~/Upload/Documents/IC Copy/");
        String path4 = Server.MapPath("~/Upload/Documents/Bank Book Copy/");

        if (upldStudyPlan.HasFile & upldAcceptanceLetter.HasFile & upldBankBookCopy.HasFile & upldICCopy.HasFile)
        {
            String extendFName = Session["MATRIC"].ToString();
            String fileExtension = System.IO.Path.GetFileName(upldStudyPlan.PostedFile.FileName);
            String fileExtension1 = System.IO.Path.GetFileName(upldAcceptanceLetter.PostedFile.FileName);
            String fileExtension2 = System.IO.Path.GetFileName(upldBankBookCopy.PostedFile.FileName);
            String fileExtension3 = System.IO.Path.GetFileName(upldICCopy.PostedFile.FileName);


            String saveLocation = path1 + extendFName + fileExtension;
            String saveLocation1 = path2 + extendFName + fileExtension1;
            String saveLocation2 = path3 + extendFName + fileExtension2;
            String saveLocation3 = path4 + extendFName + fileExtension3;


            String file1 = "~/Upload/Documents/Study Plan/" + fileExtension;
            String file2 = extendFName + fileExtension;

            String strInsert = "insert into ATTACHMENT(APPID, UPLOADDATE, FILENAME,FILEPATH) values (@appid, @update, @fname, @fpath)";
            SqlCommand cmdUpload = new SqlCommand(strInsert, con);
            cmdUpload.Parameters.AddWithValue("@appid", Session["APPID"].ToString());
            cmdUpload.Parameters.AddWithValue("@update", DateTime.Now);
            cmdUpload.Parameters.AddWithValue("@fname", file2);
            cmdUpload.Parameters.AddWithValue("@fpath", file1);
            cmdUpload.ExecuteNonQuery();

            String file11 = "~/Upload/Documents/Acceptance Letter/" + fileExtension1;
            String file22 = extendFName + fileExtension1;

            String strInsert1 = "insert into ATTACHMENT(APPID, UPLOADDATE, FILENAME,FILEPATH) values (@appid, @update, @fname, @fpath)";
            SqlCommand cmdUpload1 = new SqlCommand(strInsert1, con);
            cmdUpload1.Parameters.AddWithValue("@appid", Session["APPID"].ToString());
            cmdUpload1.Parameters.AddWithValue("@update", DateTime.Now);
            cmdUpload1.Parameters.AddWithValue("@fname", file22);
            cmdUpload1.Parameters.AddWithValue("@fpath", file11);
            cmdUpload1.ExecuteNonQuery();

            String file111 = "~/Upload/Documents/IC Copy/" + fileExtension2;
            String file222 = extendFName + fileExtension2;

            String strInsert2 = "insert into ATTACHMENT(APPID, UPLOADDATE, FILENAME,FILEPATH) values (@appid, @update, @fname, @fpath)";
            SqlCommand cmdUpload2 = new SqlCommand(strInsert2, con);
            cmdUpload2.Parameters.AddWithValue("@appid", Session["APPID"].ToString());
            cmdUpload2.Parameters.AddWithValue("@update", DateTime.Now);
            cmdUpload2.Parameters.AddWithValue("@fname", file222);
            cmdUpload2.Parameters.AddWithValue("@fpath", file111);
            cmdUpload2.ExecuteNonQuery();

            String file1111 = "~/Upload/Documents/Bank Book Copy/" + fileExtension3;
            String file2222 = extendFName + fileExtension3;

            String strInsert3 = "insert into ATTACHMENT(APPID, UPLOADDATE, FILENAME,FILEPATH) values (@appid, @update, @fname, @fpath)";
            SqlCommand cmdUpload3 = new SqlCommand(strInsert3, con);
            cmdUpload3.Parameters.AddWithValue("@appid", Session["APPID"].ToString());
            cmdUpload3.Parameters.AddWithValue("@update", DateTime.Now);
            cmdUpload3.Parameters.AddWithValue("@fname", file2222);
            cmdUpload3.Parameters.AddWithValue("@fpath", file1111);
            cmdUpload3.ExecuteNonQuery();

            upldStudyPlan.PostedFile.SaveAs(saveLocation);
            upldAcceptanceLetter.PostedFile.SaveAs(saveLocation1);
            upldBankBookCopy.PostedFile.SaveAs(saveLocation2);
            upldICCopy.PostedFile.SaveAs(saveLocation3);

            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Upload Successfull.');window.location='frmDeclaration.aspx';</script>'");
            //Response.Redirect("frmDeclaration.aspx");
        }
        else
        {
            string script = "alert('Upload Failed. Please try again'); window.location.reload();\n";
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", script, true);
        }

        con.Close();
    }
}