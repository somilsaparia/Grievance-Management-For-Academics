using GrievanceSystem.BAL;
using GrievanceSystem.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Login : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.UrlReferrer != null)
            {
                string staff = "/FrontPanel/Staff/";
                string student = "/FrontPanel/Student/";
                string previousPageUrl = Request.UrlReferrer.AbsoluteUri;

                if (previousPageUrl.Contains(staff) == true)
                {
                    upnlAdminLogin.Visible = false;
                    upnlStudentLogin.Visible = false;
                    upnlStaffLogin.Visible = true;
                    Title.Text = "Staff Login";
                }
                else if (previousPageUrl.Contains(student) == true)
                {
                    upnlAdminLogin.Visible = false;
                    upnlStaffLogin.Visible = false;
                    upnlStudentLogin.Visible = true;
                    Title.Text = "Student Login";
                }
                else
                {
                    Title.Text = "Admin Login";
                }
            }
            else
            {
                Title.Text = "Admin Login";
            }
        }
    }
    #endregion Page Load

    #region Update Panel - Admin Login

    #region Button - Login
    protected void btnLogin_Admin_Click(object sender, EventArgs e)
    {
        #region Local Variables
        String strErrorMessage = "";
        pnlErrorMessage.Visible = false;
        #endregion Local Variables

        #region Server Side Validation
        if (txtUserName.Text.ToString().Trim() == "")
        {
            strErrorMessage += "Please enter User Name <br />";
        }

        if (txtPassword.Text.ToString().Trim() == "")
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

        #region Login
        AdminLoginDetailBAL balAdminLoginDetail = new AdminLoginDetailBAL();
        AdminLoginDetailENT entAdminLoginDetail = new AdminLoginDetailENT();

        entAdminLoginDetail = balAdminLoginDetail.SelectByUserNamePassword(txtUserName.Text.ToString().Trim(), txtPassword.Text.ToString().Trim());

        if (!entAdminLoginDetail.AdminLoginDetailID.IsNull)
        {
            if (!entAdminLoginDetail.AdminLoginDetailID.IsNull)
                Session["UserID"] = entAdminLoginDetail.AdminLoginDetailID.ToString().Trim();

            if (!entAdminLoginDetail.AdminUserName.IsNull)
                Session["UserName"] = entAdminLoginDetail.AdminUserName.ToString().Trim();

            Response.Redirect("~/AdminPanel/Default.aspx");
        }
        else
        {
            pnlErrorMessage.Visible = true;
            lblErrorMessage.Text = "Invalid Credentials";
        }

        #endregion Login
    }
    #endregion Button - Login

    #region Button - Staff Login
    protected void btnStaffLogin_Admin_Click(object sender, EventArgs e)
    {
        upnlAdminLogin.Visible = false;
        upnlStudentLogin.Visible = false;
        upnlStaffLogin.Visible = true;
        Title.Text = "Staff Login";
    }
    #endregion Button - Staff Login

    #region Button - Student Login
    protected void btnStudentLogin_Admin_Click(object sender, EventArgs e)
    {
        upnlAdminLogin.Visible = false;
        upnlStaffLogin.Visible = false;
        upnlStudentLogin.Visible = true;
        Title.Text = "Student Login";
    }
    #endregion Button - Student Login

    #endregion Update Panel - Admin Login

    #region Update Panel - Staff Login

    #region Button - Login
    protected void btnLogin_Staff_Click(object sender, EventArgs e)
    {
        #region Local Variables
        String strErrorMessage = "";
        pnlErrorMessage.Visible = false;
        #endregion Local Variables

        #region Server Side Validation
        if (txtStaffCode.Text.ToString().Trim() == "")
        {
            strErrorMessage += "Please enter Staff Code <br />";
        }

        if (txtStaffPassword.Text.ToString().Trim() == "")
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

        #region Login
        StaffLoginDetailBAL balStaffLoginDetail = new StaffLoginDetailBAL();
        StaffLoginDetailENT entStaffLoginDetail = new StaffLoginDetailENT();

        entStaffLoginDetail = balStaffLoginDetail.SelectByStaffCodePassword(txtStaffCode.Text.ToString().Trim(), txtStaffPassword.Text.ToString().Trim());

        if (!entStaffLoginDetail.StaffLoginDetailID.IsNull)
        {
            if (!entStaffLoginDetail.StaffID.IsNull)
                Session["StaffID"] = entStaffLoginDetail.StaffID.ToString().Trim();

            if (!entStaffLoginDetail.StaffCode.IsNull)
                Session["StaffCode"] = entStaffLoginDetail.StaffCode.ToString().Trim();

            Response.Redirect("~/FrontPanel/Staff/Default.aspx");
        }
        else
        {
            pnlErrorMessage.Visible = true;
            lblErrorMessage.Text = "Invalid Credentials";
        }

        #endregion Login
    }
    #endregion Button - Login

    #region Button - Admin Login
    protected void btnAdminLogin_Staff_Click(object sender, EventArgs e)
    {
        upnlStaffLogin.Visible = false;
        upnlStudentLogin.Visible = false;
        upnlAdminLogin.Visible = true;
        Title.Text = "Admin Login";
    }
    #endregion Button - Admin Login

    #region Button - Student Login
    protected void btnStudentLogin_Staff_Click(object sender, EventArgs e)
    {
        upnlStaffLogin.Visible = false;
        upnlAdminLogin.Visible = false;
        upnlStudentLogin.Visible = true;
        Title.Text = "Student Login";
    }
    #endregion Button - Student Login

    #endregion Update Panel - Staff Login

    #region Update Panel - Student

    #region Button - Login
    protected void btnStudentLogin_Student_Click(object sender, EventArgs e)
    {
        #region Local Variables
        String strErrorMessage = "";
        pnlErrorMessage.Visible = false;
        #endregion Local Variables

        #region Server Side Validation
        if (txtStudentEnrollmentNumber.Text.ToString().Trim() == "")
        {
            strErrorMessage += "Please enter Enrollment Number <br />";
        }

        if (txtStudentPassword.Text.ToString().Trim() == "")
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

        #region Login
        StudentLoginDetailBAL balStudentLoginDetail = new StudentLoginDetailBAL();
        StudentLoginDetailENT entStudentLoginDetail = new StudentLoginDetailENT();

        entStudentLoginDetail = balStudentLoginDetail.SelectByEnrollmentNumberPassword(txtStudentEnrollmentNumber.Text.ToString().Trim(), txtStudentPassword.Text.ToString().Trim());

        if (!entStudentLoginDetail.StudentLoginDetailID.IsNull)
        {
            if (!entStudentLoginDetail.StudentID.IsNull)
                Session["StudentID"] = entStudentLoginDetail.StudentID.ToString().Trim();

            if (!entStudentLoginDetail.StudentEnrollmentNumber.IsNull)
                Session["EnrollmentNumber"] = entStudentLoginDetail.StudentEnrollmentNumber.ToString().Trim();

            Response.Redirect("~/FrontPanel/Student/Default.aspx");
        }
        else
        {
            pnlErrorMessage.Visible = true;
            lblErrorMessage.Text = "Invalid Credentials";
        }

        #endregion Login
    }
    #endregion Button - Login

    #region Button - Admin Login
    protected void btnAdminLogin_Student_Click(object sender, EventArgs e)
    {
        upnlStudentLogin.Visible = false;
        upnlStaffLogin.Visible = false;
        upnlAdminLogin.Visible = true;
        Title.Text = "Admin Login";
    }
    #endregion Button - Admin Login

    #region Button - Staff Login
    protected void btnStaffLogin_Student_Click(object sender, EventArgs e)
    {
        upnlStudentLogin.Visible = false;
        upnlAdminLogin.Visible = false;
        upnlStaffLogin.Visible = true;
        Title.Text = "Staff Login";
    }
    #endregion Button - Staff Login

    #endregion Update Panel - Student
}