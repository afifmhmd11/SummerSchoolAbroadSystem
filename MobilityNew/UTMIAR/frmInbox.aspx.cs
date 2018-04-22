using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UTMIAR_frmInbox : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //protected void ViewStudApp(object sender, EventArgs e)
    //{
    //    string APP_APPID = (sender as LinkButton).CommandArgument;
    //    Session.Add("APP_APPID", APP_APPID);
    //    Response.Redirect("frmViewStudApp.aspx");
    //}

    protected void ViewStudent(object sender, EventArgs e)
    {
        string matric = (sender as LinkButton).CommandArgument;
        //Session.Add("MATRIC", matric);
        Session["StudentView"] = matric;
        Response.Redirect("frmViewStudApp.aspx");
    }
}