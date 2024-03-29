using GrievanceSystem.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Default : System.Web.UI.Page
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
            lblPageTittle.Text = "Home";
            Course();
            Department();
            Semester();
            Grievance();
            Staff();
            StaffGrievance();
            Student();
            StudentGrievance();
        }
        #endregion Page Not Post Back
    }
    #endregion Page Load

    #region Counters

    #region Course
    private void Course()
    {
        CourseBAL balCourse = new CourseBAL();

        int Count = balCourse.Count();
        lblCourse.Text = Count.ToString();
    }
    #endregion Course

    #region Department
    private void Department()
    {
        DepartmentBAL balDepartment = new DepartmentBAL();

        int Count = balDepartment.Count();
        lblDepartment.Text = Count.ToString();
    }
    #endregion Department

    #region Semester
    private void Semester()
    {
        SemesterBAL balSemester = new SemesterBAL();

        int Count = balSemester.Count();
        lblSemester.Text = Count.ToString();
    }
    #endregion Semester

    #region Grievance
    private void Grievance()
    {
        GrievanceBAL balGrievance = new GrievanceBAL();

        int Count = balGrievance.Count();
        lblGrievance.Text = Count.ToString();
    }
    #endregion Grievance

    #region Staff
    private void Staff()
    {
        StaffBAL balStaff = new StaffBAL();

        int Count = balStaff.Count();
        lblStaff.Text = Count.ToString();
    }
    #endregion Staff

    #region StaffGrievance
    private void StaffGrievance()
    {
        StaffGrievanceBAL balStaffGrievance = new StaffGrievanceBAL();

        int Count = balStaffGrievance.Count();
        lblStaffGrievance.Text = Count.ToString();
    }
    #endregion StaffGrievance

    #region Student
    private void Student()
    {
        StudentBAL balStudent = new StudentBAL();

        int Count = balStudent.Count();
        lblStudent.Text = Count.ToString();
    }
    #endregion Student

    #region StudentGrievance
    private void StudentGrievance()
    {
        StudentGrievanceBAL balStudentGrievance = new StudentGrievanceBAL();

        int Count = balStudentGrievance.Count();
        lblStudentGrievance.Text = Count.ToString();
    }
    #endregion StudentGrievance

    #endregion Counter
}