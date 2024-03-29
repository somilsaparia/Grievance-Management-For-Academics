using GrievanceSystem.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Course_CourseList : System.Web.UI.Page
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
            lblPageTittle.Text = "Course List";
            lblCardTitle.Text = lblPageTittle.Text;
            lblBreadcrumb.Text = lblPageTittle.Text;
            FillGridViewCourse();
        }
        #endregion Page Not post Back
    }
    #endregion Page Load

    #region Fill Course GridView
    private void FillGridViewCourse()
    {
        CourseBAL balCourse = new CourseBAL();
        DataTable dtCourse = new DataTable();

        dtCourse = balCourse.SelectAll();

        if (dtCourse != null && dtCourse.Rows.Count > 0)
        {
            gvCourse.DataSource = dtCourse;
            gvCourse.DataBind();
            upnlNoDataFound.Visible = false;
            upnlCourseList.Visible = true;
        }
        else
        {
            upnlCourseList.Visible = false;
            upnlNoDataFound.Visible = true;
        }
    }
    #endregion Fill Course GridView

    #region GridView: Course - RowCommand
    protected void gvCourse_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                CourseBAL balCourse = new CourseBAL();
                if (balCourse.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    lblSuccessMessage.Text = "Course Deleted Successfully";
                    pnlSuccessMessage.Visible = true;
                    Response.Redirect("~/AdminPanel/Course/CourseList.aspx");
                }
                else
                {
                    lblErrorMessage.Text = balCourse.Message;
                }
            }
        }
    }
    #endregion GridView: Course - RowCommand

    #region Button Add - Click
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Course/CourseAddEdit.aspx");
    }
    #endregion Button Add - Click
}