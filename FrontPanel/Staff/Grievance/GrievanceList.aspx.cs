using GrievanceSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontPanel_Staff_Grievance_GrievanceList : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Valid User
        if (Session["StaffID"] == null)
        {
            Response.Redirect("~/AdminPanel/Login.aspx");
        }
        #endregion Check Valid User

        #region Page Not post Back
        if (!Page.IsPostBack)
        {
            lblPageTittle.Text = "All Grievance";
            lblCardTitle.Text = lblPageTittle.Text;
            lblBreadcrumb.Text = lblPageTittle.Text;
            FillGridViewGrievance();
        }
        #endregion Page Not post Back
    }
    #endregion Page Load

    #region Fill Staff Grievance GridView
    private void FillGridViewGrievance()
    {
        StaffGrievanceBAL balStaffGrievance = new StaffGrievanceBAL();
        DataTable dtStaffGrievance = new DataTable();

        dtStaffGrievance = balStaffGrievance.SelectAllByStaffID(Convert.ToInt32(Session["StaffID"]));

        if (dtStaffGrievance != null && dtStaffGrievance.Rows.Count > 0)
        {
            gvStaffGrievance.DataSource = dtStaffGrievance;
            gvStaffGrievance.DataBind();
        }
        else
        {
            upnlStaffGrievance.Visible = false;
            upnlNoDataFound.Visible = true;
        }
    }
    #endregion Fill Staff Grievance GridView

    #region GridView: Staff Grievance - RowCommand
    protected void gvStaffGrievance_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                StaffGrievanceBAL balStaffGrievance = new StaffGrievanceBAL();
                if (balStaffGrievance.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    lblSuccessMessage.Text = "Grievance Deleted Successfully";
                    pnlSuccessMessage.Visible = true;
                    Response.Redirect("~/FrontPanel/Staff/Grievance/GrievanceList.aspx");
                }
                else
                {
                    lblErrorMessage.Text = balStaffGrievance.Message;
                }
            }
        }
    }
    #endregion GridView: Staff Grievance - RowCommand

    #region Button AllGrievance - Click
    protected void btnAllGrievance_Click(object sender, EventArgs e)
    {
        btnAllGrievance.Enabled = false;
        btnNewGrievance.Enabled = true;
        btnInProgressGrievance.Enabled = true;
        btnResolvedGrievance.Enabled = true;
        btnRejectedGrievance.Enabled = true;

        StaffGrievanceBAL balStaffGrievance = new StaffGrievanceBAL();
        DataTable dtStaffGrievance = new DataTable();

        lblCardTitle.Text = "All Grievance List";
        dtStaffGrievance = balStaffGrievance.SelectAllByStaffID(Convert.ToInt32(Session["StaffID"]));

        if (dtStaffGrievance != null && dtStaffGrievance.Rows.Count > 0)
        {
            gvStaffGrievance.DataSource = dtStaffGrievance;
            gvStaffGrievance.DataBind();
            upnlStaffGrievance.Visible = true;
            upnlNoDataFound.Visible = false;
        }
        else
        {
            upnlStaffGrievance.Visible = false;
            upnlNoDataFound.Visible = true;
        }
    }
    #endregion Button AllGrievance - Click

    #region Button NewGrievance - Click
    protected void btnNewGrievance_Click(object sender, EventArgs e)
    {
        btnAllGrievance.Enabled = true;
        btnNewGrievance.Enabled = false;
        btnInProgressGrievance.Enabled = true;
        btnResolvedGrievance.Enabled = true;
        btnRejectedGrievance.Enabled = true;

        StaffGrievanceBAL balStaffGrievance = new StaffGrievanceBAL();
        DataTable dtStaffGrievance = new DataTable();

        lblCardTitle.Text = "New Grievance List";
        dtStaffGrievance = balStaffGrievance.SelectRegisteredByStaffID(Convert.ToInt32(Session["StaffID"]));

        if (dtStaffGrievance != null && dtStaffGrievance.Rows.Count > 0)
        {
            gvStaffGrievance.DataSource = dtStaffGrievance;
            gvStaffGrievance.DataBind();
            upnlStaffGrievance.Visible = true;
            upnlNoDataFound.Visible = false;
        }
        else
        {
            upnlStaffGrievance.Visible = false;
            upnlNoDataFound.Visible = true;
        }
    }
    #endregion Button NewGrievance - Click

    #region Button InProgressGrievance - Click
    protected void btnInProgressGrievance_Click(object sender, EventArgs e)
    {
        btnAllGrievance.Enabled = true;
        btnNewGrievance.Enabled = true;
        btnInProgressGrievance.Enabled = false;
        btnResolvedGrievance.Enabled = true;
        btnRejectedGrievance.Enabled = true;

        StaffGrievanceBAL balStaffGrievance = new StaffGrievanceBAL();
        DataTable dtStaffGrievance = new DataTable();

        lblCardTitle.Text = "In-Progress Grievance List";
        dtStaffGrievance = balStaffGrievance.SelectInProgressByStaffID(Convert.ToInt32(Session["StaffID"]));

        if (dtStaffGrievance != null && dtStaffGrievance.Rows.Count > 0)
        {
            gvStaffGrievance.DataSource = dtStaffGrievance;
            gvStaffGrievance.DataBind();
            upnlStaffGrievance.Visible = true;
            upnlNoDataFound.Visible = false;
        }
        else
        {
            upnlStaffGrievance.Visible = false;
            upnlNoDataFound.Visible = true;
        }
    }
    #endregion Button InProgressGrievance - Click

    #region Button ResolvedGrievance - Click
    protected void btnResolvedGrievance_Click(object sender, EventArgs e)
    {
        btnAllGrievance.Enabled = true;
        btnNewGrievance.Enabled = true;
        btnInProgressGrievance.Enabled = true;
        btnResolvedGrievance.Enabled = false;
        btnRejectedGrievance.Enabled = true;

        StaffGrievanceBAL balStaffGrievance = new StaffGrievanceBAL();
        DataTable dtStaffGrievance = new DataTable();

        lblCardTitle.Text = "Resolved Grievance List";
        dtStaffGrievance = balStaffGrievance.SelectResolveByStaffID(Convert.ToInt32(Session["StaffID"]));

        if (dtStaffGrievance != null && dtStaffGrievance.Rows.Count > 0)
        {
            gvStaffGrievance.DataSource = dtStaffGrievance;
            gvStaffGrievance.DataBind();
            upnlStaffGrievance.Visible = true;
            upnlNoDataFound.Visible = false;
        }
        else
        {
            upnlStaffGrievance.Visible = false;
            upnlNoDataFound.Visible = true;
        }
    }
    #endregion Button ResolvedGrievance - Click

    #region Button RejectedGrievance - Click
    protected void btnRejectedGrievance_Click(object sender, EventArgs e)
    {
        btnAllGrievance.Enabled = true;
        btnNewGrievance.Enabled = true;
        btnInProgressGrievance.Enabled = true;
        btnResolvedGrievance.Enabled = true;
        btnRejectedGrievance.Enabled = false;

        StaffGrievanceBAL balStaffGrievance = new StaffGrievanceBAL();
        DataTable dtStaffGrievance = new DataTable();

        lblCardTitle.Text = "Rejected Grievance List";
        dtStaffGrievance = balStaffGrievance.SelectRejectedByStaffID(Convert.ToInt32(Session["StaffID"]));

        if (dtStaffGrievance != null && dtStaffGrievance.Rows.Count > 0)
        {
            gvStaffGrievance.DataSource = dtStaffGrievance;
            gvStaffGrievance.DataBind();
            upnlStaffGrievance.Visible = true;
            upnlNoDataFound.Visible = false ;
        }
        else
        {
            upnlStaffGrievance.Visible = false;
            upnlNoDataFound.Visible = true;
        }
    }
    #endregion Button RejectedGrievance - Click

    #region Button Add - Click
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FrontPanel/Staff/Grievance/GrievanceAddEdit.aspx");
    }
    #endregion Button Add - Click
}