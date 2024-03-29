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

public partial class AdminPanel_Staff_StaffAddEdit : System.Web.UI.Page
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
            if (Request.QueryString["StaffID"] == null)
            {
                lblPageTittle.Text = "Staff Add";
                lblCardTitle.Text = lblPageTittle.Text;
                lblBreadcrumb.Text = lblPageTittle.Text;
                btnSubmit.Text = "Submit";
            }
            else
            {
                lblPageTittle.Text = "Staff Edit";
                lblCardTitle.Text = lblPageTittle.Text;
                lblBreadcrumb.Text = lblPageTittle.Text;
                btnSubmit.Text = "Update";
                FillControls(Convert.ToInt32(Request.QueryString["StaffID"]));
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
        if (txtStaffFirstName.Text.Trim() == "")
        {
            strErrorMessage += "Please enter First Name <br />";
        }

        if (txtStaffMiddleName.Text.Trim() == "")
        {
            strErrorMessage += "Please enter Middle Name <br />";
        }

        if (txtStaffLastName.Text.Trim() == "")
        {
            strErrorMessage += "Please enter Last Name <br />";
        }

        if (txtStaffCode.Text.Trim() == "")
        {
            strErrorMessage += "Please enter Staff Code <br />";
        }

        if (txtStaffMobileNumber.Text.Trim() == "")
        {
            strErrorMessage += "Please enter Mobile Number <br />";
        }

        if (txtStaffPersonalEmailAddress.Text.Trim() == "")
        {
            strErrorMessage += "Please enter Personal Email <br />";
        }

        if (txtStaffCollegeEmailAddress.Text.Trim() == "")
        {
            strErrorMessage += "Please enter College Email <br />";
        }

        if (txtStaffJoiningYear.Text.Trim() == "")
        {
            strErrorMessage += "Please enter Joining Year <br />";
        }

        if (ddlDepartmentName.SelectedIndex <= 0)
        {
            strErrorMessage += "Please select Department Name <br />";
        }

        if (ddlCourseName.SelectedIndex == 0)
        {
            strErrorMessage += "Please select Course Name <br />";
        }

        if (txtPassword.Text.Trim() == "")
        {
            strErrorMessage += "Please enter Password <br />";
        }

        if (strErrorMessage.Trim() != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            pnlErrorMessage.Visible = true;
            return;
        }
        #endregion Server Side Validation

        #region Collect Form Data
        StaffENT entStaff = new StaffENT();
        StaffLoginDetailENT entStaffLoginDetail = new StaffLoginDetailENT();

        if (txtStaffFirstName.Text.Trim() != "")
            entStaff.StaffFirstName = txtStaffFirstName.Text.Trim();

        if (txtStaffMiddleName.Text.Trim() != "")
            entStaff.StaffMiddleName = txtStaffMiddleName.Text.Trim();

        if (txtStaffLastName.Text.Trim() != "")
            entStaff.StaffLastName = txtStaffLastName.Text.Trim();

        if (txtStaffCode.Text.Trim() != "")
            entStaff.StaffCode = txtStaffCode.Text.Trim();

        if (txtStaffMobileNumber.Text.Trim() != "")
            entStaff.StaffMobileNumber = txtStaffMobileNumber.Text.Trim();

        if (txtStaffPersonalEmailAddress.Text.Trim() != "")
            entStaff.StaffPersonalEmailAddress = txtStaffPersonalEmailAddress.Text.Trim();

        if (txtStaffCollegeEmailAddress.Text.Trim() != "")
            entStaff.StaffCollegeEmailAddress = txtStaffCollegeEmailAddress.Text.Trim();

        if (txtStaffJoiningYear.Text.Trim() != "")
            entStaff.StaffJoiningYear = Convert.ToInt32(txtStaffJoiningYear.Text.Trim());

        if (ddlDepartmentName.SelectedIndex > 0)
            entStaff.DepartmentID = Convert.ToInt32(ddlDepartmentName.SelectedValue);

        if (ddlCourseName.SelectedIndex > 0)
            entStaff.CourseID = Convert.ToInt32(ddlCourseName.SelectedValue);

        if (txtPassword.Text.Trim() != "")
            entStaffLoginDetail.StaffPassword = txtPassword.Text.Trim();
        #endregion Collect Form Data

        #region Insert
        StaffBAL balStaff = new StaffBAL();
        StaffLoginDetailBAL balStaffLoginDetail = new StaffLoginDetailBAL();

        if (Request.QueryString["StaffID"] == null)
        {
            if (balStaff.Insert(entStaff))
            {
                entStaffLoginDetail.StaffID = entStaff.StaffID;
                if (balStaffLoginDetail.Insert(entStaffLoginDetail))
                {
                    ClearControls();
                    lblSuccessMessage.Text = "Data Inserted Successfully";
                    pnlSuccessMessage.Visible = true;
                }
            }
            else
            {
                lblErrorMessage.Text = balStaff.Message;
                lblErrorMessage.Text = balStaffLoginDetail.Message;
                pnlErrorMessage.Visible = true;
            }
        }
        else
        {
            entStaff.StaffID = Convert.ToInt32(Request.QueryString["StaffID"]);

            if (balStaff.Update(entStaff))
            {
                entStaffLoginDetail.StaffID = entStaff.StaffID;
                if (balStaffLoginDetail.UpdateByStaffID(entStaffLoginDetail))
                {
                    ClearControls();
                    Response.Redirect("~/AdminPanel/Staff/StaffList.aspx");
                }
            }
            else
            {
                lblErrorMessage.Text = balStaff.Message;
                lblErrorMessage.Text = balStaffLoginDetail.Message;
                pnlErrorMessage.Visible = true;
            }
        }
        #endregion Insert
    }
    #endregion Button: Submit - Click

    #region Button: Back - Click
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Staff/StaffList.aspx");
    }
    #endregion Button: Back - Click

    #region Button: Reset - Click
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtStaffFirstName.Text = "";
        txtStaffMiddleName.Text = "";
        txtStaffLastName.Text = "";
        txtStaffCode.Text = "";
        txtStaffMobileNumber.Text = "";
        txtStaffPersonalEmailAddress.Text = "";
        txtStaffCollegeEmailAddress.Text = "";
        txtStaffJoiningYear.Text = "";
        ddlDepartmentName.SelectedIndex = 0;
        ddlCourseName.SelectedIndex = 0;
        txtPassword.Text = "";

        txtStaffFirstName.Focus();
    }
    #endregion Button: Reset - Click

    #region Clear Controls
    private void ClearControls()
    {
        txtStaffFirstName.Text = "";
        txtStaffMiddleName.Text = "";
        txtStaffLastName.Text = "";
        txtStaffCode.Text = "";
        txtStaffMobileNumber.Text = "";
        txtStaffPersonalEmailAddress.Text = "";
        txtStaffCollegeEmailAddress.Text = "";
        txtStaffJoiningYear.Text = "";
        ddlDepartmentName.SelectedIndex = 0;
        ddlCourseName.SelectedIndex = 0;
        txtPassword.Text = "";

        txtStaffFirstName.Focus();
    }
    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 StaffID)
    {
        StaffENT entStaff = new StaffENT();
        StaffBAL balStaff = new StaffBAL();
        StaffLoginDetailENT entStaffLoginDetail = new StaffLoginDetailENT();
        StaffLoginDetailBAL balStaffLoginDetail = new StaffLoginDetailBAL();

        entStaff = balStaff.SelectByPK(StaffID);
        entStaffLoginDetail = balStaffLoginDetail.SelectByStaffID(StaffID);

        if (!entStaff.StaffFirstName.IsNull)
            txtStaffFirstName.Text = entStaff.StaffFirstName.Value.ToString();

        if (!entStaff.StaffMiddleName.IsNull)
            txtStaffMiddleName.Text = entStaff.StaffMiddleName.Value.ToString();

        if (!entStaff.StaffLastName.IsNull)
            txtStaffLastName.Text = entStaff.StaffLastName.Value.ToString();

        if (!entStaff.StaffCode.IsNull)
            txtStaffCode.Text = entStaff.StaffCode.Value.ToString();

        if (!entStaff.StaffMobileNumber.IsNull)
            txtStaffMobileNumber.Text = entStaff.StaffMobileNumber.Value.ToString();

        if (!entStaff.StaffPersonalEmailAddress.IsNull)
            txtStaffPersonalEmailAddress.Text = entStaff.StaffPersonalEmailAddress.Value.ToString();

        if (!entStaff.StaffCollegeEmailAddress.IsNull)
            txtStaffCollegeEmailAddress.Text = entStaff.StaffCollegeEmailAddress.Value.ToString();

        if (!entStaff.StaffJoiningYear.IsNull)
            txtStaffJoiningYear.Text = entStaff.StaffJoiningYear.Value.ToString();

        if (!entStaff.DepartmentID.IsNull)
        {
            CommonFillMethods.FillDropDownListDepartmentByCourseID(ddlDepartmentName, Convert.ToInt32(entStaff.CourseID.Value.ToString()));
            ddlDepartmentName.SelectedValue = entStaff.DepartmentID.Value.ToString();
        }

        if (!entStaff.CourseID.IsNull)
        {
            CommonFillMethods.FillDropDownListCourse(ddlCourseName);
            ddlCourseName.SelectedValue = entStaff.CourseID.Value.ToString();
        }

        if (!entStaffLoginDetail.StaffPassword.IsNull)
            txtPassword.Text = entStaffLoginDetail.StaffPassword.Value.ToString();
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