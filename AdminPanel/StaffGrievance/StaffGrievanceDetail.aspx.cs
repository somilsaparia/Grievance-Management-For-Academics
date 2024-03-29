using GrievanceSystem.BAL;
using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_StaffGrievance_StaffGrievanceDetail : System.Web.UI.Page
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
            lblPageTittle.Text = "Staff Grievance Detail";
            lblCardTitle.Text = lblPageTittle.Text;
            lblBreadcrumb.Text = lblPageTittle.Text;
            FillControls(Convert.ToInt32(Request.QueryString["StaffGrievanceID"]));
        }
        #endregion Page Not Post Back
    }
    #endregion Page Load

    #region Fill Controls
    private void FillControls(SqlInt32 StaffGrievanceID)
    {
        StaffGrievanceENT entStaffGrievance = new StaffGrievanceENT();
        StaffGrievanceBAL balStaffGrievance = new StaffGrievanceBAL();
        StaffENT entStaff = new StaffENT();
        StaffBAL balStaff = new StaffBAL();
        GrievanceENT entGrievance = new GrievanceENT();
        GrievanceBAL balGrievance = new GrievanceBAL();
        DepartmentENT entDepartment = new DepartmentENT();
        DepartmentBAL balDepartment = new DepartmentBAL();
        CourseENT entCourse = new CourseENT();
        CourseBAL balCourse = new CourseBAL();

        entStaffGrievance = balStaffGrievance.SelectByPK(StaffGrievanceID);
        entStaff = balStaff.SelectByPK(Convert.ToInt32(entStaffGrievance.StaffID.Value.ToString()));
        entGrievance = balGrievance.SelectByPK(Convert.ToInt32(entStaffGrievance.GrievanceID.Value.ToString()));
        entDepartment = balDepartment.SelectByPK(Convert.ToInt32(entStaff.DepartmentID.Value.ToString()));
        entCourse = balCourse.SelectByPK(Convert.ToInt32(entStaff.CourseID.Value.ToString()));

        if (!entGrievance.GrievanceName.IsNull)
            txtGrievanceName.Text = entGrievance.GrievanceName.Value.ToString();

        if (!entStaffGrievance.GrievanceStatus.IsNull)
            txtGrievanceStatus.Text = entStaffGrievance.GrievanceStatus.Value.ToString();

        if (!entStaffGrievance.GrievanceDescription.IsNull)
            txtGrievanceDescription.Text = entStaffGrievance.GrievanceDescription.Value.ToString();

        if (!entStaffGrievance.GrievanceDate.IsNull)
            txtGrievanceDate.Text = entStaffGrievance.GrievanceDate.Value.ToString();

        if (!entStaffGrievance.GrievanceUpdateDate.IsNull)
            txtGrievanceUpdateDate.Text = entStaffGrievance.GrievanceUpdateDate.Value.ToString();

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
            txtDepartmentName.Text = entDepartment.DepartmentName.Value.ToString();

        if (!entStaff.CourseID.IsNull)
            txtCourseName.Text = entCourse.CourseName.Value.ToString();

        if (entStaffGrievance.GrievanceStatus != "Registered" && entStaffGrievance.GrievanceStatus != "Updated")
            btnCallMeeting.Enabled = false;

        if (entStaffGrievance.GrievanceStatus != "In-Progress")
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
        StaffGrievanceBAL balStaffGrievance = new StaffGrievanceBAL();
        if (balStaffGrievance.UpdateStatusToInProgress(Convert.ToInt32(Request.QueryString["StaffGrievanceID"])))
        {
            Response.Redirect(Request.RawUrl);
        }
        else
        {
            lblErrorMessage.Text = balStaffGrievance.Message;
            pnlErrorMessage.Visible = true;
        }
    }
    #endregion Button Call Meeting - Click

    #region Button Not Grievance - Click
    protected void btnNotGrievance_Click(object sender, EventArgs e)
    {
        StaffGrievanceBAL balStaffGrievance = new StaffGrievanceBAL();
        if (balStaffGrievance.UpdateStatusToRejected(Convert.ToInt32(Request.QueryString["StaffGrievanceID"])))
        {
            Response.Redirect(Request.RawUrl);
        }
        else
        {
            lblErrorMessage.Text = balStaffGrievance.Message;
            pnlErrorMessage.Visible = true;
        }
    }
    #endregion Button Not Grievance - Click

    #region Button Resolve - Click
    protected void btnResolve_Click(object sender, EventArgs e)
    {
        StaffGrievanceBAL balStaffGrievance = new StaffGrievanceBAL();
        if (balStaffGrievance.UpdateStatusToResolve(Convert.ToInt32(Request.QueryString["StaffGrievanceID"])))
        {
            Response.Redirect(Request.RawUrl);
        }
        else
        {
            lblErrorMessage.Text = balStaffGrievance.Message;
            pnlErrorMessage.Visible = true;
        }
    }
    #endregion Button Resolve - Click
}