using GrievanceSystem.BAL;
using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Course_CourseAddEdit : System.Web.UI.Page
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

        #region Page Not Post Back
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CourseID"] == null)
            {
                lblPageTittle.Text = "Course Add";
                lblCardTitle.Text = lblPageTittle.Text;
                lblBreadcrumb.Text = lblPageTittle.Text;
                btnSubmit.Text = "Submit";
            }
            else
            {
                lblPageTittle.Text = "Course Edit";
                lblCardTitle.Text = lblPageTittle.Text;
                lblBreadcrumb.Text = lblPageTittle.Text;
                btnSubmit.Text = "Update";
                FillControls(Convert.ToInt32(Request.QueryString["CourseID"]));
            }
        }
        #endregion Page Not Post Back
    }
    #endregion Page Load

    #region Button: Submit - Click
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Local Variables
        string strErrorMessage = "";
        #endregion Local Variables

        #region Server Side Validation
        if (txtCourseName.Text.Trim() == "")
        {
            strErrorMessage += "Please enter Course Name <br />";
        }

        if (strErrorMessage.Trim() != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            pnlErrorMessage.Visible = true;
            return;
        }
        #endregion Server Side Validation

        #region Collect Form Data
        CourseENT entCourse = new CourseENT();

        if (txtCourseName.Text.Trim() != "")
            entCourse.CourseName = txtCourseName.Text.Trim();
        #endregion Collect Form Data

        #region Insert
        CourseBAL balCourse = new CourseBAL();

        if (Request.QueryString["CourseID"] == null)
        {
            if (balCourse.Insert(entCourse))
            {
                ClearControls();
                lblSuccessMessage.Text = "Data Inserted Successfully";
                pnlSuccessMessage.Visible = true;
            }
            else
            {
                lblErrorMessage.Text = balCourse.Message;
                pnlErrorMessage.Visible = true;
            }
        }
        else
        {
            entCourse.CourseID = Convert.ToInt32(Request.QueryString["CourseID"]);

            if (balCourse.Update(entCourse))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/Course/CourseList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balCourse.Message;
                pnlErrorMessage.Visible = true;
            }
        }
        #endregion Insert
    }
    #endregion Button: Submit - Click

    #region Button: Back - Click
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Course/CourseList.aspx");
    }
    #endregion Button: Back - Click

    #region Button: Reset - Click
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtCourseName.Text = "";

        txtCourseName.Focus();
    }
    #endregion Button: Reset - Click

    #region Clear Controls
    private void ClearControls()
    {
        txtCourseName.Text = "";

        txtCourseName.Focus();
    }
    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 CourseID)
    {
        CourseENT entCourse = new CourseENT();
        CourseBAL balCourse = new CourseBAL();

        entCourse = balCourse.SelectByPK(CourseID);

        if (!entCourse.CourseName.IsNull)
            txtCourseName.Text = entCourse.CourseName.Value.ToString();
    }
    #endregion Fill Controls
}