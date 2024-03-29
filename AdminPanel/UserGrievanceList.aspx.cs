using GrievanceSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_UserGrievanceList : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Valid User
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/AdminPanel/Login.aspx");
        }
        #endregion Check Valid User

        #region Page Not post Back
        if (!Page.IsPostBack)
        {
            lblPageTittle.Text = "Grievance List";
            lblBreadcrumb.Text = lblPageTittle.Text;
            if (Request.UrlReferrer != null)
            {
                string previousPageName = System.IO.Path.GetFileName(Request.UrlReferrer.AbsolutePath);
                if (previousPageName == "StudentGrievanceDetail.aspx")
                {
                    upnlStudentGrievance.Visible = true;
                    upnlStaffGrievance.Visible = false;
                    btnStaffGrievance.Enabled = true;
                    btnStudentGrievance.Enabled = false;
                    lblCardTitle.Text = "Student Grievance List";
                    FillGridViewStudentGrievance();
                }
                else
                {
                    lblCardTitle.Text = "Staff Grievance List";
                    FillGridViewStaffGrievance();
                }
            }
            else
            {
                lblCardTitle.Text = "Staff Grievance List";
                FillGridViewStaffGrievance();
            }
            
        }
        #endregion Page Not post Back
    }
    #endregion Page Load

    #region Button StaffGrievance - Click
    protected void btnStaffGrievance_Click(object sender, EventArgs e)
    {
        upnlStudentGrievance.Visible = false;
        upnlNoDataFound.Visible = false;
        upnlStaffGrievance.Visible = true;
        btnStaffGrievance.Enabled = false;
        btnStudentGrievance.Enabled = true;
        lblCardTitle.Text = "Staff Grievance List";
        FillGridViewStaffGrievance();
    }
    #endregion Button StaffGrievance - Click

    #region Button StudentGrievance - Click
    protected void btnStudentGrievance_Click(object sender, EventArgs e)
    {
        upnlStaffGrievance.Visible = false;
        upnlNoDataFound.Visible = false;
        upnlStudentGrievance.Visible = true;
        btnStudentGrievance.Enabled = false;
        btnStaffGrievance.Enabled = true;
        lblCardTitle.Text = "Student Grievance List";
        FillGridViewStudentGrievance();
    }
    #endregion Button StudentGrievance - Click

    #region Fill Staff Grievance GridView
    private void FillGridViewStaffGrievance()
    {
        StaffGrievanceBAL balStaffGrievance = new StaffGrievanceBAL();
        DataTable dtStaffGrievance = new DataTable();

        dtStaffGrievance = balStaffGrievance.SelectAll();

        if (dtStaffGrievance != null && dtStaffGrievance.Rows.Count > 0)
        {
            gvStaffGrievance.DataSource = dtStaffGrievance;
            gvStaffGrievance.DataBind();
            upnlNoDataFound.Visible = false;
        }
        else
        {
            upnlStaffGrievance.Visible = false;
            upnlNoDataFound.Visible = true;
        }
    }
    #endregion Fill Staff Grievance GridView

    #region Fill Student Grievance GridView
    private void FillGridViewStudentGrievance()
    {
        StudentGrievanceBAL balStudentGrievance = new StudentGrievanceBAL();
        DataTable dtStudentGrievance = new DataTable();

        dtStudentGrievance = balStudentGrievance.SelectAll();

        if (dtStudentGrievance != null && dtStudentGrievance.Rows.Count > 0)
        {
            gvStudentGrievance.DataSource = dtStudentGrievance;
            gvStudentGrievance.DataBind();
            upnlNoDataFound.Visible = false;
        }
        else
        {
            upnlStudentGrievance.Visible = false;
            upnlNoDataFound.Visible = true;
        }
    }
    #endregion Fill Student Grievance GridView
}