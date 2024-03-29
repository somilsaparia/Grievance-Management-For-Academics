using GrievanceSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Semester_SemesterList : System.Web.UI.Page
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
            lblPageTittle.Text = "Semester List";
            lblCardTitle.Text = lblPageTittle.Text;
            lblBreadcrumb.Text = lblPageTittle.Text;
            FillGridViewSemester();
        }
        #endregion Page Not post Back
    }
    #endregion Page Load

    #region Fill Semester GridView
    private void FillGridViewSemester()
    {
        SemesterBAL balSemester = new SemesterBAL();
        DataTable dtSemester = new DataTable();

        dtSemester = balSemester.SelectAll();

        if (dtSemester != null && dtSemester.Rows.Count > 0)
        {
            gvSemester.DataSource = dtSemester;
            gvSemester.DataBind();
            upnlSemesterList.Visible = true;
            upnlNoDataFound.Visible = false;
        }
        else
        {
            upnlSemesterList.Visible = false;
            upnlNoDataFound.Visible = true;
        }
    }
    #endregion Fill Semester GridView

    #region GridView: Semester - RowCommand
    protected void gvSemester_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                SemesterBAL balSemester = new SemesterBAL();
                if (balSemester.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    lblSuccessMessage.Text = "Semester Deleted Successfully";
                    pnlSuccessMessage.Visible = true;
                    Response.Redirect("~/AdminPanel/Semester/SemesterList.aspx");
                }
                else
                {
                    lblErrorMessage.Text = balSemester.Message;
                }
            }
        }
    }
    #endregion GridView: Semester - RowCommand

    #region Button Add - Click
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Semester/SemesterAddEdit.aspx");
    }
    #endregion Button Add - Click
}