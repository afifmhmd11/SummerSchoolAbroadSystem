using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UTMIAR_Dashboard : System.Web.UI.Page
{
    protected void MOBILITY_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("frmInbox.aspx");
    }
}