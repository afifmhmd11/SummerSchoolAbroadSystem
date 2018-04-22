﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class UTMIAR_frmProgramme : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count == 0)
        {
            lblTxtSearchResult.Visible = false;
            lblResult.Visible = false;
        }
        else
        {
            lblResult.Text = GridView1.Rows.Count.ToString();
        }
    }
    protected void btnSearch_Click1(object sender, EventArgs e)
    {
        if (txtSearch.Text.Trim().Length == 0)
        {
            GridView1.Visible = true;
            GridView2.Visible = false;
            if (GridView1.Rows.Count == 0)
            {
                lblTxtSearchResult.Visible = false;
                lblResult.Visible = false;
            }
            else
            {
                lblResult.Text = GridView1.Rows.Count.ToString();
            }
        }
        else
        {
            GridView1.Visible = false;
            GridView2.Visible = true;
            if (GridView2.Rows.Count == 0)
            {
                lblTxtSearchResult.Visible = false;
                lblResult.Visible = false;
            }
            else
            {
                lblResult.Text = GridView2.Rows.Count.ToString();
            }
        }
    }
    protected void ViewProg(object sender, EventArgs e)
    {
        string PROG_PROGID = (sender as LinkButton).CommandArgument;
        Session.Add("PROG_PROGID", PROG_PROGID);
        Response.Redirect("frmViewProg.aspx");
    }
    protected void DeleteProg(object sender, EventArgs e)
    {
        con.Open();
        string PROG_PROGID = (sender as LinkButton).CommandArgument;
        File.Delete(PROG_PROGID);

        string strQuery1 = "DELETE FROM PROGRAMME WHERE PROGID = '" + PROG_PROGID + "'";
        SqlCommand cmd = new SqlCommand(strQuery1, con);
        cmd.ExecuteNonQuery();
        GridView1.DataBind();

        con.Close();
    }
}