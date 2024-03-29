using GrievanceSystem.BAL;
using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_StudentGrievance_StudentGrievanceDetail : System.Web.UI.Page
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
            lblPageTittle.Text = "Student Grievance Details";
            lblCardTitle.Text = lblPageTittle.Text;
            lblBreadcrumb.Text = lblPageTittle.Text;
            FillControls(Convert.ToInt32(Request.QueryString["StudentGrievanceID"]));
        }
        #endregion Page Not Post Back
    }
    #endregion Page Load

    #region Fill Controls
    private void FillControls(SqlInt32 StudentGrievanceID)
    {
        StudentGrievanceENT entStudentGrievance = new StudentGrievanceENT();
        StudentGrievanceBAL balStudentGrievance = new StudentGrievanceBAL();
        StudentENT entStudent = new StudentENT();
        StudentBAL balStudent = new StudentBAL();
        GrievanceENT entGrievance = new GrievanceENT();
        GrievanceBAL balGrievance = new GrievanceBAL();
        DepartmentENT entDepartment = new DepartmentENT();
        DepartmentBAL balDepartment = new DepartmentBAL();
        CourseENT entCourse = new CourseENT();
        CourseBAL balCourse = new CourseBAL();

        entStudentGrievance = balStudentGrievance.SelectByPK(StudentGrievanceID);
        entStudent = balStudent.SelectByPK(Convert.ToInt32(entStudentGrievance.StudentID.Value.ToString()));
        entGrievance = balGrievance.SelectByPK(Convert.ToInt32(entStudentGrievance.GrievanceID.Value.ToString()));
        entDepartment = balDepartment.SelectByPK(Convert.ToInt32(entStudent.DepartmentID.Value.ToString()));
        entCourse = balCourse.SelectByPK(Convert.ToInt32(entStudent.CourseID.Value.ToString()));

        if (!entGrievance.GrievanceName.IsNull)
            txtGrievanceName.Text = entGrievance.GrievanceName.Value.ToString();

        if (!entStudentGrievance.GrievanceStatus.IsNull)
            txtGrievanceStatus.Text = entStudentGrievance.GrievanceStatus.Value.ToString();

        if (!entStudentGrievance.GrievanceDescription.IsNull)
            txtGrievanceDescription.Text = entStudentGrievance.GrievanceDescription.Value.ToString();

        if (!entStudentGrievance.GrievanceDate.IsNull)
            txtGrievanceDate.Text = entStudentGrievance.GrievanceDate.Value.ToString();

        if (!entStudentGrievance.GrievanceUpdateDate.IsNull)
            txtGrievanceUpdateDate.Text = entStudentGrievance.GrievanceUpdateDate.Value.ToString();

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
            txtStudentCurrentSemester.Text = entStudent.StudentCurrentSemester.Value.ToString();

        if (!entStudent.StudentAdmissionYear.IsNull)
            txtStudentAdmissionYear.Text = entStudent.StudentAdmissionYear.Value.ToString();

        if (!entStudent.DepartmentID.IsNull)
            txtDepartmentName.Text = entDepartment.DepartmentName.Value.ToString();

        if (!entStudent.CourseID.IsNull)
            txtCourseName.Text = entCourse.CourseName.Value.ToString();

        if (entStudentGrievance.GrievanceStatus != "Registered" && entStudentGrievance.GrievanceStatus != "Updated")
            btnCallMeeting.Enabled = false;

        if (entStudentGrievance.GrievanceStatus != "In-Progress")
        {
            btnNotGrievance.Enabled = false;
            btnResolve.Enabled = false;
        }
    }
    #endregion Fill Controls

    #region Button: Back - Click
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/UserGrievanceList.aspx");
    }
    #endregion Button: Back - Click

    #region Button Call Meeting - Click
    protected void btnCallMeeting_Click(object sender, EventArgs e)
    {
        StudentGrievanceBAL balStudentGrievance = new StudentGrievanceBAL();
        if (balStudentGrievance.UpdateStatusToInProgress(Convert.ToInt32(Request.QueryString["StudentGrievanceID"])))
        {
            Response.Redirect(Request.RawUrl);
        }
        else
        {
            lblErrorMessage.Text = balStudentGrievance.Message;
            pnlErrorMessage.Visible = true;
        }
    }
    #endregion Button Call Meeting - Click

    #region Button Not Grievance - Click
    protected void btnNotGrievance_Click(object sender, EventArgs e)
    {
        StudentGrievanceBAL balStudentGrievance = new StudentGrievanceBAL();
        if (balStudentGrievance.UpdateStatusToRejected(Convert.ToInt32(Request.QueryString["StudentGrievanceID"])))
        {
            Response.Redirect(Request.RawUrl);
        }
        else
        {
            lblErrorMessage.Text = balStudentGrievance.Message;
            pnlErrorMessage.Visible = true;
        }
    }
    #endregion Button Not Grievance - Click

    #region Button Resolve - Click
    protected void btnResolve_Click(object sender, EventArgs e)
    {
        StudentGrievanceBAL balStudentGrievance = new StudentGrievanceBAL();
        if (balStudentGrievance.UpdateStatusToResolve(Convert.ToInt32(Request.QueryString["StudentGrievanceID"])))
        {
            Response.Redirect(Request.RawUrl);
        }
        else
        {
            lblErrorMessage.Text = balStudentGrievance.Message;
            pnlErrorMessage.Visible = true;
        }
    }
    #endregion Button Resolve - Click
}