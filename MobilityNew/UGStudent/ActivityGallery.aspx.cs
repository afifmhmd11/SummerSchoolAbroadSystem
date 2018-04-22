using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class UGStudent_ActivityGallery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int appid = Int32.Parse(Session["APPID"].ToString());
        DataTable dt = new DataTable();
        dt = selectAttachment(appid);
        rptGallery.DataSource = dt;
        rptGallery.DataBind();

 
    }

    public DataTable selectAttachment(int appid)
    {
        string query = "SELECT * FROM ATTACHMENT WHERE APPID  = " + appid + "";

        string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        if (sda.Fill(dt) != 0)
                        {
                            return dt;
                        }
                        else return null;

                    }
                }
            }
        }
    }
}