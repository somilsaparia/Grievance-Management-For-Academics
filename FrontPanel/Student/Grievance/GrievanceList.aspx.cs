using GrievanceSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontPanel_Student_Grievance_GrievanceList : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Valid User
        if (Session["StudentID"] == null)
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
    #endregion Page Laod

    #region Fill Student Grievance GridView
    private void FillGridViewGrievance()
    {
        StudentGrievanceBAL balStudentGrievance = new StudentGrievanceBAL();
        DataTable dtStudentGrievance = new DataTable();

        dtStudentGrievance = balStudentGrievance.SelectAllByStudentID(Convert.ToInt32(Session["StudentID"]));

        if (dtStudentGrievance != null && dtStudentGrievance.Rows.Count > 0)
        {
            gvStudentGrievance.DataSource = dtStudentGrievance;
            gvStudentGrievance.DataBind();
        }
        else
        {
            upnlStudentGrievance.Visible = false;
            upnlNoDataFound.Visible = true;
        }
    }
    #endregion Fill Staff Grievance GridView

    #region GridView: Student Grievance - RowCommand
    protected void gvStudentGrievance_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                StudentGrievanceBAL balStudentGrievance = new StudentGrievanceBAL();
                if (balStudentGrievance.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    lblSuccessMessage.Text = "Grievance Deleted Successfully";
                    pnlSuccessMessage.Visible = true;
                    Response.Redirect("~/FrontPanel/Student/Grievance/GrievanceList.aspx?");
                }
                else
                {
                    lblErrorMessage.Text = balStudentGrievance.Message;
                }
            }
        }
    }
    #endregion GridView: Student Grievance - RowCommand

    #region Button AllGrievance - Click
    protected void btnAllGrievance_Click(object sender, EventArgs e)
    {
        btnAllGrievance.Enabled = false;
        btnNewGrievance.Enabled = true;
        btnInProgressGrievance.Enabled = true;
        btnResolvedGrievance.Enabled = true;
        btnRejectedGrievance.Enabled = true;

        StudentGrievanceBAL balStudentGrievance = new StudentGrievanceBAL();
        DataTable dtStudentGrievance = new DataTable();

        lblCardTitle.Text = "All Grievance List";
        dtStudentGrievance = balStudentGrievance.SelectAllByStudentID(Convert.ToInt32(Session["StudentID"]));

        if (dtStudentGrievance != null && dtStudentGrievance.Rows.Count > 0)
        {
            gvStudentGrievance.DataSource = dtStudentGrievance;
            gvStudentGrievance.DataBind();
            upnlStudentGrievance.Visible = true;
            upnlNoDataFound.Visible = false;
        }
        else
        {
            upnlStudentGrievance.Visible = false;
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

        StudentGrievanceBAL balStudentGrievance = new StudentGrievanceBAL();
        DataTable dtStudentGrievance = new DataTable();

        lblCardTitle.Text = "New Grievance List";
        dtStudentGrievance = balStudentGrievance.SelectRegisteredByStudentID(Convert.ToInt32(Session["StudentID"]));

        if (dtStudentGrievance != null && dtStudentGrievance.Rows.Count > 0)
        {
            gvStudentGrievance.DataSource = dtStudentGrievance;
            gvStudentGrievance.DataBind();
            upnlStudentGrievance.Visible = true;
            upnlNoDataFound.Visible = false;
        }
        else
        {
            upnlStudentGrievance.Visible = false;
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

        StudentGrievanceBAL balStudentGrievance = new StudentGrievanceBAL();
        DataTable dtStudentGrievance = new DataTable();

        lblCardTitle.Text = "New Grievance List";
        dtStudentGrievance = balStudentGrievance.SelectInProgressByStudentID(Convert.ToInt32(Session["StudentID"]));

        if (dtStudentGrievance != null && dtStudentGrievance.Rows.Count > 0)
        {
            gvStudentGrievance.DataSource = dtStudentGrievance;
            gvStudentGrievance.DataBind();
            upnlStudentGrievance.Visible = true;
            upnlNoDataFound.Visible = false;
        }
        else
        {
            upnlStudentGrievance.Visible = false;
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

        StudentGrievanceBAL balStudentGrievance = new StudentGrievanceBAL();
        DataTable dtStudentGrievance = new DataTable();

        lblCardTitle.Text = "New Grievance List";
        dtStudentGrievance = balStudentGrievance.SelectResolveByStudentID(Convert.ToInt32(Session["StudentID"]));

        if (dtStudentGrievance != null && dtStudentGrievance.Rows.Count > 0)
        {
            gvStudentGrievance.DataSource = dtStudentGrievance;
            gvStudentGrievance.DataBind();
            upnlStudentGrievance.Visible = true;
            upnlNoDataFound.Visible = false;
        }
        else
        {
            upnlStudentGrievance.Visible = false;
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

        StudentGrievanceBAL balStudentGrievance = new StudentGrievanceBAL();
        DataTable dtStudentGrievance = new DataTable();

        lblCardTitle.Text = "New Grievance List";
        dtStudentGrievance = balStudentGrievance.SelectRejectedByStudentID(Convert.ToInt32(Session["StudentID"]));

        if (dtStudentGrievance != null && dtStudentGrievance.Rows.Count > 0)
        {
            gvStudentGrievance.DataSource = dtStudentGrievance;
            gvStudentGrievance.DataBind();
            upnlStudentGrievance.Visible = true;
            upnlNoDataFound.Visible = false;
        }
        else
        {
            upnlStudentGrievance.Visible = false;
            upnlNoDataFound.Visible = true;
        }
    }
    #endregion Button RejectedGrievance - Click

    #region Button Add - Click
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FrontPanel/Student/Grievance/GrievanceAddEdit.aspx");
    }
    #endregion Button Add - Click
}