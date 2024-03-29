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

public partial class AdminPanel_Student_StudentAddEdit : System.Web.UI.Page
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
            if (Request.QueryString["StudentID"] == null)
            {
                lblPageTittle.Text = "Student Add";
                lblCardTitle.Text = lblPageTittle.Text;
                lblBreadcrumb.Text = lblPageTittle.Text;
                btnSubmit.Text = "Submit";
            }
            else
            {
                lblPageTittle.Text = "Student Edit";
                lblCardTitle.Text = lblPageTittle.Text;
                lblBreadcrumb.Text = lblPageTittle.Text;
                btnSubmit.Text = "Update";
                FillControls(Convert.ToInt32(Request.QueryString["StudentID"]));
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
        if (txtStudentFirstName.Text.Trim() == "")
        {
            strErrorMessage += "Please enter First Name <br />";
        }

        if (txtStudentMiddleName.Text.Trim() == "")
        {
            strErrorMessage += "Please enter Middle Name <br />";
        }

        if (txtStudentLastName.Text.Trim() == "")
        {
            strErrorMessage += "Please enter Last Name <br />";
        }

        if (txtStudentEnrollmentNumber.Text.Trim() == "")
        {
            strErrorMessage += "Please enter Enrollment Number <br />";
        }

        if (txtStudentMobileNumber.Text.Trim() == "")
        {
            strErrorMessage += "Please enter Mobile Number <br />";
        }

        if (txtStudentPersonalEmailAddress.Text.Trim() == "")
        {
            strErrorMessage += "Please enter Personal Email <br />";
        }

        if (txtStudentCollegeEmailAddress.Text.Trim() == "")
        {
            strErrorMessage += "Please enter College Email <br />";
        }

        if (ddlStudentCurrentSemester.SelectedIndex <= 0)
        {
            strErrorMessage += "Please select Current Semester <br />";
        }

        if (txtStudentAdmissionYear.Text.Trim() == "")
        {
            strErrorMessage += "Please enter Admission Year <br />";
        }

        if (ddlDepartmentName.SelectedIndex == 0)
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
        StudentENT entStudent = new StudentENT();
        StudentLoginDetailENT entStudentLoginDetail = new StudentLoginDetailENT();

        if (txtStudentFirstName.Text.Trim() != "")
            entStudent.StudentFirstName = txtStudentFirstName.Text.Trim();

        if (txtStudentMiddleName.Text.Trim() != "")
            entStudent.StudentMiddleName = txtStudentMiddleName.Text.Trim();

        if (txtStudentLastName.Text.Trim() != "")
            entStudent.StudentLastName = txtStudentLastName.Text.Trim();

        if (txtStudentEnrollmentNumber.Text.Trim() != "")
            entStudent.StudentEnrollmentNumber = txtStudentEnrollmentNumber.Text.Trim();

        if (txtStudentMobileNumber.Text.Trim() != "")
            entStudent.StudentMobileNumber = txtStudentMobileNumber.Text.Trim();

        if (txtStudentPersonalEmailAddress.Text.Trim() != "")
            entStudent.StudentPersonalEmailAddress = txtStudentPersonalEmailAddress.Text.Trim();

        if (txtStudentCollegeEmailAddress.Text.Trim() != "")
            entStudent.StudentCollegeEmailAddress = txtStudentCollegeEmailAddress.Text.Trim();

        if (ddlStudentCurrentSemester.SelectedIndex > 0)
            entStudent.StudentCurrentSemester = Convert.ToInt32(ddlStudentCurrentSemester.SelectedValue);

        if (txtStudentAdmissionYear.Text.Trim() != "")
            entStudent.StudentAdmissionYear = Convert.ToInt32(txtStudentAdmissionYear.Text.Trim());

        if (ddlDepartmentName.SelectedIndex > 0)
            entStudent.DepartmentID = Convert.ToInt32(ddlDepartmentName.SelectedValue);

        if (ddlCourseName.SelectedIndex > 0)
            entStudent.CourseID = Convert.ToInt32(ddlCourseName.SelectedValue);

        if (txtPassword.Text.Trim() != "")
            entStudentLoginDetail.StudentPassword = txtPassword.Text.Trim();
        #endregion Collect Form Data

        #region Insert
        StudentBAL balStudent = new StudentBAL();
        StudentLoginDetailBAL balStudentLoginDetail = new StudentLoginDetailBAL();

        if (Request.QueryString["StudentID"] == null)
        {
            if (balStudent.Insert(entStudent))
            {
                entStudentLoginDetail.StudentID = entStudent.StudentID;
                if (balStudentLoginDetail.Insert(entStudentLoginDetail))
                {
                    ClearControls();
                    lblSuccessMessage.Text = "Data Inserted Successfully";
                    pnlSuccessMessage.Visible = true;
                }
            }
            else
            {
                lblErrorMessage.Text = balStudent.Message;
                lblErrorMessage.Text = balStudentLoginDetail.Message;
                pnlErrorMessage.Visible = true;
            }
        }
        else
        {
            entStudent.StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

            if (balStudent.Update(entStudent))
            {
                entStudentLoginDetail.StudentID = entStudent.StudentID;
                if (balStudentLoginDetail.UpdateByStudentID(entStudentLoginDetail))
                {
                    ClearControls();
                    Response.Redirect("~/AdminPanel/Student/StudentList.aspx");
                }
            }
            else
            {
                lblErrorMessage.Text = balStudent.Message;
                lblErrorMessage.Text = balStudentLoginDetail.Message;
                pnlErrorMessage.Visible = true;
            }
        }
        #endregion Insert
    }
    #endregion Button: Submit - Click

    #region Button: Back - Click
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Student/StudentList.aspx");
    }
    #endregion Button: Back - Click

    #region Button: Reset - Click
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtStudentFirstName.Text = "";
        txtStudentMiddleName.Text = "";
        txtStudentLastName.Text = "";
        txtStudentEnrollmentNumber.Text = "";
        txtStudentMobileNumber.Text = "";
        txtStudentPersonalEmailAddress.Text = "";
        txtStudentCollegeEmailAddress.Text = "";
        ddlStudentCurrentSemester.SelectedIndex = 0;
        txtStudentAdmissionYear.Text = "";
        ddlDepartmentName.SelectedIndex = 0;
        ddlCourseName.SelectedIndex = 0;
        txtPassword.Text = "";

        txtStudentFirstName.Focus();
    }
    #endregion Button: Reset - Click

    #region Clear Controls
    private void ClearControls()
    {
        txtStudentFirstName.Text = "";
        txtStudentMiddleName.Text = "";
        txtStudentLastName.Text = "";
        txtStudentEnrollmentNumber.Text = "";
        txtStudentMobileNumber.Text = "";
        txtStudentPersonalEmailAddress.Text = "";
        txtStudentCollegeEmailAddress.Text = "";
        ddlStudentCurrentSemester.SelectedIndex = 0;
        txtStudentAdmissionYear.Text = "";
        ddlDepartmentName.SelectedIndex = 0;
        ddlCourseName.SelectedIndex = 0;
        txtPassword.Text = "";

        txtStudentFirstName.Focus();
    }
    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 StudentID)
    {
        StudentENT entStudent = new StudentENT();
        StudentBAL balStudent = new StudentBAL();
        StudentLoginDetailENT entStudentLoginDetail = new StudentLoginDetailENT();
        StudentLoginDetailBAL balStudentLoginDetail = new StudentLoginDetailBAL();

        entStudent = balStudent.SelectByPK(StudentID);
        entStudentLoginDetail = balStudentLoginDetail.SelectByStudentID(StudentID);

        if (!entStudent.StudentFirstName.IsNull)
            txtStudentFirstName.Text = entStudent.StudentFirstName.Value.ToString();

        if (!entStudent.StudentMiddleName.IsNull)
            txtStudentMiddleName.Text = entStudent.StudentMiddleName.Value.ToString();

        if (!entStudent.StudentLastName.IsNull)
            txtStudentLastName.Text = entStudent.StudentLastName.Value.ToString();

        if (!entStudent.StudentEnrollmentNumber.IsNull)
            txtStudentEnrollmentNumber.Text = entStudent.StudentEnrollmentNumber.Value.ToString();

        if (!entStudent.StudentMobileNumber.IsNull)
            txtStudentMobileNumber.Text = entStudent.StudentMobileNumber.Value.ToString();

        if (!entStudent.StudentPersonalEmailAddress.IsNull)
            txtStudentPersonalEmailAddress.Text = entStudent.StudentPersonalEmailAddress.Value.ToString();

        if (!entStudent.StudentCollegeEmailAddress.IsNull)
            txtStudentCollegeEmailAddress.Text = entStudent.StudentCollegeEmailAddress.Value.ToString();

        if (!entStudent.StudentCurrentSemester.IsNull)
        {
            CommonFillMethods.FillDropDownListSemesterByDepartmentID(ddlStudentCurrentSemester, Convert.ToInt32(entStudent.DepartmentID.Value.ToString()));
            ddlStudentCurrentSemester.SelectedValue = entStudent.StudentCurrentSemester.Value.ToString();
        }

        if (!entStudent.StudentAdmissionYear.IsNull)
            txtStudentAdmissionYear.Text = entStudent.StudentAdmissionYear.Value.ToString();

        if (!entStudent.DepartmentID.IsNull)
        {
            CommonFillMethods.FillDropDownListDepartmentByCourseID(ddlDepartmentName, Convert.ToInt32(entStudent.CourseID.Value.ToString()));
            ddlDepartmentName.SelectedValue = entStudent.DepartmentID.Value.ToString();
        }

        if (!entStudent.CourseID.IsNull)
        {
            CommonFillMethods.FillDropDownListCourse(ddlCourseName);
            ddlCourseName.SelectedValue = entStudent.CourseID.Value.ToString();
        }

        if (!entStudentLoginDetail.StudentPassword.IsNull)
            txtPassword.Text = entStudentLoginDetail.StudentPassword.Value.ToString();
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
            CommonFillMethods.FillDropDownListEmpty(ddlStudentCurrentSemester, "Semester");
        }
        else
        {
            CommonFillMethods.FillDropDownListEmpty(ddlDepartmentName, "Department");
        }
    }
    #endregion Selected Index Changed - Course

    #region Selected Index Changed - Department
    protected void ddlDepartmentName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDepartmentName.SelectedIndex > 0)
        {
            CommonFillMethods.FillDropDownListSemesterByDepartmentID(ddlStudentCurrentSemester, Convert.ToInt32(ddlDepartmentName.SelectedValue));
        }
        else
        {
            CommonFillMethods.FillDropDownListEmpty(ddlStudentCurrentSemester, "Semester");
        }
    }
    #endregion Selected Index Changed - Course
}