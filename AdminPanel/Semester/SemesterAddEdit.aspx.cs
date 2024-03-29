using GrievanceSystem;
using GrievanceSystem.BAL;
using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Semester_SemesterAddEdit : System.Web.UI.Page
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
            FillDropDownListCourse();
            if (Request.QueryString["SemesterID"] == null)
            {
                lblPageTittle.Text = "Semester Add";
                lblCardTitle.Text = lblPageTittle.Text;
                lblBreadcrumb.Text = lblPageTittle.Text;
                btnSubmit.Text = "Submit";
            }
            else
            {
                lblPageTittle.Text = "Semester Edit";
                lblCardTitle.Text = lblPageTittle.Text;
                lblBreadcrumb.Text = lblPageTittle.Text;
                btnSubmit.Text = "Update";
                FillControls(Convert.ToInt32(Request.QueryString["SemesterID"]));
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
        if (txtSemesterNumber.Text.Trim() == "")
        {
            strErrorMessage += "Please enter Semester Number <br />";
        }

        if (ddlDepartmentName.SelectedIndex == 0)
        {
            strErrorMessage += "Please select Department Name <br />";
        }

        if (ddlCourseName.SelectedIndex == 0)
        {
            strErrorMessage += "Please select Course Name <br />";
        }

        if (strErrorMessage.Trim() != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            pnlErrorMessage.Visible = true;
            return;
        }
        #endregion Server Side Validation

        #region Collect Form Data
        SemesterENT entSemester = new SemesterENT();

        if (txtSemesterNumber.Text.Trim() != "")
            entSemester.SemesterNumber = Convert.ToInt32(txtSemesterNumber.Text.Trim());

        if (ddlDepartmentName.SelectedIndex > 0)
            entSemester.DepartmentID = Convert.ToInt32(ddlDepartmentName.SelectedValue);

        if (ddlCourseName.SelectedIndex > 0)
            entSemester.CourseID = Convert.ToInt32(ddlCourseName.SelectedValue);
        #endregion Collect Form Data

        #region Insert
        SemesterBAL balSemester = new SemesterBAL();

        if (Request.QueryString["SemesterID"] == null)
        {
            if (balSemester.Insert(entSemester))
            {
                ClearControls();
                lblSuccessMessage.Text = "Data Inserted Successfully";
                pnlSuccessMessage.Visible = true;
            }
            else
            {
                lblErrorMessage.Text = balSemester.Message;
                pnlErrorMessage.Visible = true;
            }
        }
        else
        {
            entSemester.SemesterID = Convert.ToInt32(Request.QueryString["SemesterID"]);

            if (balSemester.Update(entSemester))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/Semester/SemesterList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balSemester.Message;
                pnlErrorMessage.Visible = true;
            }
        }
        #endregion Insert
    }
    #endregion Button: Submit - Click

    #region Button: Back - Click
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Semester/SemesterList.aspx");
    }
    #endregion Button: Back - Click

    #region Button: Reset - Click
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtSemesterNumber.Text = "";
        ddlDepartmentName.SelectedIndex = 0;
        ddlCourseName.SelectedIndex = 0;

        txtSemesterNumber.Focus();
    }
    #endregion Button: Reset - Click

    #region Clear Controls
    private void ClearControls()
    {
        txtSemesterNumber.Text = "";
        ddlDepartmentName.SelectedIndex = 0;
        ddlCourseName.SelectedIndex = 0;

        txtSemesterNumber.Focus();
    }
    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 SemesterID)
    {
        SemesterENT entSemester = new SemesterENT();
        SemesterBAL balSemester = new SemesterBAL();

        entSemester = balSemester.SelectByPK(SemesterID);

        if (!entSemester.SemesterNumber.IsNull)
            txtSemesterNumber.Text = entSemester.SemesterNumber.Value.ToString();

        if (!entSemester.CourseID.IsNull)
            CommonFillMethods.FillDropDownListCourse(ddlCourseName);
            ddlCourseName.SelectedValue = entSemester.CourseID.Value.ToString();

        if (!entSemester.DepartmentID.IsNull)
        {
            CommonFillMethods.FillDropDownListDepartmentByCourseID(ddlDepartmentName,Convert.ToInt32(entSemester.CourseID.Value.ToString()));
            ddlDepartmentName.SelectedValue = entSemester.DepartmentID.Value.ToString();
        }
    }
    #endregion Fill Controls

    #region FillDropDownList - Course
    public void FillDropDownListCourse()
    {
        CommonFillMethods.FillDropDownListCourse(ddlCourseName);
    }
    #endregion FillDorpDownList - Course

    #region Selected Index Changed - Course
    protected void ddlCourseName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourseName.SelectedIndex > 0)
        {
            CommonFillMethods.FillDropDownListDepartmentByCourseID(ddlDepartmentName, Convert.ToInt32(ddlCourseName.SelectedValue));
        }
        else
        {
            CommonFillMethods.FillDropDownListEmpty(ddlDepartmentName, "State");
        }
    }
    #endregion Selected Index Changed - Course
}