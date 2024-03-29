
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

public partial class AdminPanel_Department_DepartmentAddEdit : System.Web.UI.Page
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
            if (Request.QueryString["DepartmentID"] == null)
            {
                lblPageTittle.Text = "Department Add";
                lblCardTitle.Text = lblPageTittle.Text;
                lblBreadcrumb.Text = lblPageTittle.Text;
                btnSubmit.Text = "Submit";
            }
            else
            {
                lblPageTittle.Text = "Department Edit";
                lblCardTitle.Text = lblPageTittle.Text;
                lblBreadcrumb.Text = lblPageTittle.Text;
                btnSubmit.Text = "Update";
                FillControls(Convert.ToInt32(Request.QueryString["DepartmentID"]));
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
        if (txtDepartmentName.Text.Trim() == "")
        {
            strErrorMessage += "Please enter Department Name <br />";
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
        DepartmentENT entDepartment = new DepartmentENT();

        if (txtDepartmentName.Text.Trim() != "")
            entDepartment.DepartmentName = txtDepartmentName.Text.Trim();

        if (ddlCourseName.SelectedIndex > 0)
            entDepartment.CourseID = Convert.ToInt32(ddlCourseName.SelectedValue);
        #endregion Collect Form Data

        #region Insert
        DepartmentBAL balDepartment = new DepartmentBAL();

        if (Request.QueryString["DepartmentID"] == null)
        {
            if (balDepartment.Insert(entDepartment))
            {
                ClearControls();
                lblSuccessMessage.Text = "Data Inserted Successfully";
                pnlSuccessMessage.Visible = true;
            }
            else
            {
                lblErrorMessage.Text = balDepartment.Message;
                pnlErrorMessage.Visible = true;
            }
        }
        else
        {
            entDepartment.DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

            if (balDepartment.Update(entDepartment))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/Department/DepartmentList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balDepartment.Message;
                pnlErrorMessage.Visible = true;
            }
        }
        #endregion Insert
    }
    #endregion Button: Submit - Click

    #region Button: Back - Click
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Department/DepartmentList.aspx");
    }
    #endregion Button: Back - Click

    #region Button: Reset - Click
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtDepartmentName.Text = "";
        ddlCourseName.SelectedIndex = 0;

        txtDepartmentName.Focus();
    }
    #endregion Button: Reset - Click

    #region Clear Controls
    private void ClearControls()
    {
        txtDepartmentName.Text = "";
        ddlCourseName.SelectedIndex = 0;

        txtDepartmentName.Focus();
    }
    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 DepartmentID)
    {
        DepartmentENT entDepartment = new DepartmentENT();
        DepartmentBAL balDepartment = new DepartmentBAL();

        entDepartment = balDepartment.SelectByPK(DepartmentID);

        if (!entDepartment.DepartmentName.IsNull)
            txtDepartmentName.Text = entDepartment.DepartmentName.Value.ToString();

        if (!entDepartment.CourseID.IsNull)
            ddlCourseName.SelectedValue = entDepartment.CourseID.Value.ToString();
    }
    #endregion Fill Controls

    #region FillDropDownList - Course
    public void FillDropDownListCourse()
    {
        CommonFillMethods.FillDropDownListCourse(ddlCourseName);
    }
    #endregion FillDorpDownList - Course
}