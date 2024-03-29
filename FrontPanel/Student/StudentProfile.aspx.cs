using GrievanceSystem.BAL;
using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontPanel_Student_StudentProfile : System.Web.UI.Page
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

        #region Page Not Post Back
        if (!Page.IsPostBack)
        {
            lblPageTittle.Text = "Student Profile";
            lblCardTitle.Text = "Student Profile";
            lblBreadcrumb.Text = "Student Profile";
            FillStudentDetails();
        }
        #endregion Page Not Post Back
    }
    #endregion Page Load

    #region Button: Back
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FrontPanel/Student/Default.aspx");
    }
    #endregion button: Back

    #region Fill Student Details
    protected void FillStudentDetails()
    {
        StudentENT entStudent = new StudentENT();
        StudentBAL balStudent = new StudentBAL();

        entStudent = balStudent.SelectByPK(Convert.ToInt32(Session["StudentID"]));

        if (!entStudent.StudentFirstName.IsNull)
            lblFirstNameDetail.Text = entStudent.StudentFirstName.Value.ToString();

        if (!entStudent.StudentMiddleName.IsNull)
            lblMiddleNameDetail.Text = entStudent.StudentMiddleName.Value.ToString();

        if (!entStudent.StudentLastName.IsNull)
            lblLastNameDetail.Text = entStudent.StudentLastName.Value.ToString();

        if (!entStudent.StudentEnrollmentNumber.IsNull)
            lblEnrollmentNumberDetail.Text = entStudent.StudentEnrollmentNumber.Value.ToString();

        if (!entStudent.StudentMobileNumber.IsNull)
            lblMobileNumberDetail.Text = entStudent.StudentMobileNumber.Value.ToString();

        if (!entStudent.StudentPersonalEmailAddress.IsNull)
            lblPersonalEmailAddressDetail.Text = entStudent.StudentPersonalEmailAddress.Value.ToString();

        if (!entStudent.StudentCollegeEmailAddress.IsNull)
            lblCollegeEmailAddressDetail.Text = entStudent.StudentCollegeEmailAddress.Value.ToString();

        if (!entStudent.StudentCurrentSemester.IsNull)
            lblCurrentSemesterDetail.Text = entStudent.StudentCurrentSemester.Value.ToString();

        if (!entStudent.StudentAdmissionYear.IsNull)
            lblAdmissionYearDetail.Text = entStudent.StudentAdmissionYear.Value.ToString();
    }
    #endregion Fill Student Details
}